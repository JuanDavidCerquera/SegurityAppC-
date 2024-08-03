using Entity.Model.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IVistaBusiness 
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Vista> GetById(int id);
        Task<Vista> Save(VistaDto entityDto);
        Task Update(VistaDto entityDto);
        Task<List<VistaDto>> GetAll();
    }
}
