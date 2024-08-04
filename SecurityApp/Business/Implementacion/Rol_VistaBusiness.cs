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
    public class Rol_VistaBusiness : IRol_VistaBusiness
    {
        private readonly IRol_VistaData data;
        public async  Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async  Task<List<Rol_VistaDto>> GetAll()
        {
            List<Rol_Vista> listEntity = await this.data.GetAll();
            List <Rol_VistaDto> listEntityDto = this.MostrarDatos(listEntity);
            return listEntityDto;
        }

        public async  Task<Rol_Vista> GetById(int id)
        {
            Rol_Vista entity = await this.data.GetById(id);
            return entity;
        }

        public async  Task<Rol_Vista> Save(Rol_VistaDto entityDto)
        {
            Rol_Vista entity = new Rol_Vista();
            entity = this.MapearDatos(entity,entityDto);
            entity.Estado = true;
            return entity;


        }

        public async  Task Update(Rol_VistaDto entityDto)
        {
            Rol_Vista entity = await this.data.GetById(entityDto.Id);
            if(entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity = this.MapearDatos(entity, entityDto);
            entity.UpdateAt = DateTime.Now;

            await this.data.Update(entity);
        }

        private Rol_VistaDto MostrarDatos(Rol_Vista entity)
        {
            Rol_VistaDto entityDto = new Rol_VistaDto();
            entityDto.RolId = entity.RolId;
            entityDto.VistaId = entity.VistaId;
            return entityDto;
        }
        private Rol_Vista MapearDatos(Rol_Vista entity, Rol_VistaDto entityDto)
        {
            entity.RolId = entityDto.RolId;
            entity.VistaId = entityDto.VistaId;
            return entity;
        }
        private List<Rol_VistaDto> MostrarDatos(List<Rol_Vista> entity)
        {
            List<Rol_VistaDto> listaDto = new List<Rol_VistaDto>();
            int i = 0;
            entity.ForEach(item =>
            {
                listaDto[i].RolId = item.RolId;
                listaDto[i].VistaId = item.VistaId;
                i++;
            });
            return listaDto;
        }

    }
}
