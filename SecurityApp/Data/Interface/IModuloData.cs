using Entity.Model.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IModuloData 
    {
        Task Delete(int id);
        Task<Modulo> GetById(int id);
        Task<Modulo> Save(Modulo entity);
        Task Update(Modulo entity);
        Task<List<Modulo>> GetAll();
        Task<Modulo> GetByCode(string code);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
