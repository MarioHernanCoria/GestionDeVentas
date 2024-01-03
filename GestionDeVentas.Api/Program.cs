
using GestionDeVentas.Application.Interfaces.IRepositories;
using GestionDeVentas.Application.Interfaces.IUnitOfWork;
using GestionDeVentas.Persistence;
using GestionDeVentas.Persistence.Repositories;
using GestionDeVentas.Persistence.UnitOfWork;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;

namespace GestionDeVentas.Api
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

            //Conexion a la base de datos
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("name=DefaultConnection");
            });

            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddScoped<IUnitOfWork, UnitOfWorkService>();
            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
            builder.Services.AddScoped<IComercialRepository, ComercialRepository>();
            builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
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