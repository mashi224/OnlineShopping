using AutumnStore.Business;
using AutumnStore.Data.Repository.Interfaces;
using AutumnStore.Data.UnitOfWork;
using AutumnStore.Entity;
using EmailService;
using Microsoft.AspNetCore.Hosting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AutumnStore.Test.Business
{
    public class CompletePaymentTest
    {
        private readonly Mock<IPaymentRepository> _paymentRepositoryMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        readonly DateTime localDateTime;
        private readonly Mock<IEmailSender> _emailSenderMock;
        private readonly Mock<IWebHostEnvironment> _webHostEnvironmentMock;

        public CompletePaymentTest()
        {
            _paymentRepositoryMock = new Mock<IPaymentRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            localDateTime = DateTime.Now;
            _emailSenderMock = new Mock<IEmailSender>();
            _webHostEnvironmentMock = new Mock<IWebHostEnvironment>();
        }

        [Fact]
        public async Task Should_Return__Null_When_Saving_OrderAndOrderProducts_Failed()
        {
            //var orderedProductsDto = new OrderedProductsDto() { };

            var orderDto = new OrderDto()
            {
                UserId = 16,
                Username = "nemo",
                OrderedProductsDto = null
            };

            _paymentRepositoryMock.Setup(x => x.CompletePayment(orderDto, localDateTime));
            //await _paymentRepositoryMock.Object.AddAsync(null);

            _unitOfWorkMock.Setup(m => m.PaymentRepository).Returns(_paymentRepositoryMock.Object);

            var paymentManagement = new PaymentManagement(_unitOfWorkMock.Object, _emailSenderMock.Object, _webHostEnvironmentMock.Object);
            var result = await paymentManagement.CompletePayment(orderDto);

            Assert.Null(result);
        }

        //[Fact]
        //public async Task CompletePayment_Success()
        //{
        //    List<OrderedProductsDto> orderedProductsDtoList = new List<OrderedProductsDto>() {
        //        new OrderedProductsDto
        //        {
        //            ProductId = 8,
        //            ProductName = "Canopy Daybeds – Sleeping Under the Stars"
        //        }
        //    };

        //    var orderDto = new OrderDto()
        //    {
        //        UserId = 16,
        //        Username = "nemo",
        //        OrderedProductsDto = orderedProductsDtoList
        //    };

        //    IEnumerable<OrderDetailsDto> orderDetailsDto = new List<OrderDetailsDto>()
        //    {
        //        new OrderDetailsDto
        //        {
        //            OrderId = 1,
        //            ReceiverFirstName = "Nemo"

        //        }
        //    };

        //    _paymentRepositoryMock.Setup(x => x.OrderHistoryData(orderDto)).Returns(orderDetailsDto);
        //    //await _paymentRepositoryMock.Object.AddAsync(null);

        //    _unitOfWorkMock.Setup(m => m.PaymentRepository).Returns(_paymentRepositoryMock.Object);

        //    var paymentManagement = new PaymentManagement(_unitOfWorkMock.Object, _emailSenderMock.Object, _webHostEnvironmentMock.Object);
        //    var result = await paymentManagement.SendEmailData(orderDto).ConfigureAwait(true);

        //    Assert.NotNull(result);
        //    Assert.IsAssignableFrom<IEnumerable<OrderDetailsDto>>(result);
        //    var resultsList = result.ToList();
        //    Assert.Single(resultsList);
        //}
    }
}
