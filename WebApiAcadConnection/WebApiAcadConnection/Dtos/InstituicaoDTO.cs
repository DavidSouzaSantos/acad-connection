using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiAcadConnection.DTOs
{
    ///<summary>
    ///Classe Instituição
    ///</summary>
    public class InstituicaoDTO
    {
        ///<summary>
        ///Código da Instituição
        ///</summary>
        public int? Codigo { get; set; }

        ///<summary>
        ///Nome da Instituição
        ///</summary>
        [Required]
        [MaxLength(100, ErrorMessage = "O Nome deve ter no maxímo 100 caracteres")]
        public string Nome { get; set; }

        ///<summary>
        ///Descrição da Instituição
        ///</summary>
        [Required]
        [MaxLength(250, ErrorMessage = "O Descrição deve ter no maxímo 100 caracteres")]
        public string Descricao { get; set; }

        ///<summary>
        ///CNPJ da Instituição
        ///</summary>
        [Required]
        [RegularExpression(@"[0-9]{2}\.[0-9]{3}\.[0-9]{3}\/[0-9]{4}\-[0-9]{2}$", ErrorMessage = "O formato do CPF deve ser: 123.456.789-10")]
        public string Cnpj { get; set; }

        ///<summary>
        ///Email da Instituição
        ///</summary>
        [Required]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        ///<summary>
        ///Telefone da Instituição
        ///</summary>
        [Required]
        [RegularExpression(@"^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$", ErrorMessage = "O formato do CPF deve ser: 123.456.789-10")]
        public string Telefone { get; set; }

        ///<summary>
        ///Endereço da Instituição
        ///</summary>
        [Required]
        public EnderecoDTO Endereco { get; set; }

        ///<summary>
        ///Usuário da Instituição
        ///</summary>
        [Required]
        public UsuarioDTO Usuario { get; set; }

        ///<summary>
        ///Data da Criação da Instituição
        ///</summary>
        public DateTime? DataCriacao { get; set; }
    }
}