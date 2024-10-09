using CQRSDemo.Database;
using CQRSDemo.Interfaces;
using CQRSDemo.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CQRSDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StudentServiceContext>(config => {
                config.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddMediatR(cfg => 
                cfg.RegisterServicesFromAssembly(System.Reflection.Assembly.GetExecutingAssembly()));

            builder.Services.AddTransient<IStudentRepository, StudentRepository>();
            
            
            builder.Services.AddControllers();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
