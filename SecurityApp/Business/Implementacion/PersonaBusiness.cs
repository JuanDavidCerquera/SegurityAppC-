using Business.Interface;
using Data.Interface;
using Entity.Model.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementacion
{
    public class PersonaBusiness : IPersonaBusiness
    {
        private readonly IPersonaData data;

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<List<PersonaDto>> GetAll()
        {
            List<Persona> entity = await this.data.GetAll();
            List<PersonaDto> entityDto = MostrarDatos(entity);
            return entityDto;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }

        public async Task<Persona> GetById(int id)
        {
            Persona entity = await this.data.GetById(id);
            return entity;
        }

        public async Task<Persona> Save(PersonaDto entityDto)
        {
            Persona entity = new Persona();
            entity = this.MapearDatos(entity, entityDto);
            entity.CreateAt = DateTime.Now;
            entity.Estado = true;
            return await this.data.Save(entity);
        }

        public async Task Update(PersonaDto entityDto)
        {
            Persona entity = await this.data.GetById(entityDto.Id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity = MapearDatos(entity, entityDto);
            entity.UpdateAt = DateTime.Now;
            await this.data.Update(entity);
        }

        private PersonaDto MostrarDatos(Persona entity, PersonaDto entityDto)
        {
            entityDto.Nombre = entity.Nombre;
            entityDto.Apellido = entity.Apellido;
            entityDto.CorreoElectronico = entity.CorreoElectronico;
            entityDto.FechaNacimiento = entity.FechaNacimiento;
            entityDto.Genero = entity.Genero;
            entityDto.Direccion = entity.Direccion;
            entityDto.TipoDocumento = entity.TipoDocumento;
            entityDto.NumeroDocumento = entity.NumeroDocumento;
            entityDto.Telefono = entity.Telefono;
            return entityDto;
        }
        private List<PersonaDto> MostrarDatos(List<Persona> listEntity)
        {
            List<PersonaDto> listaDto = new List<PersonaDto>();
            int i = 0;
            listEntity.ForEach(item =>
            {
                listaDto[i].Nombre = item.Nombre;

                i++;
            });
            return listaDto;
        }
        private Persona MapearDatos(Persona entity, PersonaDto entityDto)
        {
            entity.Nombre = entityDto.Nombre;
            entity.Apellido = entityDto.Apellido;
            entity.CorreoElectronico = entityDto.CorreoElectronico;
            entity.FechaNacimiento = entityDto.FechaNacimiento;
            entity.Genero = entityDto.Genero;
            entity.Direccion = entityDto.Direccion;
            entity.TipoDocumento = entityDto.TipoDocumento;
            entity.NumeroDocumento = entityDto.NumeroDocumento;
            entity.Telefono = entityDto.Telefono;
 
            return entity;
        }
    }
}
