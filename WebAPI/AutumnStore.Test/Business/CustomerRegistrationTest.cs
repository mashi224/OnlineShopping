using AutumnStore.Business;
using AutumnStore.Data.Repository.Interfaces;
using AutumnStore.Data.UnitOfWork;
using AutumnStore.Entity;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AutumnStore.Test.Business
{
    public class CustomerRegistrationTest
    {
        private readonly Mock<IAuthRepository> _authRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IConfiguration> _configMock;
        readonly DateTime localDateTime;

        public CustomerRegistrationTest()
        {
            _authRepositoryMock = new Mock<IAuthRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _configMock = new Mock<IConfiguration>();
            localDateTime = DateTime.Now;
        }

        //[Fact]
        //public async Task Should_Return__Exception_When_User_IsNull() 
        //{
        //    _authRepositoryMock.Setup(x => x.Register(null, null, localDateTime));
        //    await _authRepositoryMock.Object.Register(null, null, localDateTime);

        //    _unitOfWorkMock.Setup(m => m.AuthRepository).Returns(_authRepositoryMock.Object);

        //    var authManagementResult = new AuthManagement(_unitOfWorkMock.Object, _configMock.Object);

        //    //var result = await authManagement.Register(null).ConfigureAwait(false);
        //    //await Assert.Equal("400", result);
        //}

        [Fact]
        public async Task RegisterCustomer()
        {
            var userDto = new UserForRegisterDto()
            {
                FirstName = "Nemo",
                LastName = "Memo",
                UserName = "nemo"
            };

            _authRepositoryMock.Setup(x => x.Register(userDto, "1234", localDateTime)).ReturnsAsync(userDto);
            //await _authRepositoryMock.Object.Register(userDto, "1234", localDateTime);

            _unitOfWorkMock.Setup(m => m.AuthRepository).Returns(_authRepositoryMock.Object);

            var authManagement = new AuthManagement(_unitOfWorkMock.Object, _configMock.Object);
            var isUserRegistered = await authManagement.Register(userDto).ConfigureAwait(false);

            Assert.False(isUserRegistered);
            
        }

        [Fact]
        public async Task RegisterCustomer_Fail_When_UserExists()
        {
            var userDto = new UserForRegisterDto()
            {
                FirstName = "Nemo",
                LastName = "Memo",
                UserName = "nemo"
            };

            _authRepositoryMock.Setup(y => y.UserExists(userDto.UserName)).ReturnsAsync(true);

            _unitOfWorkMock.Setup(m => m.AuthRepository).Returns(_authRepositoryMock.Object);

            var authManagement = new AuthManagement(_unitOfWorkMock.Object, _configMock.Object);
            var isUserRegistered = await authManagement.Register(userDto).ConfigureAwait(false);

            Assert.True(isUserRegistered);

        }

    }
}
