using Microsoft.EntityFrameworkCore;
using Product.Persistence.DBContexts;
using Product.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Persistence.Repository
{
    public class _productRepository : IProductRepository
    {
        private readonly ProductContext _dbContext;

        public _productRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteProduct(int productId)
        {
            var product = _dbContext.Products.Find(productId);
            _dbContext.Products.Remove(product);
            Save();
        }

        public Products GetProductByID(int productId)
        {
            return _dbContext.Products.Find(productId);
        }
        public async Task<Products> GetByIdAsync(int id)
        {
            try
            {
                var foundById = _dbContext.Products.Find(id);
                return foundById;
            }
            catch (Exception e)
            {
                await Task.Delay(1000);
                throw e;
            }

            throw new ApplicationException("Hit retry limit while trying to query MongoDB");
        }

        public async Task UpdateProduct(Products product)
        {
            try
            {
                var k = _dbContext.Products.Find(product.Id);
                if (k != null)
                {

                    k.Name = product.Name;
                    k.Url = product.Url;
                    k.Code = product.Code;
                }
                //       _dbContext.Entry(product).State = EntityState.Modified;
                Save();
            }
            catch (Exception e)
            {
                await Task.Delay(1000);
                throw e;
            }
        }

        public IEnumerable<Products> GetProducts()
        {
            return _dbContext.Products.ToList();
        }

        public void InsertProduct(Products product)
        {
            _dbContext.Add(product);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }


    }
}
