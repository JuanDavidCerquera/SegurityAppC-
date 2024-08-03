using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IRol_UsuarioData 
    {
        
        Task Delete(int id);
        Task<Rol_Usuario> GetById(int id);
        Task<Rol_Usuario> Save(Rol_Usuario entity);
        Task Update(Rol_Usuario entity);
        Task<List<Rol_Usuario>> GetAll();
    }
}
