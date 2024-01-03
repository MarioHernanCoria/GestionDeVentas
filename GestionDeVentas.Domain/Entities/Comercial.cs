using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeVentas.Domain.Entities
{
    public class Comercial
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido1 { get; set; }

        [StringLength(100)]
        public string Apellido2 { get; set; }

        public float? Comisión { get; set; }
    }
}
