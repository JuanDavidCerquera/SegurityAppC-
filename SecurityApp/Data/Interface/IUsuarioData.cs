using Entity.Model.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IUsuarioData
    {
        Task Delete(int id);
        Task<Usuario> GetById(int id);
        Task<Usuario> Save(Usuario entity);
        Task Update(Usuario entity);
        Task<List<Usuario>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
