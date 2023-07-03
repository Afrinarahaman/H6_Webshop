using H5_Webshop.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;

namespace H5_WebshopIntegrationTests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        public Mock<ICategoryRepository> CategoryRepositoryMock { get; }
        public CustomWebApplicationFactory()
        {
            CategoryRepositoryMock = new Mock<ICategoryRepository>();
        }
        protected  void ConfigureWebhost(IWebHostBuilder builder)
        { 
            base.ConfigureWebHost(builder);
            builder.ConfigureTestServices(services =>
            {
                services.AddSingleton(CategoryRepositoryMock.Object);
            });
        }
    
    
    }
}