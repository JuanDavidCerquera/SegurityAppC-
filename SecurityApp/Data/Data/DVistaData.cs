using System;
using Entity.Model.Context;
using Entity.Model.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Data.Interface;
using Entity.Model.Dto;

namespace Data.Data
{
    public class DVistaData : IVistaData
    {
        private readonly AplicationContext context;
        protected readonly IConfiguration configuration;
        public DVistaData( AplicationContext context, IConfiguration configuration)
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
            entity.Estado = false;
            context.Vistas.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Vista> GetById(int id)
        {
            var sql = @"SELECT * FROM vistas WHERE Id = @Id";
            return await this.context.QueryFirstOrDefaultAsync<Vista>(sql, new { Id = id });
        }

        public async Task<Vista> Save(Vista entity)
        {
            context.Vistas.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Vista entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<Vista> GetByCode(string code)
        {
            return await this.context.Vistas.AsNoTracking().Where(item => item.Nombre == code).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
      {
          var sql = @"SELECT id, nombre As TextoMostrar
               FROM 
                   vistas
               WHERE DeletedAt IS NULL AND Estado = 1
               ORDER BY Id ASC";
          return await context.QueryAsync<DataSelectDto>(sql);
      }

        public async Task<List<Vista>> GetAll()
        {
            var sql = @"SELECT * FROM vistas WHERE DeletedAt IS NULL AND Estado = 1";
            var Entity = await context.QueryAsync<Vista>(sql);
            return Entity.ToList();
        }

        /*
     public async Task<PagedListDto<CiudadesDto>> GetDataTable(QueryFilterDto filter)
     {
         int pageNumber = (filter.PageNumber == 0) ? Int32.Parse(configuration["Pagination:DefaultPageNumber"]) : filter.PageNumber;
         int pageSize = (filter.PageSize == 0) ? Int32.Parse(configuration["Pagination:DefaultPageSize"]) : filter.PageSize;

         var sql = @"SELECT
                     ciu.Id,
                     ciu.Codigo,
                     ciu.Nombre,
                     ciu.Estado,
                     ciu.DepartamentoId,
                     dep.Nombre AS Departamento
                 FROM parametro.Ciudades ciu
                     INNER JOIN parametro.Departamentos dep ON ciu.DepartamentoId = dep.Id
                     WHERE ciu.DeletedAt IS NULL AND
                     (UPPER(CONCAT(ciu.Codigo, ciu.Nombre, ciu.DepartamentoId, dep.Nombre)) LIKE UPPER(CONCAT('%', @filter, '%')))
                     ORDER BY '" + (filter.ColumnOrder ?? "Id") + "' " + (filter.DirectionOrder ?? "asc");

         IEnumerable<CiudadesDto> items = await context.QueryAsync<CiudadesDto>(sql, new { Filter = filter.Filter });

         var pagedItems = PagedListDto<CiudadesDto>.Create(items, pageNumber, pageSize);

         return pagedItems;
     }*/

    }
}
