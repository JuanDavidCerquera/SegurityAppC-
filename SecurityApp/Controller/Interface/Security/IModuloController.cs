using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Interface.Security
{
    public interface IModuloController
    {
        [HttpDelete("{id}")]
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        //Traer por id
        Task<ActionResult<ModuloDto>>Get(int id);
        //Guardar
        Task<ActionResult> Post([FromBody] ModuloDto entity);
        //actualizar
        Task<ActionResult> Put([FromBody] ModuloDto entity);
        //eliminar
        Task<ActionResult> Delete(int id);
        //traer todo
        Task<ActionResult<List<ModuloDto>>> GetAll();

    }
}
