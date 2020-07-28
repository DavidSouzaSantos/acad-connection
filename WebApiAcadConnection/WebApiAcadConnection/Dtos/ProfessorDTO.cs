using System;
using System.ComponentModel.DataAnnotations;
using WebApiAcadConnection.Enums;

namespace WebApiAcadConnection.DTOs
{
    public class ProfessorDTO
    {
        public int? Codigo { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "O Nome deve ter no maxímo 200 caracteres")]
        public string Nome { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{3}\.[0-9]{3}\.[0-9]{3}\-[0-9]{2}$", ErrorMessage = "O formato do CPF deve ser: 123.456.789-10")]
        public string Cpf { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }

        public SexoEnum? Sexo { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$", ErrorMessage = "O formato do CPF deve ser: 123.456.789-10")]
        public string Telefone { get; set; }

        [Required]
        public EnderecoDTO Endereco { get; set; }

        [Required]
        public DisciplinaDTO Disciplina { get; set; }

        [Required]
        public UsuarioDTO Usuario { get; set; }

        [Required]
        public InstituicaoDTO Instituicao { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}

