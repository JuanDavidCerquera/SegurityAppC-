using Business.Interface;
using Data.Interface;
using Entity.Model.Dto;
using Entity.Model.Security;

namespace Business.Implementacion
{
    public class Rol_UsuarioBusiness : IRol_UsuarioBusiness
    {
        private readonly IRol_UsuarioData data;
        public Rol_UsuarioBusiness(IRol_UsuarioData data)
        {
            this.data = data;
        }
        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }
        public async Task<List<Rol_UsuarioDto>> GetAll()
        {
            List<Rol_Usuario> entity = await this.data.GetAll();
            List<Rol_UsuarioDto> entityDto = MostrarDatos(entity);
            return entityDto;
        }
        public async Task<Rol_Usuario> GetById(int id)
        {
            Rol_Usuario entity = await this.data.GetById(id);
            return entity;
        }
        public async Task<Rol_Usuario> Save(Rol_UsuarioDto entityDto)
        {
            Rol_Usuario entity = new Rol_Usuario();
            entity = this.MapearDatos(entity, entityDto);
            entity.CreateAt = DateTime.Now;
            return await this.data.Save(entity);
        }
        public async Task Update(Rol_UsuarioDto entityDto)
        {
            Rol_Usuario entity = await this.data.GetById(entityDto.Id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity = MapearDatos(entity, entityDto);
            entity.UpdateAt = DateTime.Now;
            await this.data.Update(entity);
        }
        private Rol_UsuarioDto MostrarDatos(Rol_Usuario entity, Rol_UsuarioDto entityDto)
        {
            entityDto.RolId = entity.RolId;
            entityDto.UsuarioId = entity.UsuarioId;

            return entityDto;
        }
        private List<Rol_UsuarioDto> MostrarDatos(List<Rol_Usuario> listEntity)
        {
            List<Rol_UsuarioDto> listaDto = new List<Rol_UsuarioDto>();
            int i = 0;
            listEntity.ForEach(item =>
            {
                listaDto[i].RolId = item.RolId;
                listaDto[i].UsuarioId = item.UsuarioId;

                i++;
            });
            return listaDto;
        }
        private Rol_Usuario MapearDatos(Rol_Usuario entity, Rol_UsuarioDto entityDto)
        {
            entity.RolId = entityDto.RolId;
            entity.UsuarioId = entityDto.UsuarioId;

            return entity;
        }
    }
}
