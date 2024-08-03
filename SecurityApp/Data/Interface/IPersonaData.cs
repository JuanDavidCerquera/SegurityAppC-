using Entity.Model.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IPersonaData
    {
        Task Delete(int id);
        Task<Persona> GetById(int id);
        Task<Persona> Save(Persona entity);
        Task Update(Persona entity);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<List<Persona>> GetAll();
    }
}
