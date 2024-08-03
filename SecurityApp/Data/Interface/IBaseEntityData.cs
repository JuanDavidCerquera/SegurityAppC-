using Entity.Model.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IBaseEntityData<T> : IBaseData<T>
    {
        Task<T> GetByCode(string code);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
