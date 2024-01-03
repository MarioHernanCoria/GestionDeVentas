using GestionDeVentas.Application.Interfaces.IRepositories;
using GestionDeVentas.Application.Interfaces.IUnitOfWork;
using GestionDeVentas.Persistence.Repositories;

namespace GestionDeVentas.Persistence.UnitOfWork
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public ClienteRepository ClienteRepository { get; }
        public ComercialRepository ComercialRepository { get; }
        public PedidoRepository PedidoRepository { get; }

        public UnitOfWorkService(AppDbContext context)
        {
            _context = context;

            ClienteRepository = new ClienteRepository(_context);
            ComercialRepository = new ComercialRepository(_context);
            PedidoRepository = new PedidoRepository(_context);
        }

        public Task<int> Complete()
        {
            return _context.SaveChangesAsync();
        }
    }
}
