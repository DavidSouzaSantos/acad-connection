using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiAcadConnection.DTOs
{
    public class InstituicaoDTO
    {
        public int? Codigo { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "O Nome deve ter no maxímo 100 caracteres")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "O Descrição deve ter no maxímo 100 caracteres")]
        public string Descricao { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{2}\.[0-9]{3}\.[0-9]{3}\/[0-9]{4}\-[0-9]{2}$", ErrorMessage = "O formato do CPF deve ser: 123.456.789-10")]
        public string Cnpj { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$", ErrorMessage = "O formato do CPF deve ser: 123.456.789-10")]
        public string Telefone { get; set; }

        [Required]
        public EnderecoDTO Endereco { get; set; }

        [Required]
        public UsuarioDTO Usuario { get; set; }

        public DateTime? DataCriacao { get; set; }
    }
}