using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IRol_VistaData
    {
        Task Delete(int id);
        Task<Rol_Vista> GetById(int id);
        Task<Rol_Vista> Save(Rol_Vista entity);
        Task Update(Rol_Vista entity);
        Task<List<Rol_Vista>> GetAll();
    }
}
