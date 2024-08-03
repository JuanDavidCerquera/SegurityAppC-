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
    public class UsuarioController
    {
        private readonly IUsuarioBusiness business;

        public UsuarioController(IUsuarioBusiness business)
        {
            this.business = business;
        }

        [HttpDelete("{id}")]
        public Task<ActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public Task<ActionResult<UsuarioDto>> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public Task<ActionResult<List<UsuarioDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet("allSelect")]
        public Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Task<ActionResult> Post([FromBody] UsuarioDto entityDto)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public Task<ActionResult> Put([FromBody] UsuarioDto entityDto)
        {
            throw new NotImplementedException();
        }
    }
}
