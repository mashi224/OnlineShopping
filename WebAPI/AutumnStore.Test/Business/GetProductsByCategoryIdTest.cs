using AutumnStore.Business;
using AutumnStore.Data.Repository.Interfaces;
using AutumnStore.Data.UnitOfWork;
using AutumnStore.Entity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AutumnStore.Test.Business
{
    public class GetProductsByCategoryIdTest
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public GetProductsByCategoryIdTest()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async Task Should_Return__Exception_When_ProductsNotAvailable()
        {
            var productManagement = new ProductManagement(_unitOfWorkMock.Object);
            _productRepositoryMock.Setup(x => x.GetProducts(1)).Returns((Task<IEnumerable<ProductDto>>) null);
            _unitOfWorkMock.Setup(m => m.ProductRepository).Returns(_productRepositoryMock.Object);
            await Assert.ThrowsAsync<NullReferenceException>(async () => await productManagement.GetProducts(1).ConfigureAwait(false));

        }
        
        [Fact]
        public async Task GetProducts_WhenSuccessful_ReturnProductList()
        {
            IEnumerable<ProductDto> productList = new List<ProductDto>()
            {
                new ProductDto
                {
                    ProductId = 1,
                    ProductName = "WASSILY CHAIR"
                }
            };

            _productRepositoryMock.Setup(x => x.GetProducts(1)).ReturnsAsync(productList);
            _unitOfWorkMock.Setup(m => m.ProductRepository).Returns(_productRepositoryMock.Object);

            var productManagement = new ProductManagement(_unitOfWorkMock.Object);
            IEnumerable<ProductDto> products = await productManagement.GetProducts(1).ConfigureAwait(false);

            Assert.NotNull(products);
            Assert.IsAssignableFrom<IEnumerable<ProductDto>>(products);
            Assert.Single(products);

        }
    }
}
