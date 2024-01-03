using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeVentas.Domain.Entities
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double Total { get; set; }

        public DateTime? Fecha { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [Required]
        public int IdComercial { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente? Cliente { get; set; }

        [ForeignKey("IdComercial")]
        public Comercial? Comercial { get; set; }
    }
}
