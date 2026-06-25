using System.ComponentModel.DataAnnotations;

namespace exemploBlobAzure.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }

        public string? UsuarioNome { get; set; }

        public string? UsuarioImageUrl { get; set; }
    }
}
