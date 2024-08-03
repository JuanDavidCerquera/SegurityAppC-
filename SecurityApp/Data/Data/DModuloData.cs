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
    public class DModuloData : IModuloData
    {
        private readonly AplicationContext context;
        protected readonly IConfiguration configuration;
        public DModuloData(AplicationContext context, IConfiguration configuration)
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
            context.Modulos.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<Modulo> GetById(int id)
        {
            var sql = @"SELECT * FROM Modulos WHERE Id = @Id";
            return await this.context.QueryFirstOrDefaultAsync<Modulo>(sql,new {Id = id});
        }
        public async Task<Modulo> Save(Modulo entity)
        {
            context.Modulos.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task Update(Modulo entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task<List<Modulo>> GetAll()
        {
            var sql = "SELECT * FROM Modulos WHERE DeletedAt IS NULL AND Estado = 1";
            var entity = await context.QueryAsync<Modulo>(sql);
            return entity.ToList();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT id, nombre As TextoMostrar
               FROM 
                   Modulos
               WHERE DeletedAt IS NULL AND Estado = 1
               ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<Modulo> GetByCode(string code)
        {
            return await this.context.Modulos.AsNoTracking().Where(item => item.Nombre == code).FirstOrDefaultAsync();
        }
    }
}
