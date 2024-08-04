

namespace Entity.Model.Security
{
    public class Usuario
    {
        public int Id {  get; set; }
        public string? Nombre { get; set; }
        public string? Contraseña { get; set; }
        public int Personaid { get; set; }
        public Persona Persona { get; set; } = new Persona();
        public DateTime? CreateAt { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }
        public bool Estado { get; set; }

    }
}
