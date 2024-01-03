using GestionDeVentas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeVentas.Persistence.DataBaseSeeding
{
    public class ClienteSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasData(
                new 
                {
                    Id = 1,
                    Nombre = "Aarón",
                    Apellido1 = "Rivero",
                    Apellido2 = "Gómez",
                    Ciudad = "Almería",
                    Categoría = 100
                },
                new
                {
                    Id = 2,
                    Nombre = "Adela",
                    Apellido1 = "Salas",
                    Apellido2 = "Díaz",
                    Ciudad = "Granada",
                    Categoría = 200
                });
        }
    }
}
