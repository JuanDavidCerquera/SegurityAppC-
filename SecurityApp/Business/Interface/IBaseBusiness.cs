using Entity.Model.Dto;

namespace Business.Interface
{
    public interface IBaseBusiness<T, Dto>
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<T> GetById(int id);
        Task<T> Save(Dto entityDto);
        Task Update( Dto entityDto);
        Task<List<Dto>> GetAll();

    }
}
