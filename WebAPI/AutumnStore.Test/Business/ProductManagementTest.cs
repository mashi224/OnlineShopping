using AutumnStore.Business;
using AutumnStore.Data.Repository.Interfaces;
using AutumnStore.Data.UnitOfWork;
using AutumnStore.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace AutumnStore.Test.Business
{
    [TestClass]
    public class ProductManagementTest
    {
        Mock<IUnitOfWork> _unitOfWorkMock;
        private ProductDto productDto;
        private ProductManagement productManagement;
        Mock<IProductRepository> _productRepositoryMock;

        [TestInitialize]
        public void ProductManagementInitialize()
        {
            List<ProductDto> productList = new List<ProductDto>();
            productDto = new ProductDto()
            {
                Id = 1,
                ProductName = "WASSILY CHAIR"
            };

            productList.Add(productDto);

            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _productRepositoryMock = new Mock<IProductRepository>();
            _productRepositoryMock.Setup(m => m.GetProducts(1)).ReturnsAsync(productList);
            _unitOfWorkMock.Setup(m => m.ProductRepository).Returns(_productRepositoryMock.Object);
        }

        [TestMethod]
        public void GetProducts_WhenSuccessful_ReturnProductList()
        {
            productManagement = new ProductManagement(_unitOfWorkMock.Object);

            IEnumerable<ProductDto> productObjectList = productManagement.GetProducts(1).GetAwaiter().GetResult();
            Assert.AreEqual("WASSILY CHAIR", productObjectList.ToList()[0].ProductName);
        }
    }
}
