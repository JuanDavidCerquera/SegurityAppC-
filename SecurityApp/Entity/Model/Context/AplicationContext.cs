using Dapper;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Context
{
    public class AplicationContext : DbContext
    {





        protected readonly IConfiguration _configuration;
        public AplicationContext(
            DbContextOptions<AplicationContext> options,
            IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }





        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        }






        private void EnsureAudit()
        {
            ChangeTracker.DetectChanges();
        }






        public override int SaveChanges()
        {
            EnsureAudit();
            return base.SaveChanges();
        }







        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSucces,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            EnsureAudit();
            return base.SaveChangesAsync(
                acceptAllChangesOnSucces,
                cancellationToken);
        }






        public async Task<IEnumerable<T>> QueryAsync<T>(
            string text,
            object parameters = null,
            int? timeout = null,
            CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(
                this,
                text,
                parameters,
                timeout,
                type,
                CancellationToken.None);

            var connection = this.Database.GetDbConnection();
            return await connection.QueryAsync<T>(command.Definition);
        }






        public async Task<T> QueryFirstOrDefaultAsync<T>(
            string text,
            object parameters = null,
            int? timeout = null,
            CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(
                this,
                text,
                parameters,
                timeout,
                type,
                CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(command.Definition);
        }







        public readonly struct DapperEFCoreCommand : IDisposable
        {
            public DapperEFCoreCommand(
                DbContext context,
                string text,
                object parameters,
                int? timeout,
                CommandType? type,
                CancellationToken ct)
            {
                var transaction = context.Database.CurrentTransaction?.GetDbTransaction();
                var commandType = type ?? CommandType.Text;
                var commandTimeout = timeout ?? context.Database.GetCommandTimeout() ?? 30;

                Definition = new CommandDefinition(
                    text,
                    parameters,
                    transaction,
                    commandTimeout,
                    commandType,
                    cancellationToken: ct
                );
            }

            public CommandDefinition Definition { get; }

            public void Dispose() { }
        }

        public DbSet<Vista> Vistas => Set<Vista>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Rol> Roles => Set<Rol>();
        public DbSet<Persona> Personas => Set<Persona>();
        public DbSet<Modulo> Modulos => Set<Modulo>();
        public DbSet<Rol_Vista> Rol_Vistas => Set<Rol_Vista>();
        public DbSet<Rol_Usuario> Rol_Usuarios => Set<Rol_Usuario>();



    }
}
