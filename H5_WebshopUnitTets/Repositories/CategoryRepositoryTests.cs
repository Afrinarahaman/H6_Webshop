using H5_Webshop.Database;
using H5_Webshop.DTOs.Entities;
using H5_Webshop.Repositories;
using Microsoft.EntityFrameworkCore;

namespace H5_WebshopUnitTets.Repositories
{
    public class CategoryRepositoryTests
    {
            private readonly DbContextOptions<WebshopApiContext> _options;
            private readonly WebshopApiContext _context;
            private readonly CategoryRepository _categoryRepository;
            public CategoryRepositoryTests()
            {
                _options = new DbContextOptionsBuilder<WebshopApiContext>()
                    .UseInMemoryDatabase(databaseName: "Webshop")
                    .Options;

                _context = new(_options);
                _categoryRepository = new(_context);
            }
            [Fact]
            public async void SelectAllCategories_ShouldReturnListOfCategories_WhenCategoryExists()
            {
                //Arrange 
                await _context.Database.EnsureDeletedAsync();
                _context.Category.Add(new()
                {
                    CategoryId = 1,
                    CategoryName = "Kids"

                });
                _context.Category.Add(new()
                {

                    CategoryId = 2,
                    CategoryName = "Men"



                });

                await _context.SaveChangesAsync();

                //Act
                var result = await _categoryRepository.SelectAllCategories();

                //Assert
                Assert.NotNull(result);
                Assert.IsType<List<Category>>(result);
                Assert.Equal(2, result.Count);
                // Assert.Empty(result);
            }
            [Fact]
            public async void SelectAllCategories_ShouldReturnEmptyListOfCategories_WhenCategoryExists()
            {
                //Arrange 
                await _context.Database.EnsureDeletedAsync();




                //Act
                var result = await _categoryRepository.SelectAllCategories();

                //Assert
                Assert.NotNull(result);
                Assert.IsType<List<Category>>(result);

                Assert.Empty(result);
            }
            [Fact]
            public async void SelectCategoryById_ShouldReturnCategory_WhenCategoryExists()
            {
                //Arrange 
                await _context.Database.EnsureDeletedAsync();
                int category_Id = 1;
                _context.Category.Add(new()
                {
                    CategoryId = 1,
                    CategoryName = "Toy"


                });


                await _context.SaveChangesAsync();

                //Act
                var result = await _categoryRepository.SelectCategoryById(category_Id);

                //Assert
                Assert.NotNull(result);
                Assert.IsType<Category>(result);
                Assert.Equal(category_Id, result.CategoryId);
                // Assert.Empty(result);
            }
            [Fact]
            public async void SelectCategoryById_ShouldReturnNull_WhenCategoryDoesNotExist()
            {
                //Arrange 
                await _context.Database.EnsureDeletedAsync();




                //Act
                var result = await _categoryRepository.SelectCategoryById(1);

                //Assert


                Assert.Null(result);
            }
            [Fact]
            public async void InsertNewCategory_ShouldAddnewIdToCategory_WhenSavingToDatabase()
            {
                //Arrange 
                await _context.Database.EnsureDeletedAsync();

                int expectedNewId = 1;

                Category category = new()
                {
                    CategoryId = 1,
                    CategoryName = "Kids"


                };


                await _context.SaveChangesAsync();

                //Act
                var result = await _categoryRepository.InsertNewCategory(category);

                //Assert
                Assert.NotNull(result);
                Assert.IsType<Category>(result);
                Assert.Equal(expectedNewId, result.CategoryId);

            }

            [Fact]
            public async void InsertNewCategory_ShouldFailToAddNewCategory_WhenCategoryIdAlreadyExists()
            {
                //Arrange 
                await _context.Database.EnsureDeletedAsync();



                Category category = new()
                {
                    CategoryId = 1,
                    CategoryName = "Kids"

                };

                _context.Category.Add(category);
                await _context.SaveChangesAsync();

                //Act
                async Task action() => await _categoryRepository.InsertNewCategory(category);


                //Assert
                var ex = await Assert.ThrowsAsync<ArgumentException>(action);
                Assert.Contains("An item with the same key has already been added", ex.Message);

            }
            [Fact]
            public async void UpdateExistingCategory_ShouldChangeValuesOnCategory_WhenCategoryExists()
            {
                //Arrange 
                await _context.Database.EnsureDeletedAsync();
                int category_Id = 1;
                Category newCategory = new()
                {
                    CategoryId = category_Id,
                    CategoryName="Kids"

                };

                _context.Category.Add(newCategory);
                await _context.SaveChangesAsync();

                Category updateCategory = new()
                {
                    CategoryId = category_Id,
                    CategoryName = "updated Kids"

                };



                //Act
                var result = await _categoryRepository.UpdateExistingCategory(category_Id, updateCategory);

                //Assert
                Assert.NotNull(result);
                Assert.IsType<Category>(result);
                Assert.Equal(category_Id, result.CategoryId);
                Assert.Equal(updateCategory.CategoryName, result.CategoryName);

            }

            [Fact]
            public async void UpdateExistingCategory_ShouldReturnNull_WhenCategoryDoesNotExist()
            {
                //Arrange 
                await _context.Database.EnsureDeletedAsync();
                int category_Id = 1;


                Category updateCategory = new()
                {
                    CategoryId = category_Id,
                    CategoryName = "Kids"

                };



                //Act
                var result = await _categoryRepository.UpdateExistingCategory(category_Id, updateCategory);

                //Assert
                Assert.Null(result);

            }
            [Fact]
            public async void DeleteCategoryById_ShouldReturnDeleteCategory_WhenCategoryIsDeleted()
            {
                //Arrange 
                await _context.Database.EnsureDeletedAsync();
                int category_Id = 1;
                Category newCategory = new()
                {
                    CategoryId = category_Id,
                    CategoryName = "Kids"

                };

                _context.Category.Add(newCategory);
                await _context.SaveChangesAsync();




                //Act
                var result = await _categoryRepository.DeleteCategoryById(category_Id);
                var category = await _categoryRepository.SelectCategoryById(category_Id);

                //Assert
                Assert.NotNull(result);
                Assert.IsType<Category>(result);
                Assert.Equal(category_Id, result.CategoryId);
                Assert.Null(category);
            }
            [Fact]
            public async void DeleteCategoryById_ShouldReturnNull_WhenCategoryDoesNotExist()
            {
                //Arrange 
                await _context.Database.EnsureDeletedAsync();



                _context.Add(new Category { CategoryId = 1, CategoryName = "Kids" });
                //Act
                var result = await _categoryRepository.DeleteCategoryById(1);


                //Assert

                Assert.Null(result);
            }


        
    }

}
