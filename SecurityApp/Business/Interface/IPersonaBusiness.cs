using Entity.Model.Dto;
using Entity.Model.Security;

namespace Business.Interface
{
    public interface IPersonaBusiness 
    {

        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Persona> GetById(int id);
        Task<Persona> Save(PersonaDto entityDto);
        Task Update(PersonaDto entityDto);
        Task<List<PersonaDto>> GetAll();
    }
}
