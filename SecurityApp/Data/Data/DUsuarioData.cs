using Data.Interface;
using Entity.Model.Context;
using Entity.Model.Dto;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class DUsuarioData : IUsuarioData
    {
        private readonly AplicationContext context;
        protected readonly IConfiguration configuration;

        public DUsuarioData(AplicationContext context, IConfiguration configuration) 
        {
            this.context = context;
            this.configuration = configuration;
        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("registro no encontrado");
            }
            entity.DeletedAt = DateTime.Parse(DateTime.Today.ToString());
            entity.Estado = false;
            context.Usuarios.Update(entity);

        }

        public async Task<Usuario> GetById(int id)
        {
            var sql = @"SELECT * FROM Usuarios WHERE Id = @Id";
            return await this.context.QueryFirstOrDefaultAsync<Usuario>(sql, new {Id = id});
        }

        public async Task<Usuario> Save(Usuario entity)
        {
            context.Usuarios.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Usuario entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task<List<Usuario>> GetAll()
        {
            var sql = "SELECT * FROM Usuarios WHERE DeletedAt IS NULL AND Estado = 1";
            var entity = await context.QueryAsync<Usuario>(sql);
            return entity.ToList();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT id, Nombre As TextoMostrar
               FROM 
                   Usuarios
               WHERE DeletedAt IS NULL AND Estado = 1
               ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<Usuario> GetByCode(string code)
        {
            return await this.context.Usuarios.AsNoTracking().Where(item => item.Nombre == code).FirstOrDefaultAsync();
        }
    }
}
