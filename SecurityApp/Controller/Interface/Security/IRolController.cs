using Entity.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Interface.Security
{
    public interface IRolController
    {
        Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect();
        Task<ActionResult<RolDto>> Get(int id);
        Task<ActionResult> Post([FromBody] RolDto entityDto);
        Task<ActionResult> Put([FromBody] RolDto entityDto);
        Task<ActionResult> Delete();
        Task<ActionResult<List<RolDto>>> GetAll();
    }
}
