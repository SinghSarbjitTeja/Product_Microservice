using Product.Persistence.Domain.Contracts;
using Product.Persistence.Models;
using Product.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Product.Persistence.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductDTO> GetProductList()
        {
            var listOfProducts = _productRepository.GetProducts();
            var list = listOfProducts.Select(x => new ProductDTO
            {
                Id = x.Id,
                Name = x.Name,
                Url = x.Url,
                Code = x.Code
            }).ToList();

            return list;
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            var result = new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Url = product.Url,
                Code = product.Code
            };
            return result;
        }

        public bool AddNewProduct(ProductDTO Product)
        {

            try
            {
                var newProduct = new Products
                {
                    Name = Product.Name,
                    Url = Product.Url,
                    Code = Product.Code,
                };

                using (var scope = new TransactionScope())
                {
                    _productRepository.InsertProduct(newProduct);
                    scope.Complete();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        //Task<bool> UpdateProduct(ProductDTO product);
        public async Task<bool> UpdateProduct(ProductDTO product)
        {
            try
            {
                var newProduct = new Products
                {
                    Id = product.Id,
                    Name = product.Name,
                    Url = product.Url,
                    Code = product.Code,
                };
                await _productRepository.UpdateProduct(newProduct);
                return true;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool DeleteProduct(int productId)
        {
            _productRepository.DeleteProduct(productId);
            return true;
        }
    }
}
