using AutoMapper;
using AutumnStore.Data;
using AutumnStore.Data.Helpers;
using AutumnStore.Data.Helpers.Seed;
using AutumnStore.Data.Model;
using AutumnStore.Data.Repository;
using AutumnStore.Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AutumnStore.Test.Data
{
    public class RetrieveAllCategories_IntegrationTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly Mock<IWebHostEnvironment> _webHostEnvironmentMock;
        //private readonly Mock<IMapper> _mapperMock;

        public RetrieveAllCategories_IntegrationTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _webHostEnvironmentMock = new Mock<IWebHostEnvironment>();

            _webHostEnvironmentMock.Setup(m => m.EnvironmentName).Returns("TestEnvironment");
        }

        [Fact]
        public async Task ShouldretrieveAllCategories()
        {
            var services = new ServiceCollection().AddEntityFrameworkInMemoryDatabase();
            services.AddSingleton(_webHostEnvironmentMock.Object);
            services.AddDbContext<DataContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDB");
            });

            //var configuration = new MapperConfiguration(c => c.AddMaps(Assembly.Load("AutumnStore.Test")));
            //var mapper = new Mapper(configuration);

            // mapper
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<AutoMapperProfiles>();
            });
            IMapper mapper = config.CreateMapper();

            var serviceProvider = services.BuildServiceProvider();
            using (var scope = serviceProvider.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var dataContext = scopedServices.GetRequiredService<DataContext>();
                DbContextSeed.SeedAsync(dataContext).Wait();

                //_mapperMock.Setup(m => m.Map<Category, CategoryDto>).Returns(categoryList);
                var categoryRepository = new CategoryRepository(dataContext, mapper);
                List<CategoryDto> categoryList = await categoryRepository.GetCategories().ConfigureAwait(false);
                    //.ProjectTo<CategoryDto>(mapper.ConfigurationProvider).ConfigureAwait(false);

                //Assert.IsAssignableFrom<CategoryDto>(Category);
                Assert.Equal(2, categoryList.Count);

            }
        }
    }
}
