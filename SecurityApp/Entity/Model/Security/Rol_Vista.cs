

namespace Entity.Model.Security
{
    public class Rol_Vista
    {
        public int Id { get; set; }
        public int VistaId {get;set;}
        public Vista Vista { get; set; } = new Vista();
        public int RolId {get;set;}
        public Rol Rol { get; set; } = new Rol();
        public DateTime? CreateAt { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }
        public bool Estado { get; set; }

    }
}
