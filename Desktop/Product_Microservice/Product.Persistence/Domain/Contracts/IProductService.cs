using Microsoft.AspNetCore.Mvc;
using Product.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Persistence.Domain.Contracts
{
    public interface IProductService
    {
        Task<ProductDTO> GetByIdAsync(int id);
        Task<bool> UpdateProduct(ProductDTO product);
        bool DeleteProduct(int productId);
        IEnumerable<ProductDTO> GetProductList();
        bool AddNewProduct(ProductDTO Product);
    }
}
