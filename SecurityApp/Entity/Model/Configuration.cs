using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.Model
{
    internal class Configuration
    {
        public void configureUsuario(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasIndex(i => i.Nombre).IsUnique();
            builder.HasIndex(i => i.Contraseña).IsUnique();
        }
        public void configurePersona(EntityTypeBuilder<Persona> builder)
        {
            builder.HasIndex(i => i.NumeroDocumento).IsUnique();
            builder.HasIndex(i => i.CorreoElectronico).IsUnique();
            builder.HasIndex(i => i.Telefono).IsUnique();
        }
        public void configureModulo(EntityTypeBuilder<Modulo> builder)
        {

        }
        public void configureVista(EntityTypeBuilder<Vista> builder)
        {

        }
        public void configureRolVista(EntityTypeBuilder<Rol_Vista> builder)
        {

        }
        public void configureRol(EntityTypeBuilder<Rol> builder)
        {

        }
        public void configureUsuarioRol(EntityTypeBuilder<Rol_Usuario> builder)
        {

        }
    }
}
