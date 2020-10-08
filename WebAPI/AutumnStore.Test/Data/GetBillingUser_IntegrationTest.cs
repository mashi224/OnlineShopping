using AutoMapper;
using AutumnStore.Data.Helpers;
using AutumnStore.Data.Helpers.Seed;
using AutumnStore.Data.Repository;
using AutumnStore.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AutumnStore.Test.Data
{
    public class GetBillingUser_IntegrationTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly Mock<IWebHostEnvironment> _webHostEnvironmentMock;

        public GetBillingUser_IntegrationTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _webHostEnvironmentMock = new Mock<IWebHostEnvironment>();

            _webHostEnvironmentMock.Setup(m => m.EnvironmentName).Returns("TestEnvironment");
        }

        [Fact]
        public async Task ShouldRetrieveBillingUser()
        {
            var services = new ServiceCollection().AddEntityFrameworkInMemoryDatabase();
            services.AddSingleton(_webHostEnvironmentMock.Object);
            services.AddDbContext<DataContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDB");
            });

            // mapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfiles>();
            });
            IMapper mapper = config.CreateMapper();

            var serviceProvider = services.BuildServiceProvider();
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var dataContext = scopedServices.GetRequiredService<DataContext>();
                DbContextSeed.SeedAsync(dataContext).Wait();

                var paymentRepository = new PaymentRepository(dataContext, mapper);
                UserForRegisterDto userDetails = await paymentRepository.GetBillingUser(1).ConfigureAwait(false);

                Assert.Equal("Nemo", userDetails.FirstName);

            }
        }
    }
}
