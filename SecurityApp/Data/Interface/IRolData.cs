using Entity.Model.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IRolData
    {
        Task Delete(int id);
        Task<Rol> GetById(int id);
        Task<Rol> Save(Rol entity);
        Task Update(Rol entity);
        Task<List<Rol>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
