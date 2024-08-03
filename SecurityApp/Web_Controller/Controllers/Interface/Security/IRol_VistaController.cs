using Entity.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Interface.Security
{
    public interface IRol_VistaController
    {
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<Rol_VistaDto>> Get(int id);
        Task<ActionResult<Rol_VistaDto>> Post([FromBody] Rol_VistaDto entityDto);
        Task<ActionResult> Put([FromBody] Rol_VistaDto entityDto);
        Task<ActionResult> Delete(int id);
        Task<ActionResult<List<Rol_VistaDto>>> GetAll();
    }
}
