using Entity.Model.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IRolBusiness
    {

        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Rol> GetById(int id);
        Task<Rol> Save(RolDto entityDto);
        Task Update(RolDto entityDto);
        Task<List<RolDto>> GetAll();
    }
}
