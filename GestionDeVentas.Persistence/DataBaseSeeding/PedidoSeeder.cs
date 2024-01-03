using GestionDeVentas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeVentas.Persistence.DataBaseSeeding
{
    public class PedidoSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>().HasData(
                new Pedido
                {
                    Id = 1,
                    Total = 150.5,
                    Fecha = new DateTime(2017 - 10 - 05),
                    IdCliente = 2,
                    IdComercial = 1
                },
                new Pedido
                {
                    Id = 2,
                    Total = 270.65,
                    Fecha = new DateTime(2016 - 09 - 10),
                    IdCliente = 1,
                    IdComercial = 2
                });
        }
    }
}
