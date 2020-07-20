using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiAcadConnection.DTOs
{
    public class InstituicaoDTO
    {
        public int Codigo { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "O Nome deve ter no maxímo 100 caracteres")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "O Descrição deve ter no maxímo 100 caracteres")]
        public string Descricao { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        [Required]
        public EnderecoDTO Endereco { get; set; }

        [Required]
        public UsuarioDTO Usuario { get; set; }

        public DateTime? DataCriacao { get; set; }
    }
}