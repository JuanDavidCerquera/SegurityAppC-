using Entity.Model.Security;
using Entity.Model.Dto;

namespace Data.Interface
{
    public interface IVistaData
    {
        Task Delete(int id);
        Task<Vista> GetById(int id);
        Task<Vista> Save(Vista entity);
        Task Update(Vista entity);
 
        Task<List<Vista>> GetAll();
        Task<Vista> GetByCode(string code);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();


    }
}
