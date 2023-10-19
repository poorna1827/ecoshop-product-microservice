using ProductMicroservice.Dto;
using ProductMicroservice.Models;

namespace tests.MockData
{
    internal class ProductMockData
    {

        public static List<Product> GetSampleProductItems()
        {

            return new List<Product>
            {

                new Product
                {
                    PId = new Guid("10188938-5308-4B19-8E97-57E7F36A6184"),
                    Name = "sample name 1",
                    Brand = "sample brand 1",
                    Category = "sample category 1",
                    Price = 100,
                    Description = "sample description 1",
                    Image = "sample image link 1"
                },

                new Product
                {
                    PId = new Guid("10288938-5308-4B19-8E97-57E7F36A6184"),
                    Name = "sample name 2",
                    Brand = "sample brand 2",
                    Category = "sample category 2",
                    Price = 200,
                    Description = "sample description 2",
                    Image = "sample image link 2"
                },

                new Product
                {
                    PId = new Guid("10388938-5308-4B19-8E97-57E7F36A6184"),
                    Name = "sample name 3",
                    Brand = "sample brand 3",
                    Category = "sample category 3",
                    Price = 300,
                    Description = "sample description 3",
                    Image = "sample image link 3"
                },
            };

        }
        public ProductIdList GetSampleProductIds()
        {

            return new ProductIdList()
            {
              array = new List<Guid>()
               {
                   new Guid("10188938-5308-4B19-8E97-57E7F36A6184"),
                   new Guid("10288938-5308-4B19-8E97-57E7F36A6184")
               }
            };

        }


    }
}
