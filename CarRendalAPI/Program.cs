
using CarRendalAPI.Database;
using CarRendalAPI.IRepositories;
using CarRendalAPI.IServices;
using CarRendalAPI.Repositories;
using CarRendalAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarRendalAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("appDbConnection")));

            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddScoped<ICarService, CarService>();

            builder.Services.AddScoped<IBrandRepository, BrandRepository>();
            builder.Services.AddScoped<IBrandService, BrandService>();
            
            builder.Services.AddScoped<IModelRepository, ModelRepository>();
            builder.Services.AddScoped<IModelService, ModelService>();

            //builder.Services.AddScoped<IUserRepository, UserRepository>();
            //builder.Services.AddScoped<IUserService, UserService>();

            ////builder.Services.AddScoped<IRentalRepository, RentalRepository>();
            //builder.Services.AddScoped<IRentalService, RentalService>();

            //builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
            //builder.Services.AddScoped<IPaymentService, PaymentService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
