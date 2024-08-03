using Entity.Model.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IRol_UsuarioBusiness
    {
        Task Delete(int id);
        Task<Rol_Usuario> GetById(int id);
        Task<Rol_Usuario> Save(Rol_UsuarioDto entityDto);
        Task Update(Rol_UsuarioDto entityDto);
        Task<List<Rol_UsuarioDto>> GetAll();
    }
}
