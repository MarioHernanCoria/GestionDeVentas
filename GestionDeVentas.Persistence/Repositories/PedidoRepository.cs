using GestionDeVentas.Application.Interfaces.IRepositories;
using GestionDeVentas.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace GestionDeVentas.Persistence.Repositories
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(AppDbContext context) : base(context) { }

        public override async Task<bool> Update(Pedido updatePedido)
        {
            var pedido = await _context.Pedidos.FirstOrDefaultAsync(x => x.Id == updatePedido.Id);
            if (pedido == null) { return false; }

            pedido.Total = updatePedido.Total;
            pedido.Fecha = updatePedido.Fecha;
            pedido.IdCliente = updatePedido.IdCliente;
            pedido.IdComercial = updatePedido.IdComercial;

            _context.Pedidos.Update(pedido);
            return true;
        }

        public override async Task<bool> Delete(int id)
        {
            var pedido = await _context.Pedidos.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
            }

            return true;    
        }
    }
}