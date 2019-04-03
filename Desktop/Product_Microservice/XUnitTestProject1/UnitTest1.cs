using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using Product.Persistence.Controllers;
using Product.Persistence.Domain.Contracts;
using Product.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        private object expected;

        [Fact]
        public void Test_GetProductApi_Returns_NotNull()
        {
            // Arrange
            var mockRepo = new Mock<IProductService>();
            mockRepo
                .Setup(repo => repo.GetProductList())
                .Returns(() => ListClasses.GetMockList());

            var controller = new ProductController(mockRepo.Object);

            // Act
            var result = controller.Get();

            ////Assert           
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_GetProductApi_Returns_NoException()
        {
            //It.IsAny<ProductDTO>
            // Arrange
            var mockRepo = new Mock<IProductService>();
            mockRepo
                .Setup(repo => repo.GetProductList())
                .Returns(() => ListClasses.GetMockList());

            var controller = new ProductController(mockRepo.Object);

            // Act
            JsonResult res = controller.Get() as JsonResult;

            ////Assert           
            try
            {
                Assert.Throws<InvalidOperationException>(() => res);
            }
            catch (AssertActualExpectedException exception)
            {
                Assert.Equal("(No exception was thrown)", exception.Actual);
            }
        }

        [Fact]
        public void Test_GetProductApi_Returns_TypeObject()
        {
            // Arrange
            var mockRepo = new Mock<IProductService>();
            mockRepo
                .Setup(repo => repo.GetProductList())
                .Returns(() => ListClasses.GetMockList());

            var controller = new ProductController(mockRepo.Object);

            var res = controller.Get();

            ////Assert           
            Assert.IsType<OkObjectResult>(res);
        }

        [Fact]
        public void Test_GetProductByID_Returns_NoException_NotNull()
        {
            // Arrange
            int id = 2;
            var mockRepo = new Mock<IProductService>();
            mockRepo
                .Setup(repo => repo.GetByIdAsync(id))
                .ReturnsAsync(() => new ProductDTO());

            var controller = new ProductController(mockRepo.Object);

            //Act
            var res = controller.Get(id);

            ////Assert  
            Assert.NotNull(res);
            try
            {
                Assert.ThrowsAsync<InvalidOperationException>(() => res);
            }
            catch (AssertActualExpectedException exception)
            {
                Assert.Equal("(No exception was thrown)", exception.Actual);
            }
        }

        [Fact]
        public void Test_PostProduct_Returns_NoException_NotNull()
        {
            // Arrange
            var mockObject = new ProductDTO()
            {
                Id = 1,
                Name = "jj",
                Url = "kkk",
                Code = "ll"

            };
            var mockRepo = new Mock<IProductService>();
            mockRepo
                .Setup(repo => repo.AddNewProduct(mockObject))
                .Returns(() => true);

            var controller = new ProductController(mockRepo.Object);

            //Act
            var res = controller.Post(mockObject);

            //Assert         
            try
            {
                Assert.Throws<InvalidOperationException>(() => res);
            }
            catch (AssertActualExpectedException exception)
            {
                Assert.Equal("(No exception was thrown)", exception.Actual);
            }

            Assert.NotNull(res);

        }

        [Fact]
        public void Test_PostProduct_handles_empty_result()
        {
            // Arrange
            var mockObject = new ProductDTO()
            {
                Id = 0,
                Name = "",
                Url = "",
                Code = ""
            };
            var mockRepo = new Mock<IProductService>();
            mockRepo
                .Setup(repo => repo.AddNewProduct(mockObject))
                .Returns(() => true);

            var controller = new ProductController(mockRepo.Object);

            //Act
            var res = controller.Post(mockObject);

            try
            {
                Assert.Throws<InvalidOperationException>(() => res);
            }
            catch (AssertActualExpectedException exception)
            {
                Assert.Equal("(No exception was thrown)", exception.Actual);
            }
        }

        [Fact]
        public void Test_PutProduct_Returns_NoException_NotNull()
        {
            // Arrange
            var mockObject = new ProductDTO()
            {
                Id = 1,
                Name = "jj",
                Url = "kkk",
                Code = "ll"

            };
            var mockRepo = new Mock<IProductService>();
            mockRepo
                .Setup(repo => repo.UpdateProduct(mockObject))
                .ReturnsAsync(() => true);

            var controller = new ProductController(mockRepo.Object);

            //Act
            var res = controller.Put(mockObject);

            //Assert         
            try
            {
                Assert.ThrowsAsync<InvalidOperationException>(() => res);
            }
            catch (AssertActualExpectedException exception)
            {
                Assert.Equal("(No exception was thrown)", exception.Actual);
            }

            Assert.NotNull(res);

        }

        [Fact]
        public void Test_DeleteProduct_Returns_NoException_NotNull()
        {
            // Arrange
            int id = 2;
            var mockRepo = new Mock<IProductService>();
            mockRepo
                .Setup(repo => repo.DeleteProduct(id))
                .Returns(() => true);

            var controller = new ProductController(mockRepo.Object);

            //Act
            var res = controller.Delete(id);

            //Assert         
            try
            {
                Assert.Throws<InvalidOperationException>(() => res);
            }
            catch (AssertActualExpectedException exception)
            {
                Assert.Equal("(No exception was thrown)", exception.Actual);
            }

            Assert.NotNull(res);

        }
    }
}

