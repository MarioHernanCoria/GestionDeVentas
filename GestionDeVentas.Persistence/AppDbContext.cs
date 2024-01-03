using GestionDeVentas.Domain.Entities;
using GestionDeVentas.Persistence.DataBaseSeeding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeVentas.Persistence
{
    public class AppDbContext :  DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Comercial> Comercios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var seeders = new List<IEntitySeeder>
            {
                new ClienteSeeder(),
                new ComercialSeeder(),
                new PedidoSeeder(),
            };
            foreach (var seeder in seeders)
            {
                seeder.SeedDataBase(modelBuilder);
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
