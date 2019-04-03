using Product.Persistence.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Persistence.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Products> GetProducts();
        Task<Products> GetByIdAsync(int id);
        Task UpdateProduct(Products product);
        void InsertProduct(Products product);
        void DeleteProduct(int productId);
        void Save();
    }
}
