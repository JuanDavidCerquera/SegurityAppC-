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
    public class DRolData : IRolData
    {
        private readonly AplicationContext context;
        protected readonly IConfiguration configuration;
        public DRolData(AplicationContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.DeletedAt = DateTime.Parse(DateTime.Today.ToString());
            context.Roles.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Rol> GetById(int id)
        {
            var sql = @"SELECT * FROM Rol WHERE Id = @Id";
            return await this.context.QueryFirstOrDefaultAsync<Rol>(sql, new { Id = id });
        }

        public async Task<Rol> Save(Rol entity)
        {
            context.Roles.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Rol entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<List<Rol>> GetAll()
        {
            var sql = "SELECT * FROM Roles WHERE Deleted_at IS NULL AND State = 1";
            var entity = await context.QueryAsync<Rol>(sql);
            return entity.ToList();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT id, nombre As TextoMostrar
               FROM 
                   Roles
               WHERE Deleted_at IS NULL AND State = 1
               ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<Rol> GetByCode(string code)
        {
            return await this.context.Roles.AsNoTracking().Where(item => item.Nombre == code).FirstOrDefaultAsync();
        }
    }
}
