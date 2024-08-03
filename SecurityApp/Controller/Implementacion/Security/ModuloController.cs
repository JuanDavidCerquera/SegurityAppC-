using Business.Interface;
using Controller.Interface.Security;
using Entity.Model.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Implementacion.Security
{
    public class ModuloController : IModuloController
    {
        private readonly IModuloBusiness business;

        public ModuloController(IModuloBusiness business)
        {
            this.business = business;
        }

        [HttpDelete("{id}")]
        public Task<ActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public Task<ActionResult<ModuloDto>> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public Task<ActionResult<List<ModuloDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet("allSelect")]
        public Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ModuloDto entityDto)
        {
            try
            {
                Modulo entity = await business.Save(entityDto);
                return new CreatedAtRouteResult(new { id=entity.Id},entity);
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                throw new NotImplementedException();
            }
            
        }

        [HttpPut("{id}")]
        public Task<ActionResult> Put([FromBody] ModuloDto entityDto)
        {
            throw new NotImplementedException();
        }
    }
}
