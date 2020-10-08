using AutumnStore.Business;
using AutumnStore.Data.Repository.Interfaces;
using AutumnStore.Data.UnitOfWork;
using AutumnStore.Entity;
using EmailService;
using Microsoft.AspNetCore.Hosting;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AutumnStore.Test.Business
{
    public class GetBillingUserTest
    {
        private readonly Mock<IPaymentRepository> _paymentRepositoryMock;
        readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<IEmailSender> _emailSender;
        private Mock<IWebHostEnvironment> _webHostEnvironment;

        public GetBillingUserTest()
        {
            _paymentRepositoryMock = new Mock<IPaymentRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _emailSender = new Mock<IEmailSender>();
            _webHostEnvironment = new Mock<IWebHostEnvironment>();
        }

        [Fact]
        public async Task Should_Return__Exception_When_BillingUserIsNotAvailable()
        {
            var paymentManagement = new PaymentManagement(_unitOfWorkMock.Object, _emailSender.Object, _webHostEnvironment.Object);
            _unitOfWorkMock.Setup(m => m.PaymentRepository).Returns(_paymentRepositoryMock.Object);
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await paymentManagement.GetBillingUser(1).ConfigureAwait(false));
        }

        [Fact]
        public async Task ShouldRetrieveBillingUser()
        {
            UserForRegisterDto userDto;
            {
                userDto = new UserForRegisterDto()
                {
                    FirstName = "Nemo",
                    LastName = "Memo"
                };
            }

            _paymentRepositoryMock.Setup(x => x.GetBillingUser(1)).ReturnsAsync(userDto);
            _unitOfWorkMock.Setup(m => m.PaymentRepository).Returns(_paymentRepositoryMock.Object);

            var paymentManagement = new PaymentManagement(_unitOfWorkMock.Object, _emailSender.Object, _webHostEnvironment.Object);
            UserForRegisterDto billingUser = await paymentManagement.GetBillingUser(1).ConfigureAwait(false);

            Assert.NotNull(billingUser);
            Assert.IsAssignableFrom<UserForRegisterDto>(billingUser);
            Assert.Equal("Nemo", billingUser.FirstName);

        }
    }
}
