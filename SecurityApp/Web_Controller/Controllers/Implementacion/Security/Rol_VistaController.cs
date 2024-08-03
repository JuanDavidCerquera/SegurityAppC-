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
    [Route("Rol_Vista")]
    public class Rol_VistaController : ControllerBase
    {
        private readonly IRol_VistaBusiness business;

        public Rol_VistaController(IRol_VistaBusiness _business)
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
        public async Task<ActionResult<Rol_VistaDto>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<Rol_VistaDto>>> GetAll()
        {
            var result = await business.GetAll();
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<Rol_VistaDto>> Post([FromBody] Rol_VistaDto entityDto)
        {
            if (entityDto == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await business.Save(entityDto);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Rol_VistaDto entityDto)
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
