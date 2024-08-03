using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Dto
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nombre{ get; set; }
        public string Contraseña { get; set; }
        public int Personaid { get; set; }
    }
}
