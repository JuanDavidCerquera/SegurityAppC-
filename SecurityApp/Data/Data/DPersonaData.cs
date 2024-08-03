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
    public class DPersonaData : IPersonaData
    {
        private readonly AplicationContext context;
        protected readonly IConfiguration configuration;
        public DPersonaData(AplicationContext context, IConfiguration configuration)
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
            context.Personas.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Persona> GetById(int id)
        {
            var sql = @"SELECT * FROM Persona WHERE Id = @Id";
            return await this.context.QueryFirstOrDefaultAsync<Persona>(sql, new { Id = id });
        }

        public async Task<Persona> Save(Persona entity)
        {
            context.Personas.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Persona entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task<List<Persona>> GetAll()
        {
            var sql = "SELECT * FROM Personas WHERE Deleted_at IS NULL AND State = 1";
            var entity = await context.QueryAsync<Persona>(sql);
            return entity.ToList();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT id, CONCAT(Nombre,' ',Apellido) As TextoMostrar
               FROM 
                   Personas
               WHERE Deleted_at IS NULL AND State = 1
               ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<Persona> GetByCode(string code)
        {
            return await this.context.Personas.AsNoTracking().Where(item => item.Nombre == code).FirstOrDefaultAsync();
        }
    }
}
