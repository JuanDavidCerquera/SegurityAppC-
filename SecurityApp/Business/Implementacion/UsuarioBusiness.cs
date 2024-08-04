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
    public class UsuarioBusiness : IUsuarioBusiness
    {

        private readonly IUsuarioData data;

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<List<UsuarioDto>> GetAll()
        {
            List<Usuario> entity = await this.data.GetAll();
            List<UsuarioDto> entityDto = MostrarDatos(entity);
            return entityDto;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }

        public async Task<Usuario> GetById(int id)
        {
            Usuario entity = await this.data.GetById(id);
            return entity;
        }

        public async Task<Usuario> Save(UsuarioDto entityDto)
        {
            Usuario Usuario = new Usuario();
            Usuario = this.MapearDatos(Usuario, entityDto);
            Usuario.CreateAt = DateTime.Now;
            Usuario.Estado = true;
            return await this.data.Save(Usuario);
        }

        public async Task Update(UsuarioDto entityDto)
        {
            Usuario entity = await this.data.GetById(entityDto.Id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity = MapearDatos(entity, entityDto);
            entity.UpdateAt = DateTime.Now;
            await this.data.Update(entity);
        }
        private UsuarioDto MostrarDatos(Usuario entity)
        {
            UsuarioDto entityDto = new UsuarioDto();
            entity.Nombre = entityDto.Nombre;
            entity.Contraseña = entityDto.Contraseña;
            entity.Personaid = entityDto.Personaid;

            return entityDto;
        }
        private List<UsuarioDto> MostrarDatos(List<Usuario> listEntity)
        {
            List<UsuarioDto> listaDto = new List<UsuarioDto>();
            int i = 0;
            listEntity.ForEach(item =>
            {
                listaDto[i].Nombre = item.Nombre;
                listaDto[i].Contraseña = item.Contraseña;
                listaDto[i].Personaid = item.Personaid;
                i++;
            });
            return listaDto;
        }
        private Usuario MapearDatos(Usuario entity, UsuarioDto entityDto)
        {
            entity.Nombre = entityDto.Nombre;
            entity.Contraseña = entityDto.Contraseña;
            entity.Personaid = entityDto.Personaid;
            return entity;
        }
    }
}
