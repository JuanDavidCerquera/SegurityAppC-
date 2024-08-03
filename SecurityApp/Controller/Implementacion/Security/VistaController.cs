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
    public class VistaController
    {
        private readonly IVistaBusiness business;

        public VistaController(IVistaBusiness business)
        {
            this.business = business;
        }

        [HttpDelete("{id}")]
        public Task<ActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public Task<ActionResult<VistaDto>> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public Task<ActionResult<List<VistaDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet("allSelect")]
        public Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Task<ActionResult> Post([FromBody] VistaDto entityDto)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public Task<ActionResult> Put([FromBody] VistaDto entityDto)
        {
            throw new NotImplementedException();
        }
    }
}
