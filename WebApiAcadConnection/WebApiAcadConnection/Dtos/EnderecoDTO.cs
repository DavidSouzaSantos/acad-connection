using System.ComponentModel.DataAnnotations;

namespace WebApiAcadConnection.DTOs
{
    ///<summary>
    ///Classe Endereço
    ///</summary>
    public class EnderecoDTO
    {
        ///<summary>
        ///Código
        ///</summary>
        public int? Codigo { get; set; }

        ///<summary>
        ///CEP
        ///</summary>
        [Required]
        [RegularExpression(@"[0-9]{5}\-[0-9]{3}", ErrorMessage = "O formato do CEP deve ser: 12345-678")]
        public string Cep { get; set; }

        ///<summary>
        ///Logradouro
        ///</summary>
        [Required]
        [MaxLength(200, ErrorMessage = "O Logradouro deve ter no maxímo 200 caracteres")]
        public string Logradouro { get; set; }

        ///<summary>
        ///Número
        ///</summary>
        [Required]
        [MaxLength(10, ErrorMessage = "O Número deve ter no maxímo 10 caracteres")]
        public string Numero { get; set; }

        ///<summary>
        ///Complemento
        ///</summary>
        [MaxLength(100, ErrorMessage = "O Complemento deve ter no maxímo 100 caracteres")]
        public string Complemento { get; set; }

        ///<summary>
        ///Bairro
        ///</summary>
        [Required]
        [MaxLength(150, ErrorMessage = "O Bairro deve ter no maxímo 150 caracteres")]
        public string Bairro { get; set; }

        ///<summary>
        ///Cidade
        ///</summary>
        [Required]
        [MaxLength(50, ErrorMessage = "O Cidade deve ter no maxímo 50 caracteres")]
        public string Cidade { get; set; }

        ///<summary>
        ///Estado
        ///</summary>
        [Required]
        [MaxLength(2, ErrorMessage = "O Estado deve ter no maxímo 2 caracteres")]
        public string Estado { get; set; }

        ///<summary>
        ///País
        ///</summary>
        [Required]
        [MaxLength(50, ErrorMessage = "O País deve ter no maxímo 50 caracteres")]
        public string Pais { get; set; }
    }
}