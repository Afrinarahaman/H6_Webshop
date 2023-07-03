using H5_Webshop.DTOs;
using H5_Webshop.DTOs.Entities;
using H5_Webshop.Repositories;
using H5_Webshop.Services;
using Moq;


namespace H5_WebshopUnitTests.Services
{
    public class CategoryServiceTests
    {
        private readonly CategoryService _categoryService;
        private readonly Mock<ICategoryRepository> _mockCategoryRepository = new();

        public CategoryServiceTests()
        {
            _categoryService = new CategoryService(_mockCategoryRepository.Object);
        }
        [Fact]
        public async void GetAllCategories_ShouldReturnListOfCategoryResponses_WhenCategoriesExists()
        {
            // Arrange
            List<Category> Categories = new();

            Categories.Add(new()
            {
                CategoryId = 1,
                CategoryName="Toy"
            });

            Categories.Add(new()
            {
                CategoryId = 2,
                CategoryName = "T-Shirt"
            });

            _mockCategoryRepository
                .Setup(x => x.SelectAllCategories())
                .ReturnsAsync(Categories);

            // Act
            var result = await _categoryService.GetAllCategories();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.IsType<List<CategoryResponse>>(result);
        }

        [Fact]
        public async void GetAllCategories_ShouldReturnEmptyListOfCategoryResponses_WhenNoCategoriesExists()
        {
            // Arrange
            List<Category> Categories = new();

            _mockCategoryRepository
                .Setup(x => x.SelectAllCategories())
                .ReturnsAsync(Categories);

            // Act
            var result = await _categoryService.GetAllCategories();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
            Assert.IsType<List<CategoryResponse>>(result);
        }

        [Fact]
        public async void GetCategoryById_ShouldReturnCategoryResponse_WhenCategoryExists()
        {
            // Arrange

            int categoryId = 1;

            Category category = new()
            {
                CategoryId = categoryId,
                CategoryName="Toy"
            };

            _mockCategoryRepository
                .Setup(x => x.SelectCategoryById(It.IsAny<int>()))
                .ReturnsAsync(category);

            // Act
            var result = await _categoryService.GetCategoryById(categoryId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CategoryResponse>(result);
            Assert.Equal(category.CategoryId, result.Id);
            Assert.Equal(category.CategoryName, result.CategoryName);
            
        }


        [Fact]
        public async void GetCategoryById_ShouldReturnNull_WhenCategoryDoesNotExist()
        {
            // Arrange
            int categoryId = 1;

            _mockCategoryRepository
                .Setup(x => x.SelectCategoryById(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            // Act
            var result = await _categoryService.GetCategoryById(categoryId);

            // Assert
            Assert.Null(result);
        }
        [Fact]
        public async void CreateCategory_ShouldReturnCategoryResponse_WhenCreateIsSuccess()
        {
            // Arrange
            CategoryRequest newCategory = new()
            {
                CategoryName="Toy"
            };

            int categoryId = 1;

            Category createdCategory = new()
            {
                CategoryId = categoryId,
                CategoryName="Toy"
            };

            _mockCategoryRepository
                .Setup(x => x.InsertNewCategory(It.IsAny<Category>()))
                .ReturnsAsync(createdCategory);

            // Act
            var result = await _categoryService.CreateCategory(newCategory);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CategoryResponse>(result);
            Assert.Equal(categoryId, result.Id);
            Assert.Equal(newCategory.CategoryName, result.CategoryName);
            
        }

        [Fact]
        public async void CreateCategory_ShouldReturnNull_WhenRepositoryReturnsNull()
        {
            // Arrange
            CategoryRequest newCategory = new()
            {
               CategoryName="Kids"
            };

            _mockCategoryRepository
                .Setup(x => x.InsertNewCategory(It.IsAny<Category>()))
                .ReturnsAsync(() => null);

            // Act
            var result = await _categoryService.CreateCategory(newCategory);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async void UpdateCategory_ShouldReturnCategoryResponse_WhenUpdateIsSuccess()
        {
            // NOTICE, we do not test if anything actually changed on the DB,
            // we only test that the returned values match the submitted values
            // Arrange
            CategoryRequest categoryRequest = new()
            {
                CategoryName="Kids"
            };

            int categoryId = 1;

            Category category = new()
            {
                CategoryId = categoryId,
                CategoryName="Kids"
            };

            _mockCategoryRepository
                .Setup(x => x.UpdateExistingCategory(It.IsAny<int>(), It.IsAny<Category>()))
                .ReturnsAsync(category);

            // Act
            var result = await _categoryService.UpdateCategory(categoryId, categoryRequest);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CategoryResponse>(result);
            Assert.Equal(categoryId, result.Id);
            Assert.Equal(categoryRequest.CategoryName, result.CategoryName);
           
        }


        [Fact]
        public async void UpdateCategory_ShouldReturnNull_WhenCategoryDoesNotExist()
        {
            // Arrange
            CategoryRequest categoryRequest = new()
            {
                CategoryName="Toy"
            };

            int categoryId = 1;

            _mockCategoryRepository
                .Setup(x => x.UpdateExistingCategory(It.IsAny<int>(), It.IsAny<Category>()))
                .ReturnsAsync(() => null);

            // Act
            var result = await _categoryService.UpdateCategory(categoryId, categoryRequest);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async void DeleteCategory_ShouldReturnCategoryResponse_WhenDeleteIsSuccess()
        {
            // Arrange
            int categoryId = 1;

            Category deletedCategory = new()
            {
                CategoryId = 1,
                CategoryName="Toy"
            };

            _mockCategoryRepository
                .Setup(x => x.DeleteCategoryById(It.IsAny<int>()))
                .ReturnsAsync(deletedCategory);

            // Act
            var result = await _categoryService.DeleteCategory(categoryId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CategoryResponse>(result);
            Assert.Equal(categoryId, result.Id);
        }

        [Fact]
        public async void DeleteCategory_ShouldReturnNull_WhenCategoryDoesNotExist()
        {
            // Arrange
            int categoryId = 1;

            _mockCategoryRepository
                .Setup(x => x.DeleteCategoryById(It.IsAny<int>()))
                .ReturnsAsync(() => null);

            // Act
            var result = await _categoryService.DeleteCategory(categoryId);

            // Assert
            Assert.Null(result);
        }
    }
}
