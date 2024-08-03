using Entity.Model.Dto;
using Entity.Model.Security;

namespace Business.Interface
{
    public interface IModuloBusiness 
    {

        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Modulo> GetById(int id);
        Task<Modulo> Save(ModuloDto entityDto);
        Task Update(ModuloDto entityDto);
        Task<List<ModuloDto>> GetAll();
    }
}
