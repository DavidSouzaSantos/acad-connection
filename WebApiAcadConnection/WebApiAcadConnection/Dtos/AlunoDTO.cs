using System;
using System.ComponentModel.DataAnnotations;
using WebApiAcadConnection.Enums;

namespace WebApiAcadConnection.DTOs
{
    ///<summary>
    ///Classe Aluno
    ///</summary>
    public class AlunoDTO
    {
        ///<summary>
        ///Código do Aluno
        ///</summary>
        public int? Codigo { get; set; }

        ///<summary>
        ///Nome do Aluno
        ///</summary>
        [Required]
        [MaxLength(250, ErrorMessage = "O Nome deve ter no maxímo 200 caracteres")]
        public string Nome { get; set; }

        ///<summary>
        ///CPF do Aluno
        ///</summary>
        [Required]
        [RegularExpression(@"[0-9]{3}\.[0-9]{3}\.[0-9]{3}\-[0-9]{2}$", ErrorMessage = "O formato do CPF deve ser: 123.456.789-10")]
        public string Cpf { get; set; }

        ///<summary>
        ///Data de Nascimento do Aluno
        ///</summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }

        ///<summary>
        ///Classe Aluno
        ///</summary>
        public SexoEnum? Sexo { get; set; }

        ///<summary>
        ///Email do Aluno
        ///</summary>
        [Required]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        ///<summary>
        ///Telefone do Aluno
        ///</summary>
        [Required]
        [RegularExpression(@"^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$", ErrorMessage = "O formato do CPF deve ser: 123.456.789-10")]
        public string Telefone { get; set; }

        ///<summary>
        ///Endereço do Aluno
        ///</summary>
        [Required]
        public EnderecoDTO Endereco { get; set; }

        ///<summary>
        ///Usuário do Aluno
        ///</summary>
        [Required]
        public UsuarioDTO Usuario { get; set; }

        ///<summary>
        ///Data de Criação do Aluno
        ///</summary>
        public DateTime? DataCriacao { get; set; }
    }
}