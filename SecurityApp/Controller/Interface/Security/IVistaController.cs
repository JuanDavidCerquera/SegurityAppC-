using Entity.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Interface.Security
{
    public interface IVistaController
    {
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<VistaDto>> Get(int id);
        Task<ActionResult> Post([FromBody] VistaDto entityDto);
        Task<ActionResult> Put([FromBody] VistaDto entityDto);
        Task<ActionResult> Delete();
        Task<ActionResult<List<VistaDto>>> GetAll();
    }
}
