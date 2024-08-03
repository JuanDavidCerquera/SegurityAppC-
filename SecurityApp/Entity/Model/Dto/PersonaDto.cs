using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Dto
{
    public class PersonaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string Direccion { get; set; }
        public string TipoDocumento { get; set; }
        public int NumeroDocumento { get; set; }
        public int Telefono { get; set; }
    }
}
