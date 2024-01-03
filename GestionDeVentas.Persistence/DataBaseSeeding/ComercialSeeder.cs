using GestionDeVentas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeVentas.Persistence.DataBaseSeeding
{
    public class ComercialSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comercial>().HasData(
                new 
                {
                    Id = 1,
                    Nombre = "Daniel",
                    Apellido1 = "Sáez",
                    Apellido2 = "Vega",
                    Comisión = 0.15f
                },
                new 
                {
                    Id = 2,
                    Nombre = "Juan",
                    Apellido1 = "Gómez",
                    Apellido2 = "López",
                    Comisión = 0.13f
                });
        }
    }
}
