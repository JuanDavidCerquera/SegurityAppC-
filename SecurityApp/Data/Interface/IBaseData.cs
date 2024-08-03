using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IBaseData<T>
    {
        Task Delete(int id);
        Task<T> GetById(int id);
        Task<T> Save(T entity);
        Task Update(T entity);
        Task<List<T>> GetAll();
    }
}
