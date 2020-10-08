using AutumnStore.Data.UnitOfWork;
using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using AutumnStore.Entity;
using AutumnStore.Data.Repository.Interfaces;
using System.Threading.Tasks;
using AutumnStore.Business;

namespace AutumnStore.Test.Business
{
    public class RetrieveAllCategoriesTest
    {
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
        readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public RetrieveAllCategoriesTest()
        {
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async Task Should_Return__Exception_When_CategoriesNotAvailable()
        {
            var categoryManagement = new CategoryManagement(_unitOfWorkMock.Object);
            _unitOfWorkMock.Setup(m => m.CategoryRepository).Returns(_categoryRepositoryMock.Object);
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await categoryManagement.GetCategories().ConfigureAwait(false));
        }

        [Fact]
        public async Task ShouldRetrieveAllCategories()
        {
            List<CategoryDto> categoryList = new List<CategoryDto>()
            {
                new CategoryDto
                {
                    CategoryId = 1,
                    CategoryName = "CHAIRS"
                    //CategoryDesc = ""
                },
                  new CategoryDto
                {
                    CategoryId = 2,
                    CategoryName = "COFFEE TABLES"
                }
            };

            _categoryRepositoryMock.Setup(x => x.GetCategories()).ReturnsAsync(categoryList);
            _unitOfWorkMock.Setup(m => m.CategoryRepository).Returns(_categoryRepositoryMock.Object);

            var categoryManagement = new CategoryManagement(_unitOfWorkMock.Object);
            List<CategoryDto> categories = await categoryManagement.GetCategories().ConfigureAwait(false);

            Assert.NotNull(categories);
            Assert.IsAssignableFrom<List<CategoryDto>>(categories);
            Assert.Equal(2, categories.Count);

        }

    }
}
