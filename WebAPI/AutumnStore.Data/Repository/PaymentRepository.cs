using AutoMapper;
using AutumnStore.Data.Model;
using AutumnStore.Data.Repository.Interfaces;
using AutumnStore.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutumnStore.Data.Repository
{
    public class PaymentRepository: IPaymentRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PaymentRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserForRegisterDto> GetBillingUser(int userId)
        {
            User currentUser = await _context.User.FirstOrDefaultAsync(x => x.UserId == userId);
            return _mapper.Map<UserForRegisterDto>(currentUser);

        }

        public async Task<OrderDto> CompletePayment(OrderDto orderDto, DateTime localDateTime)
        {
            Order order = _mapper.Map<Order>(orderDto);

            order.OrderDate = localDateTime;

            await _context.Order.AddAsync(order);
            await _context.SaveChangesAsync();

            return orderDto;

        }

        public async Task<UserForEmailDto> UserDetailsForEmail(OrderDto orderDto)
        {
            User userFromRepo = await _context.User.Where(x => x.UserId == orderDto.UserId).FirstOrDefaultAsync();
            return _mapper.Map<UserForEmailDto>(userFromRepo);
        }

        public IEnumerable<OrderDetailsDto> OrderHistoryData(OrderDto orderDto)
        {
            var orderDetails = (from Order in _context.Order //.Cast<Order>()
                                                             //join User in _context.User
                                                             //    on Order.UserId equals User.UserId
                                                             //where Order.UserId == orderDto.UserId
                                 join OrderProduct in _context.OrderProduct
                                 //_context.Model.HasEntityTypeWithDefiningNavigation < OrderProduct >                                
                                 on Order.OrderId equals OrderProduct.OrderId
                                where Order.UserId == orderDto.UserId
                                select new OrderDetailsDto()
                                {
                                    OrderId = Order.OrderId,
                                    OrderDate = Order.OrderDate,
                                    OrderTotal = Order.OrderTotal,

                                    ReceiverFirstName = Order.ReceiverFirstName,
                                    ReceiverLastName = Order.ReceiverLastName,
                                    ReceiverEmail = Order.ReceiverEmail,
                                    ReceiverAddress = Order.ReceiverAddress,
                                    ReceiverAddress2 = Order.ReceiverAddress2,
                                    ReceiverCountry = Order.ReceiverCountry,
                                    ReceiverState = Order.ReceiverState,
                                    ReceiverZip = Order.ReceiverZip,

                                    ProductId = OrderProduct.ProductId,
                                    ProductName = OrderProduct.ProductName,
                                    ProductQty = OrderProduct.ProductQty,
                                    ProductPrice = OrderProduct.ProductPrice,

                                }).Distinct().OrderByDescending(x => x.OrderId).ToList();

            return orderDetails;
        }
    }
}
