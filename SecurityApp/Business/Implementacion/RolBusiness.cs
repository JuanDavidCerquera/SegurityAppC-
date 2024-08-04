using Business.Interface;
using Data.Interface;
using Entity.Model.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Business.Implementacion
{
    public class RolBusiness : IRolBusiness
    {

        private readonly IRolData data;

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<List<RolDto>> GetAll()
        {
            List<Rol> entity = await this.data.GetAll();
            List<RolDto> entityDto = MostrarDatos(entity);
            return entityDto;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }

        public async Task<Rol> GetById(int id)
        {
            Rol entity = await this.data.GetById(id);
            return entity;
        }

        public async Task<Rol> Save(RolDto entityDto)
        {
            Rol Rol = new Rol();
            Rol = this.MapearDatos(Rol, entityDto);
            Rol.CreateAt = DateTime.Now;
            Rol.Estado = true;
            return await this.data.Save(Rol);
        }

        public async Task Update(RolDto entityDto)
        {
            Rol entity = await this.data.GetById(entityDto.Id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity = MapearDatos(entity, entityDto);
            entity.UpdateAt = DateTime.Now;
            await this.data.Update(entity);
        }
        private RolDto MostrarDatos(Rol entity)
        {
            RolDto entityDto = new RolDto();
            entityDto.Nombre = entity.Nombre;
            entityDto.Descripcion = entity.Descripcion;
            return entityDto;
        }
        private List<RolDto> MostrarDatos(List<Rol> listEntity)
        {
            List<RolDto> listaDto = new List<RolDto>();
            int i = 0;
            listEntity.ForEach(item =>
            {
                listaDto[i].Nombre = item.Nombre;
                listaDto[i].Descripcion = item.Descripcion;
                i++;
            });
            return listaDto;
        }
        private Rol MapearDatos(Rol entity, RolDto entityDto)
        {
            entity.Nombre = entityDto.Nombre;
            entity.Descripcion = entityDto.Descripcion;
            return entity;
        }
    }
}
