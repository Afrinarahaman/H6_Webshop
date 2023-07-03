using H5_Webshop.Database;
using H5_Webshop.DTOs.Entities;
using Microsoft.EntityFrameworkCore;

namespace H5_Webshop.Repositories
{

  
        public interface IProductRepository
        {
            Task<List<Product>> SelectAllProducts();
            Task<Product> SelectProductById(int product_Id);

            Task<List<Product>> GetProductsByCategoryId(int category_Id);
            Task<Product> InsertNewProduct(Product product);
            Task<Product> UpdateExistingProduct(int product_Id, Product product);

            Task<Product> DeleteProductById(int product_Id);

    }
        public class ProductRepository : IProductRepository
        {
            private readonly WebshopApiContext _context;

            public ProductRepository(WebshopApiContext context)
            {
                _context = context;
            }



            public async Task<List<Product>> SelectAllProducts()
            {
                return await _context.Product
                    .Include(a => a.Category)
                    .OrderBy(a => a.CategoryId)

                    .ToListAsync();
            }

            public async Task<Product> SelectProductById(int product_Id)
            {
                return await _context.Product
                    .Include(a => a.Category)
                    .OrderBy(a => a.CategoryId)
                    .FirstOrDefaultAsync(product => product.ProductId == product_Id);
            }
            public async Task<List<Product>> GetProductsByCategoryId(int Category_Id)
            {

                return await _context.Product
                    .Include(a => a.Category)
                    .OrderBy(a => a.CategoryId)
                    .Where(a => a.CategoryId==Category_Id)
                    .ToListAsync();
            }
        public async Task<Product> InsertNewProduct(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<Product> UpdateExistingProduct(int product_Id, Product product)
        {
            Product updateProduct = await _context.Product.FirstOrDefaultAsync(product => product.ProductId == product_Id);

            if (updateProduct != null)
            {
                updateProduct.Title = product.Title;
                updateProduct.Price = product.Price;
                updateProduct.Description = product.Description;
                updateProduct.Image = product.Image;
                updateProduct.Stock = product.Stock;

                await _context.SaveChangesAsync();

            }

            return updateProduct;
        }

        public async Task<Product> DeleteProductById(int product_Id)
        {
            Product deleteProduct = await _context.Product.FirstOrDefaultAsync(product => product.ProductId == product_Id);

            if (deleteProduct != null)
            {
                _context.Product.Remove(deleteProduct);
                await _context.SaveChangesAsync();
            }
            return deleteProduct;
        }

    }
    
}
