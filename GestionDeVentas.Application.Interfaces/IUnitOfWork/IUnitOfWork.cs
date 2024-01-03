using GestionDeVentas.Persistence.Repositories;

namespace GestionDeVentas.Application.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork
    {
        public ClienteRepository ClienteRepository { get; }
        public ComercialRepository ComercialRepository { get; }
        public PedidoRepository PedidoRepository { get; }

        Task<int> Complete();
    }
}
