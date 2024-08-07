using Asp.Versioning;
using LandonApi.Filters;
using LandonApi.Models;
using LandonApi.Repository;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace LandonApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<HotelApiDbContext>(
                options => options.UseInMemoryDatabase("landenDb"));

            builder.Services.AddControllers();
            builder.Services.AddRouting(options => options.LowercaseUrls = true);

            //adding 
            builder.Services.AddMvcCore(options => 
                options.Filters.Add<JsonExceptionFilter>()
                
                );

           

            // adding versioning
            builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = false;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new HeaderApiVersionReader("X-Api-Version"),
                    new QueryStringApiVersionReader("api-version"));
                
                
            });

            builder.Services.Configure<HoteInfomation>(
                options => {
                    options.Title = "Title";
                    options.Email = "email";
                    options.Location = new Address() { City = "Pune" };
                    });

            // adding CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowMyApp",
                    policy => policy.WithOrigins("https://example.com"));

            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();
            
            app.UseAuthorization();


            app.MapControllers();

            app.UseCors("AllowMyApp");

            app.Run();
        }
    }
}
