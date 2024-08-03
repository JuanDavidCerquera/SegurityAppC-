using Business.Interface;
using Entity.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Implementacion.Security
{
    public class RolController
    {
        private readonly IRolBusiness business;

        public RolController(IRolBusiness business)
        {
            this.business = business;
        }

        [HttpDelete("{id}")]
        public Task<ActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public Task<ActionResult<RolDto>> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public Task<ActionResult<List<RolDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet("allSelect")]
        public Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Task<ActionResult> Post([FromBody] RolDto entityDto)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public Task<ActionResult> Put([FromBody] RolDto entityDto)
        {
            throw new NotImplementedException();
        }
    }
}
