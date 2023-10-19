using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Controllers;
using ProductMicroservice.DbContexts;
using ProductMicroservice.Dto;
using tests.MockData;
using Xunit;

namespace tests.Systems.Controllers
{
    public  class TestProductDetailsController : IDisposable
    {

        private readonly ProductDbContext _context;
        public TestProductDetailsController()
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
        public async Task GetAllItemsAsync_ShouldReturn200Status()
        {

            //Arrange 

            //database mock
            _context.Products.AddRange(ProductMockData.GetSampleProductItems());
            _context.SaveChanges();

            var sut = new ProductDetailsController(_context);


            //Act 

            var result = await sut.GetAllItems();

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));


        }

        [Fact]
        public async Task GetFiltersAsync_ShouldReturn200Status()
        {

            //Arrange 

            //database mock
            _context.Products.AddRange(ProductMockData.GetSampleProductItems());
            _context.SaveChanges();

            var sut = new ProductDetailsController(_context);


            //Act 

            var result = await sut.GetFilters();

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));


        }

        [Fact]
        public async Task GetItemsForCartAsync_ShouldReturn200Status()
        {

            //Arrange 

            //database mock
            _context.Products.AddRange(ProductMockData.GetSampleProductItems());
            _context.SaveChanges();

            var sut = new ProductDetailsController(_context);


            //Act 

            ProductIdList data = new ProductIdList()
            {
                array = new List<Guid>()
                {
                    new Guid("10188938-5308-4B19-8E97-57E7F36A6184"),
                    new Guid("10288938-5308-4B19-8E97-57E7F36A6184")
                }
            };


            var result = await sut.GetItemsForCart(data);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));


        }

        [Fact]
        public async Task GetItemsForCartAsync_ShouldReturn404Status()
        {

            //Arrange 

            //database mock
            _context.Products.AddRange(ProductMockData.GetSampleProductItems());
            _context.SaveChanges();

            var sut = new ProductDetailsController(_context);


            //Act 

            ProductIdList data = new ProductIdList()
            {
                array = new List<Guid>()
                {
                    new Guid("20188938-5308-4B19-8E97-57E7F36A6184"),
                    new Guid("10288938-5308-4B19-8E97-57E7F36A6184")
                }
            };


            var result = await sut.GetItemsForCart(data);

            //Assert
            result.GetType().Should().Be(typeof(NotFoundResult));


        }



        [Fact]
        public async Task GetItemAsync_ShouldReturn200Status()
        {

            //Arrange 

            //database mock
            _context.Products.AddRange(ProductMockData.GetSampleProductItems());
            _context.SaveChanges();

            var sut = new ProductDetailsController(_context);


            //Act 

            var result = await sut.GetItem(new Guid("10188938-5308-4B19-8E97-57E7F36A6184"));

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));


        }





    }
}
