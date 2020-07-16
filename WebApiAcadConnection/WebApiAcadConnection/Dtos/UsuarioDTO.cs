using System.ComponentModel.DataAnnotations;
using WebApiAcadConnection.Enums;

namespace WebApiAcadConnection.Dtos
{
    public class UsuarioDTO
    {
        public int? Codigo { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "O Login deve conter de 5 a 20 caracteres")]
        public string Login { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "A Senha deve conter de 8 a 10 caracteres")]
        public string Senha { get; set; }

        public PerfilEnum? Perfil { get; set; }
    }
}