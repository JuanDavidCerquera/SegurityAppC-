

namespace Entity.Model.Security
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? CorreoElectronico { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public string Direccion { get; set; }
        public string TipoDocumento { get; set; }
        public int NumeroDocumento { get; set; }
        public int Telefono { get; set; }
        public DateTime? CreateAt { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }
        public bool Estado { get; set; }


    }
}
