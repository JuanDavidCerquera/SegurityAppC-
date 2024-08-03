using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Dto
{
    public class VistaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Ruta { get; set; }
        public int ModuloId { get; set; }
        public Modulo modulo { get; set; }
    }
}
