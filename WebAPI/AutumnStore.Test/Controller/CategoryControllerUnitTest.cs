//using AutoMapper;
//using AutumnStore.Business.Interfaces;
//using AutumnStore.Controller;
//using AutumnStore.Data.Model;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using System.Collections.Generic;

//namespace AutumnStore.Test.Controller
//{
//    [TestClass]
//    public class CategoryControllerUnitTest
//    {
//        CategoryController _categoryController;

//        Mock<ICategoryManagement> _categoryManagementMock;
//        Mock<IMapper> _mapperMock;

//        [TestInitialize]
//        public void CategoryControllerInitialize()
//        {
//            _mapperMock = new Mock<IMapper>();
//            _categoryManagementMock = new Mock<ICategoryManagement>();
//        }

//        [TestMethod]
//        public void GetCategories_WhenSuccessful_ReturnCategoryList()
//        {
//            List<Category> categoryObj = new List<Category>();
//            Category category = new Category();
//            category.Id = 1;
//            category.CategoryName = "TestCategory";

//            categoryObj.Add(category);

//            // mock setup


//            //_categoryController = new CategoryController(_categoryManagementMock.Object, _mapperMock.Object, _categoryController.Object);
//        }
//    }
//}
