using System;
using System.ComponentModel.DataAnnotations;
using WebApiAcadConnection.Enums;

namespace WebApiAcadConnection.DTOs
{
    ///<summary>
    ///Classe Professor
    ///</summary>
    public class ProfessorDTO
    {
        ///<summary>
        ///Código do Professor
        ///</summary>
        public int? Codigo { get; set; }

        ///<summary>
        ///Nome do Professor
        ///</summary>
        [Required]
        [MaxLength(250, ErrorMessage = "O Nome deve ter no maxímo 200 caracteres")]
        public string Nome { get; set; }

        ///<summary>
        ///CPF do Professor
        ///</summary>
        [Required]
        [RegularExpression(@"[0-9]{3}\.[0-9]{3}\.[0-9]{3}\-[0-9]{2}$", ErrorMessage = "O formato do CPF deve ser: 123.456.789-10")]
        public string Cpf { get; set; }

        ///<summary>
        ///Data de Nascimento do Professor
        ///</summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }

        ///<summary>
        ///Sexo do Professor
        ///</summary>
        public SexoEnum? Sexo { get; set; }

        ///<summary>
        ///Email do Professor
        ///</summary>
        [Required]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        ///<summary>
        ///Telefone do Professor
        ///</summary>
        [Required]
        [RegularExpression(@"^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$", ErrorMessage = "O formato do CPF deve ser: 123.456.789-10")]
        public string Telefone { get; set; }

        ///<summary>
        ///Endereço do Professor
        ///</summary>
        [Required]
        public EnderecoDTO Endereco { get; set; }

        ///<summary>
        ///Disciplina do Professor
        ///</summary>
        [Required]
        public DisciplinaDTO Disciplina { get; set; }

        ///<summary>
        ///Usuário do Professor
        ///</summary>
        [Required]
        public UsuarioDTO Usuario { get; set; }

        ///<summary>
        ///Instituição do Professor
        ///</summary>
        [Required]
        public InstituicaoDTO Instituicao { get; set; }

        ///<summary>
        ///Data da Criação do Professor
        ///</summary>
        public DateTime DataCriacao { get; set; }
    }
}

