using Entity.Model.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IUsuarioBusiness 
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Usuario> GetById(int id);
        Task<Usuario> Save(UsuarioDto entityDto);
        Task Update(UsuarioDto entityDto);
        Task<List<UsuarioDto>> GetAll();
    }
}
