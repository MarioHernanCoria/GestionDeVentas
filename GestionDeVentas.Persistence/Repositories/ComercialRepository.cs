using GestionDeVentas.Application.Interfaces.IRepositories;
using GestionDeVentas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeVentas.Persistence.Repositories
{
    public class ComercialRepository : Repository<Comercial>, IComercialRepository
    {
        public ComercialRepository(AppDbContext context) : base(context) { }

    }
}
