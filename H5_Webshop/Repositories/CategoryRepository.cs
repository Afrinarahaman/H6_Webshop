using H5_Webshop.Database;
using H5_Webshop.DTOs.Entities;
using Microsoft.EntityFrameworkCore;

namespace H5_Webshop.Repositories
{
   
    
        public interface ICategoryRepository
        {
            Task<List<Category>> SelectAllCategories();
            Task<Category> SelectCategoryById(int category_Id);
            Task<List<Category>> SelectAllCategoriesWithoutProducts();
            // Task<List<Category>> SelectCategoriesByProductId(int productId);
            Task<Category> InsertNewCategory(Category category);
            Task<Category> UpdateExistingCategory(int category_Id, Category category);
            Task<Category> DeleteCategoryById(int category_Id);

        }
        public class CategoryRepository: ICategoryRepository
        {
            private readonly WebshopApiContext _context;

            public CategoryRepository(WebshopApiContext context)
            {
                _context = context;
            }
            public async Task<List<Category>> SelectAllCategories()
            {
                return await _context.Category
                    .Include(b => b.Products)

                    .ToListAsync();
            }
            public async Task<Category> SelectCategoryById(int category_Id)
            {
                return await _context.Category
                    .Include(a => a.Products)
                    .FirstOrDefaultAsync(category => category.CategoryId == category_Id);
            }

            public async Task<List<Category>> SelectAllCategoriesWithoutProducts()
            {
                return await _context.Category
                            .ToListAsync();
            }

            public async Task<Category> InsertNewCategory(Category category)
            {
                _context.Category.Add(category);
                await _context.SaveChangesAsync();
                return category;
            }
            public async Task<Category> UpdateExistingCategory(int category_Id, Category category)
            {
                Category updateCategory = await _context.Category.FirstOrDefaultAsync(category => category.CategoryId == category_Id);
                if (updateCategory != null)
                {
                    updateCategory.CategoryName = category.CategoryName;

                    await _context.SaveChangesAsync();
                }
                return updateCategory;
            }
            public async Task<Category> DeleteCategoryById(int category_Id)
            {
                Category deleteCategory = await _context.Category.FirstOrDefaultAsync(category => category.CategoryId == category_Id);
                if (deleteCategory != null)
                {

                    _context.Remove(deleteCategory);
                    await _context.SaveChangesAsync();
                }
                return deleteCategory;
            }


        }
    
}
