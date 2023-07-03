using H5_Webshop.Authorization;
using H5_Webshop.Database;
using H5_Webshop.Repositories;
using H5_Webshop.Services;
using Microsoft.EntityFrameworkCore;


public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddTransient<IProductService, ProductService>();
        builder.Services.AddTransient<IProductRepository, ProductRepository>();

        builder.Services.AddTransient<ICategoryService, CategoryService>();
        builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

        builder.Services.AddTransient<IUserRepository, UserRepository>();
        builder.Services.AddTransient<IUserService, UserService>();

        // Add services to the container.
        builder.Services.AddDbContext<WebshopApiContext>(
                        o => o.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
        builder.Services.AddScoped<IJwtUtils, JwtUtils>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        var app = builder.Build();
        app.UseHttpsRedirection();

        app.UseCors(policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        //JWT middleware setup, use as replacement for  default Authorization
        app.UseMiddleware<JwtMiddleware>();
        app.MapControllers();

        app.Run();
    }
}