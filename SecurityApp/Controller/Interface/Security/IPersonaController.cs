using Entity.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Interface.Security
{
    public interface IPersonaController
    {
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<PersonaDto>> Get(int id);
        Task<ActionResult> Post([FromBody] PersonaDto entityDto);
        Task<ActionResult> Put([FromBody] PersonaDto entityDto);
        Task<ActionResult> Delete();
        Task<ActionResult<List<PersonaDto>>> GetAll();
    }
}
