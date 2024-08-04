

using Entity.Model.Security;

namespace Entity.Model.Security
{
    public class Vista
    {

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Ruta { get; set; }
        public int ModuloId { get; set; }
        public Modulo modulo { get; set; } = new Modulo();

        public DateTime? CreateAt { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }
        public bool Estado { get; set; }

    }
}
