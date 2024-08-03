using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Dto
{
    public class Rol_UsuarioDto
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public int UsuarioId { get; set; }
    }
}
