

namespace Entity.Model.Security
{
    public class Rol_Usuario
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public Rol Rol { get; set; } = new Rol();
        public int UsuarioId { get; set; }
        public Usuario usuario { get; set; } = new Usuario();
        public DateTime CreateAt { get; set; }
        public int CreateBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public int UpdateBy { get; set; }
        public DateTime DeletedAt { get; set; }
        public int DeletedBy { get; set; }
        public Boolean Estado { get; set; }
    }
}
