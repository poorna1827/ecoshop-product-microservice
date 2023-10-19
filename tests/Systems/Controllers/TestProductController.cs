using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using ProductMicroservice.Controllers;
using ProductMicroservice.DbContexts;
using ProductMicroservice.Dto;
using ProductMicroservice.Services;

using System.Net;
using tests.MockData;
using Xunit;

namespace tests.Systems.Controllers
{
    public class TestProductController : IDisposable
    {

        private readonly ProductDbContext _context;
        public TestProductController()
        {
            var options = new DbContextOptionsBuilder<ProductDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            _context = new ProductDbContext(options);

            _context.Database.EnsureCreated();

        }
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();

        }

        [Fact]
        public async Task RegisterProductAsync_ShouldReturn200Status()
        {
            //Arrange


            //Identity microservice call mock 
            var ApiServiceMock = new Mock<IApiService>();
            ApiServiceMock.Setup(x => x.isAuthorized(It.IsAny<string>())).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

            //database mock
            _context.Products.AddRange(ProductMockData.GetSampleProductItems());
            _context.SaveChanges();


            //request header token mock
            var mockRequest = new Mock<HttpRequest>();
            mockRequest.Setup(x => x.Headers["Authorization"]).Returns("Bearer test_token");
            var mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(x => x.Request).Returns(mockRequest.Object);


            var sut = new ProductController(_context, ApiServiceMock.Object);

            sut.ControllerContext = new ControllerContext()
            {
                HttpContext = mockHttpContext.Object
            };



            //Act
            ProductDto data = new ProductDto()
            {
                Name = "test name",
                Image = "test url",
                Category = "test category",
                Brand = "test brand",
                Description = "test description",
                Price = 200

            };

            var result = await sut.RegisterProduct(data);



            //Assert
            result.GetType().Should().Be(typeof(OkResult));
        }

        [Fact]
        public async Task RegisterProductAsync_ShouldReturn409Status()
        {
            //Arrange


            //Identity microservice call mock 
            var ApiServiceMock = new Mock<IApiService>();
            ApiServiceMock.Setup(x => x.isAuthorized(It.IsAny<string>())).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

            //database mock
            _context.Products.AddRange(ProductMockData.GetSampleProductItems());
            _context.SaveChanges();


            //request header token mock
            var mockRequest = new Mock<HttpRequest>();
            mockRequest.Setup(x => x.Headers["Authorization"]).Returns("Bearer test_token");
            var mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(x => x.Request).Returns(mockRequest.Object);


            var sut = new ProductController(_context, ApiServiceMock.Object);

            sut.ControllerContext = new ControllerContext()
            {
                HttpContext = mockHttpContext.Object
            };



            //Act
            ProductDto data = new ProductDto()
            {
                Name = "sample name 1",
                Image = "test url",
                Category = "test category",
                Brand = "test brand",
                Description = "test description",
                Price = 200

            };

            var result = await sut.RegisterProduct(data);



            //Assert
            result.GetType().Should().Be(typeof(ConflictResult));
        }


        [Fact]
        public async Task RegisterProductAsync_ShouldReturn401Status()
        {
            //Arrange


            //Identity microservice call mock 
            var ApiServiceMock = new Mock<IApiService>();
            ApiServiceMock.Setup(x => x.isAuthorized(It.IsAny<string>())).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.Unauthorized));

            //database mock
            _context.Products.AddRange(ProductMockData.GetSampleProductItems());
            _context.SaveChanges();


            //request header token mock
            var mockRequest = new Mock<HttpRequest>();
            mockRequest.Setup(x => x.Headers["Authorization"]).Returns("Bearer test_token");
            var mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(x => x.Request).Returns(mockRequest.Object);


            var sut = new ProductController(_context, ApiServiceMock.Object);

            sut.ControllerContext = new ControllerContext()
            {
                HttpContext = mockHttpContext.Object
            };



            //Act
            ProductDto data = new ProductDto()
            {
                Name = "test name",
                Image = "test url",
                Category = "test category",
                Brand = "test brand",
                Description = "test description",
                Price = 200

            };

            var result = await sut.RegisterProduct(data);



            //Assert
            result.GetType().Should().Be(typeof(UnauthorizedResult));
        }


        [Fact]
        public async Task UpdateProductAsync_ShouldReturn200Status()
        {
            //Arrange


            //Identity microservice call mock 
            var ApiServiceMock = new Mock<IApiService>();
            ApiServiceMock.Setup(x => x.isAuthorized(It.IsAny<string>())).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

            //database mock
            _context.Products.AddRange(ProductMockData.GetSampleProductItems());
            _context.SaveChanges();


            //request header token mock
            var mockRequest = new Mock<HttpRequest>();
            mockRequest.Setup(x => x.Headers["Authorization"]).Returns("Bearer test_token");
            var mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(x => x.Request).Returns(mockRequest.Object);


            var sut = new ProductController(_context, ApiServiceMock.Object);

            sut.ControllerContext = new ControllerContext()
            {
                HttpContext = mockHttpContext.Object
            };



            //Act
            ProductDto data = new ProductDto()
            {
                Name = "updated test name",
                Image = "updated test url",
                Category = "updated test category",
                Brand = "updated test brand",
                Description = "updated test description",
                Price = 200

            };

            var result = await sut.UpdateProduct(new Guid("10188938-5308-4B19-8E97-57E7F36A6184"),data);



            //Assert
            result.GetType().Should().Be(typeof(OkResult));
        }

        [Fact]
        public async Task UpdateProductAsync_ShouldReturn404Status()
        {
            //Arrange


            //Identity microservice call mock 
            var ApiServiceMock = new Mock<IApiService>();
            ApiServiceMock.Setup(x => x.isAuthorized(It.IsAny<string>())).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

            //database mock
            _context.Products.AddRange(ProductMockData.GetSampleProductItems());
            _context.SaveChanges();


            //request header token mock
            var mockRequest = new Mock<HttpRequest>();
            mockRequest.Setup(x => x.Headers["Authorization"]).Returns("Bearer test_token");
            var mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(x => x.Request).Returns(mockRequest.Object);


            var sut = new ProductController(_context, ApiServiceMock.Object);

            sut.ControllerContext = new ControllerContext()
            {
                HttpContext = mockHttpContext.Object
            };



            //Act
            ProductDto data = new ProductDto()
            {
                Name = "updated test name",
                Image = "updated test url",
                Category = "updated test category",
                Brand = "updated test brand",
                Description = "updated test description",
                Price = 200

            };

            var result = await sut.UpdateProduct(new Guid("90088938-5308-4B19-8E97-57E7F36A6184"), data);



            //Assert
            result.GetType().Should().Be(typeof(NotFoundResult));
        }


        [Fact]
        public async Task UpdateProductAsync_ShouldReturn401Status()
        {
            //Arrange


            //Identity microservice call mock 
            var ApiServiceMock = new Mock<IApiService>();
            ApiServiceMock.Setup(x => x.isAuthorized(It.IsAny<string>())).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.Unauthorized));

            //database mock
            _context.Products.AddRange(ProductMockData.GetSampleProductItems());
            _context.SaveChanges();


            //request header token mock
            var mockRequest = new Mock<HttpRequest>();
            mockRequest.Setup(x => x.Headers["Authorization"]).Returns("Bearer test_token");
            var mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(x => x.Request).Returns(mockRequest.Object);


            var sut = new ProductController(_context, ApiServiceMock.Object);

            sut.ControllerContext = new ControllerContext()
            {
                HttpContext = mockHttpContext.Object
            };



            //Act
            ProductDto data = new ProductDto()
            {
                Name = "updated test name",
                Image = "updated test url",
                Category = "updated test category",
                Brand = "updated test brand",
                Description = "updated test description",
                Price = 200

            };

            var result = await sut.UpdateProduct(new Guid("10188938-5308-4B19-8E97-57E7F36A6184"), data);



            //Assert
            result.GetType().Should().Be(typeof(UnauthorizedResult));
        }


        [Fact]
        public async Task DeleteProductAsync_ShouldReturn200Status()
        {
            //Arrange


            //Identity microservice call mock 
            var ApiServiceMock = new Mock<IApiService>();
            ApiServiceMock.Setup(x => x.isAuthorized(It.IsAny<string>())).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

            //database mock
            _context.Products.AddRange(ProductMockData.GetSampleProductItems());
            _context.SaveChanges();


            //request header token mock
            var mockRequest = new Mock<HttpRequest>();
            mockRequest.Setup(x => x.Headers["Authorization"]).Returns("Bearer test_token");
            var mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(x => x.Request).Returns(mockRequest.Object);


            var sut = new ProductController(_context, ApiServiceMock.Object);

            sut.ControllerContext = new ControllerContext()
            {
                HttpContext = mockHttpContext.Object
            };



            //Act


            var result = await sut.DeleteProduct(new Guid("10188938-5308-4B19-8E97-57E7F36A6184"));



            //Assert
            result.GetType().Should().Be(typeof(OkResult));
        }

        [Fact]
        public async Task DeleteProductAsync_ShouldReturn404Status()
        {
            //Arrange


            //Identity microservice call mock 
            var ApiServiceMock = new Mock<IApiService>();
            ApiServiceMock.Setup(x => x.isAuthorized(It.IsAny<string>())).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

            //database mock
            _context.Products.AddRange(ProductMockData.GetSampleProductItems());
            _context.SaveChanges();


            //request header token mock
            var mockRequest = new Mock<HttpRequest>();
            mockRequest.Setup(x => x.Headers["Authorization"]).Returns("Bearer test_token");
            var mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(x => x.Request).Returns(mockRequest.Object);


            var sut = new ProductController(_context, ApiServiceMock.Object);

            sut.ControllerContext = new ControllerContext()
            {
                HttpContext = mockHttpContext.Object
            };



            //Act


            var result = await sut.DeleteProduct(new Guid("90088938-5308-4B19-8E97-57E7F36A6184"));



            //Assert
            result.GetType().Should().Be(typeof(NotFoundResult));
        }


        [Fact]
        public async Task DeleteProductAsync_ShouldReturn401Status()
        {
            //Arrange


            //Identity microservice call mock 
            var ApiServiceMock = new Mock<IApiService>();
            ApiServiceMock.Setup(x => x.isAuthorized(It.IsAny<string>())).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.Unauthorized));

            //database mock
            _context.Products.AddRange(ProductMockData.GetSampleProductItems());
            _context.SaveChanges();


            //request header token mock
            var mockRequest = new Mock<HttpRequest>();
            mockRequest.Setup(x => x.Headers["Authorization"]).Returns("Bearer test_token");
            var mockHttpContext = new Mock<HttpContext>();
            mockHttpContext.Setup(x => x.Request).Returns(mockRequest.Object);


            var sut = new ProductController(_context, ApiServiceMock.Object);

            sut.ControllerContext = new ControllerContext()
            {
                HttpContext = mockHttpContext.Object
            };



            //Act


            var result = await sut.DeleteProduct(new Guid("10188938-5308-4B19-8E97-57E7F36A6184"));



            //Assert
            result.GetType().Should().Be(typeof(UnauthorizedResult));
        }








    }
}
