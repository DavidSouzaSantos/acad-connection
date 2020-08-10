using System.ComponentModel.DataAnnotations;
using WebApiAcadConnection.Enums;

namespace WebApiAcadConnection.DTOs
{
    ///<summary>
    ///Classe Usuário
    ///</summary>
    public class UsuarioDTO
    {
        ///<summary>
        ///Código do Usuário
        ///</summary>
        public int? Codigo { get; set; }

        ///<summary>
        ///Login do Usuário
        ///</summary>
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "O Login deve conter de 5 a 20 caracteres")]
        public string Login { get; set; }

        ///<summary>
        ///Senha do Usuário
        ///</summary>
        [Required]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "A Senha deve conter de 8 a 10 caracteres")]
        public string Senha { get; set; }

        ///<summary>
        ///Perfil do Usuário
        ///</summary>
        public PerfilEnum? Perfil { get; set; }
    }
}