using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interface;
using Data.Interface;
using Entity.Model.Dto;
using Entity.Model.Security;

namespace Business.Implementacion
{
    public class VistaBusiness : IVistaBusiness
    {

        public readonly IVistaData data;
        public VistaBusiness(IVistaData data)
        {
            this.data = data;
        }
        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }
        public async Task<Vista> GetById(int id)
        {
            Vista entity = await this.data.GetById(id); 
            return entity;           
        }
        public async Task<Vista> Save(VistaDto entity)
        {
            Vista vista = new Vista();
            vista = this.MapearDatos(vista, entity);
            vista.CreateAt = DateTime.Now;
            vista.Estado = true;
            return await this.data.Save(vista);
        }
        public async Task Update(VistaDto entity)
        {
            Vista vista = await this.data.GetById(entity.Id);
            if (vista == null)
            {
                throw new Exception("Registro no encontrado");
            }
            vista = this.MapearDatos(vista, entity);
            vista.UpdateAt = DateTime.Now;

            await this.data.Update(vista);
        }
        public async Task<List<VistaDto>> GetAll()
        {
            List<Vista> vista = await this.data.GetAll();
            List<VistaDto> vistaDto = MostrarDatos(vista);
            return vistaDto;
        }
        private VistaDto MostrarDatos(Vista entity, VistaDto entityDto)
        {
            entityDto.Nombre = entity.Nombre;
            entityDto.Descripcion = entity.Descripcion;
            entityDto.Ruta = entity.Ruta;
            entityDto.ModuloId = entity.ModuloId;
            return entityDto;
        }
        private Vista MapearDatos(Vista entity, VistaDto entityDto)
        {
            entity.Nombre = entityDto.Nombre;
            entity.Descripcion = entityDto.Descripcion;
            entity.Ruta = entityDto.Ruta;
            entity.ModuloId = entityDto.ModuloId;
            return entity;
        }
        private List<VistaDto> MostrarDatos(List<Vista> entity)
        {
            List<VistaDto> listaDto = new List<VistaDto>();
            int i = 0;
            entity.ForEach(item =>
            {
                listaDto[i].Nombre = item.Nombre;
                listaDto[i].Descripcion = item.Descripcion;
                listaDto[i].Ruta = item.Ruta;
                listaDto[i].ModuloId = item.ModuloId;
                i++;
            });
            return listaDto;
        }

    }
}
