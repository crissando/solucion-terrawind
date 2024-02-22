using System.ComponentModel.DataAnnotations;

namespace api_terrawind.Models
{
    public class Gestores
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Lanzamiento { get; set; }
        public string Desarrollador { get; set; }
    }
}
