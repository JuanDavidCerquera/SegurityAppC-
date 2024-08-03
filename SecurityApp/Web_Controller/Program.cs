using Business.Implementacion;
using Business.Interface;
using Data.Data;
using Data.Interface;
using Entity.Model.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Configuracion Cords
    builder.Services.AddCors(options =>
     {
        options.AddPolicy("AllowSpecificOrigin",
            builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                            .AllowAnyHeader()
                            .AllowAnyMethod();


            });
    });



//Configura DbContext con SQL Server
builder.Services.AddDbContext<AplicationContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DbfaultConnection")));

//Add Business
builder.Services.AddScoped<IModuloBusiness, ModuloBusiness>();
builder.Services.AddScoped<IPersonaBusiness, PersonaBusiness>();
builder.Services.AddScoped<IRolBusiness, RolBusiness>();
builder.Services.AddScoped<IRol_VistaBusiness, Rol_VistaBusiness>();
builder.Services.AddScoped<IUsuarioBusiness, UsuarioBusiness>();
builder.Services.AddScoped<IRol_UsuarioBusiness, Rol_UsuarioBusiness>();
builder.Services.AddScoped<IVistaBusiness, VistaBusiness>();


//Add Data
builder.Services.AddScoped<IModuloData, DModuloData>();
builder.Services.AddScoped<IPersonaData, DPersonaData>();
builder.Services.AddScoped<IRolData, DRolData>();
builder.Services.AddScoped<IRol_VistaData, DRol_VistaData>();
builder.Services.AddScoped<IUsuarioData, DUsuarioData>();
builder.Services.AddScoped<IRol_UsuarioData, DRol_UsuarioData>();
builder.Services.AddScoped<IVistaData, DVistaData>();



// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
