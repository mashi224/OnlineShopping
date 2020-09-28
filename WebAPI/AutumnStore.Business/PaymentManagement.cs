using AutumnStore.Business.Interfaces;
using AutumnStore.Data.UnitOfWork;
using AutumnStore.Entity;
using EmailService;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AutumnStore.Business
{
    public class PaymentManagement : IPaymentManagement
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PaymentManagement(IUnitOfWork unitOfWork, IEmailSender emailSender, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<UserForRegisterDto> GetBillingUser(int userId)
        {
            return await _unitOfWork.PaymentRepository.GetBillingUser(userId);
        }

        public async Task<IEnumerable<OrderDetailsDto>> CompletePayment(OrderDto orderDto)
        {
            try
            {
                DateTime localDateTime = DateTime.Now;
                await _unitOfWork.PaymentRepository.CompletePayment(orderDto, localDateTime);
                _unitOfWork.Commit();

                var orderHistory = await SendEmailData(orderDto);

                return orderHistory;
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                return null;
            }
        }

        private async Task<IEnumerable<OrderDetailsDto>> SendEmailData(OrderDto orderDto)
        {
            UserForEmailDto userForEmailDto = await _unitOfWork.PaymentRepository.UserDetailsForEmail(orderDto);
            IEnumerable<OrderDetailsDto> orderDetailsDto = _unitOfWork.PaymentRepository.OrderHistoryData(orderDto);

            // Get last element of orderDetailsDto to get orderId and OrderDate
            OrderDetailsDto lastOrderDetailElement = orderDetailsDto.First();
            
            string emailBody = CreateBody(lastOrderDetailElement, orderDto, userForEmailDto);

            //var message = new Message(new string[] { "thamasha224@gmail.com" }, "Test Email async with attachment",
            //            "This is the content from our Email with attachment");

            var message = new Message(new string[] { userForEmailDto.UserEmail }, "Autumn Store_Proof of Purchase", emailBody);

            await _emailSender.SendEmailAsync(message);

            // return order history
            return orderDetailsDto;

        }

        private string CreateBody(OrderDetailsDto lastOrderDetailElement, OrderDto orderDto, UserForEmailDto userForEmailDto)
        {
            //var webRoot = _webHostEnvironment.WebRootPath; //get wwwroot folder
            var pathToFile = _webHostEnvironment.WebRootPath
                            + Path.DirectorySeparatorChar.ToString()
                            + "Templates"
                            + Path.DirectorySeparatorChar.ToString()
                            + "EmailTemplates"
                            + Path.DirectorySeparatorChar.ToString()
                            + "OrderConfirmationMail.html";

            string emailBody = string.Empty;
            using(StreamReader reader = new StreamReader(pathToFile))
            {
                emailBody = reader.ReadToEnd();
            }

            //Replacing parameters
            emailBody = emailBody.Replace("{FirstName}", userForEmailDto.FirstName);
            emailBody = emailBody.Replace("{LastName}", userForEmailDto.LastName);
            emailBody = emailBody.Replace("{UserAddress}", userForEmailDto.UserAddress);
            emailBody = emailBody.Replace("{UserAddress2}", userForEmailDto.UserAddress2);
            emailBody = emailBody.Replace("{State}", userForEmailDto.State);
            emailBody = emailBody.Replace("{Country}", userForEmailDto.Country);
            emailBody = emailBody.Replace("{Zip}", userForEmailDto.Zip);

            emailBody = emailBody.Replace("{ReceiverFirstName}", orderDto.ReceiverFirstName);
            emailBody = emailBody.Replace("{ReceiverLastName}", orderDto.ReceiverLastName);
            emailBody = emailBody.Replace("{ReceiverAddress}", orderDto.ReceiverAddress);
            emailBody = emailBody.Replace("{ReceiverAddress2}", orderDto.ReceiverAddress2);
            emailBody = emailBody.Replace("{ReceiverState}", orderDto.ReceiverState);
            emailBody = emailBody.Replace("{ReceiverCountry}", orderDto.ReceiverCountry);
            emailBody = emailBody.Replace("{ReceiverZip}", orderDto.ReceiverZip.ToString());

            emailBody = emailBody.Replace("{OrderId}", lastOrderDetailElement.OrderId.ToString());
            emailBody = emailBody.Replace("{OrderDate}", lastOrderDetailElement.OrderDate.ToString());
            emailBody = emailBody.Replace("{OrderTotal}", orderDto.OrderTotal.ToString());

            //Ordered products
            List<OrderedProductsDto> orderedProductsDto = orderDto.OrderedProductsDto;

            for (int i = 0; i < orderedProductsDto.Count; i++)
            {
                emailBody = emailBody.Replace("{ProductName}", orderedProductsDto[i].ProductName);
                emailBody = emailBody.Replace("{Qty}", orderedProductsDto[i].Qty.ToString());
                emailBody = emailBody.Replace("{Price}", orderedProductsDto[i].Price.ToString());
                emailBody = emailBody.Replace("{TotalPriceForProduct}", (orderedProductsDto[i].Qty * orderedProductsDto[i].Price).ToString());
            }

            return emailBody;
            
        }


    }
}
