
using Entity.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Interface.Security
{
    public interface IModuloController
    {
   
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        //Traer por id
        Task<ActionResult<ModuloDto>>Get(int id);
        //Guardar
        Task<ActionResult<ModuloDto>> Post([FromBody] ModuloDto entity);
        //actualizar
        Task<ActionResult> Put([FromBody] ModuloDto entity);
        //eliminar
        Task<ActionResult> Delete(int id);
        //traer todo
        Task<ActionResult<List<ModuloDto>>> GetAll();

    }
}
