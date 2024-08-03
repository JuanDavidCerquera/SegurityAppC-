using Entity.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Interface.Security
{
    public interface IUsuarioController
    {
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<UsuarioDto>> Get(int id);
        Task<ActionResult> Post([FromBody] UsuarioDto entityDto);
        Task<ActionResult> Put([FromBody] UsuarioDto entityDto);
        Task<ActionResult> Delete();
        Task<ActionResult<List<UsuarioDto>>> GetAll();
    }
}
