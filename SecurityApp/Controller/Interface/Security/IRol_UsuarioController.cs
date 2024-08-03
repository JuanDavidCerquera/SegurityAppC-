using Entity.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Interface.Security
{
    public interface IRol_UsuarioController
    {
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<Rol_UsuarioDto>> Get(int id);
        Task<ActionResult> Post([FromBody] Rol_UsuarioDto entityDto);
        Task<ActionResult> Put([FromBody] Rol_UsuarioDto entityDto);
        Task<ActionResult> Delete();
        Task<ActionResult<List<Rol_UsuarioDto>>> GetAll();
    }
}
