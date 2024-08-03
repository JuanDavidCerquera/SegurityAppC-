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
    public class DRol_VistaData : IRol_VistaData
    {
        private readonly AplicationContext context;
        protected readonly IConfiguration configuration;
        public DRol_VistaData(AplicationContext context, IConfiguration configuration)
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
            context.Rol_Vistas.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Rol_Vista> GetById(int id)
        {
            var sql = @"SELECT * FROM Rol_Vista WHERE Id = @Id";
            return await this.context.QueryFirstOrDefaultAsync<Rol_Vista>(sql, new { Id = id });
        }

        public async Task<Rol_Vista> Save(Rol_Vista entity)
        {
            context.Rol_Vistas.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Rol_Vista entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task<List<Rol_Vista>> GetAll()
        {
            var sql = "SELECT * FROM Rol_Vistas WHERE Deleted_at IS NULL AND State = 1";
            var entity = await context.QueryAsync<Rol_Vista>(sql);
            return entity.ToList();
        }


    }
}
