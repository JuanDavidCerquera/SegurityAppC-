using Business.Interface;
using Controller.Interface.Security;
using Entity.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Implementacion.Security
{
    [ApiController]
    [Route("Persona")]
    public class PersonaController : ControllerBase, IPersonaController
    {
        private readonly IPersonaBusiness business;

        public PersonaController(IPersonaBusiness _business)
        {
            business = _business;
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await business.Delete(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonaDto>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonaDto>>> GetAll()
        {
            var result = await business.GetAll();
            return Ok(result);
        }

        [HttpGet("allSelect")]
        public async Task<ActionResult<IEnumerable<DataSelectDto>>> GetAllSelect()
        {
            var result = await business.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<PersonaDto>> Post([FromBody] PersonaDto entityDto)
        {
            if (entityDto == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await business.Save(entityDto);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] PersonaDto entityDto)
        {

            if (entityDto == null)
            {
                return BadRequest();
            }
            await business.Update(entityDto);
            return NoContent();
        }
    }
}
