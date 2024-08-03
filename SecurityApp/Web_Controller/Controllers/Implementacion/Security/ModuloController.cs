using Business.Implementacion;
using Business.Interface;
using Entity.Model.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Implementacion.Security
{
    [ApiController]
    [Route("Modulo")]
    public class ModuloController : ControllerBase 
    {
        private readonly IModuloBusiness business;

        public ModuloController(IModuloBusiness _business)
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
        public async Task<ActionResult<ModuloDto>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<ModuloDto>>> GetAll()
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
        public async Task<ActionResult<ModuloDto>> Post([FromBody] ModuloDto entityDto)
        {
            if (entityDto == null)
            {
                return BadRequest("Entity is null");

            }
            var result = await business.Save(entityDto);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut]
        public async  Task<ActionResult> Put([FromBody] ModuloDto entityDto)
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
