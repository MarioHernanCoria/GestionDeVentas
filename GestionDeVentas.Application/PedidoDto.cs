using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeVentas.Application.Dtos
{
    public class PedidoDto
    {
        public double Total { get; set; }
        public DateTime? Fecha { get; set; }
        public int IdCliente { get; set; }
        public int IdComercial { get; set; }
    }
}
