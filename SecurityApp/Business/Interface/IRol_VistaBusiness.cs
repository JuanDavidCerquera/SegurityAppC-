using Entity.Model.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IRol_VistaBusiness
    {
        Task Delete(int id);
        Task<Rol_Vista> GetById(int id);
        Task<Rol_Vista> Save(Rol_VistaDto entityDto);
        Task Update(Rol_VistaDto entityDto);
        Task<List<Rol_VistaDto>> GetAll();
    }
}
