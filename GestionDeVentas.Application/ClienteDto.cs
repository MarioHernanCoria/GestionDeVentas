using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeVentas.Application.Dtos
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Ciudad { get; set; }
        public int? Categoría { get; set; }
    }
}
