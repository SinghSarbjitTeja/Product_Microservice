using Product.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestProject1
{
    public class ListClasses
    {
        public static List<ProductDTO> GetMockList()
        {
            var products = new List<ProductDTO>();
            products.Add(new ProductDTO()
            {
                Id = 1,
                Name = "jj",
                Url = "kkk",
                Code = "ll"

            });
            products.Add(new ProductDTO()
            {
                Id = 1,
                Name = "jj",
                Url = "kkk",
                Code = "ll"

            });
            products.Add(new ProductDTO()
            {
                Id = 1,
                Name = "jj",
                Url = "kkk",
                Code = "ll"

            });
            return products;
        }

    
    }
}
