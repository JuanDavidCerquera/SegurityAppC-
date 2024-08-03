using Entity.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Interface.Security
{
    internal interface IBaseController<Dto>
    {
        Task<ActionResult<ApiResponce<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponce<Dto>>> Get(int id);
        Task<ActionResult> Post([FromBody] Dto entityDto);
        Task<ActionResult> Put([FromBody] Dto entityDto);
        Task<ActionResult> Delete();
        Task<ActionResult<ApiResponce<List<Dto>>>> GetAll();
    }
}
