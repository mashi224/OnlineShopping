using AutoMapper;
using AutumnStore.Data;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AutumnStore.Test.Data
{
    public class RetrieveProductsToGivenCategory_IntegrationTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly Mock<IWebHostEnvironment> _webHostEnvironmentMock;

        public RetrieveProductsToGivenCategory_IntegrationTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _webHostEnvironmentMock = new Mock<IWebHostEnvironment>();

            _webHostEnvironmentMock.Setup(m => m.EnvironmentName).Returns("TestEnvironment");
        }

        [Fact]
        public async Task ShouldRetrieveProducts_ToGivenCategory()
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

                var productRepository = new ProductRepository(dataContext, mapper);
                var products = await productRepository.GetProducts(1).ConfigureAwait(false);

                var productList = products.ToList();
                Assert.Equal(2, productList.Count);

            }
        }
    }
}
