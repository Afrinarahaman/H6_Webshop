using H5_Webshop.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System.Net;

namespace H5_WebshopIntegrationTests
{
    public class CategoryApiIntegrationTests:IDisposable
    {

        private readonly Mock<ICategoryService> _mockCategoryService = new();
        private CustomWebApplicationFactory _factory;
            private HttpClient _client;
        private bool disposedValue;

        public CategoryApiIntegrationTests()
        {
            _factory = new CustomWebApplicationFactory();
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task GetAll_ShouldReturnStatusCode200_WhenCategoriesExist()
        {
            //Arrange


            var response = await _client.GetAsync("api/category");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        public void Dispose()
        {
            _factory.Dispose();
            _client.Dispose();
        }
    }
}