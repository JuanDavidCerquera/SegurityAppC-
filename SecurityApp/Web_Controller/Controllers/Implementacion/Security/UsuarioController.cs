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
    [ApiController]
    [Route("Usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioBusiness business;

        public UsuarioController(IUsuarioBusiness _business)
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
        public async Task<ActionResult<UsuarioDto>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioDto>>> GetAll()
        {
            var result = await business.GetAll();
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> Post([FromBody] UsuarioDto entityDto)
        {
            if (entityDto == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await business.Save(entityDto);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UsuarioDto entityDto)
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
