using Business.Interface;
using Data.Interface;
using Entity.Model.Dto;
using Entity.Model.Security;
using System.Data;

namespace Business.Implementacion
{
    public class ModuloBusiness : IModuloBusiness
    {
        private readonly IModuloData data;
        public ModuloBusiness(IModuloData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<List<ModuloDto>> GetAll()
        {
            List<Modulo> entity = await this.data.GetAll();
            List<ModuloDto> entityDto = MostrarDatos(entity);
            return entityDto;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }

        public async Task<Modulo> GetById(int id)
        {
            Modulo entity = await this.data.GetById(id);
            return entity;
        }

        public async Task<Modulo> Save(ModuloDto entity)
        {
            Modulo modulo = new Modulo();
            modulo = this.MapearDatos(modulo, entity);
            modulo.CreateAt = DateTime.Now;
            modulo.Estado = true;
            return await this.data.Save(modulo);
        }

        public async Task Update( ModuloDto entity)
        {
            Modulo modulo = await this.data.GetById(entity.Id);
            if(modulo == null)
            {
                throw new Exception("Registro no encontrado");
            }
            modulo = MapearDatos(modulo, entity);
            modulo.UpdateAt = DateTime.Now;
            await this.data.Update(modulo);
        }

        private List<ModuloDto> MostrarDatos(List<Modulo> entity)
        {
            return entity.Select(item => new ModuloDto
            {
                Nombre = item.Nombre,
                Descripcion = item.Descripcion
            }).ToList();
        }
        private Modulo MapearDatos(Modulo entity, ModuloDto entityDto)
        {
            entity.Nombre = entityDto.Nombre;
            entity.Descripcion = entityDto.Descripcion;
            return entity;
        }
    }
}
