using System.ComponentModel.DataAnnotations;

namespace WebApiAcadConnection.DTOs
{
    public class EnderecoDTO
    {
        public int? Codigo { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{5}\-[0-9]{3}", ErrorMessage = "O formato do CEP deve ser: 12345-678")]
        public string Cep { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "O Logradouro deve ter no maxímo 200 caracteres")]
        public string Logradouro { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "O Número deve ter no maxímo 10 caracteres")]
        public string Numero { get; set; }

        [MaxLength(100, ErrorMessage = "O Complemento deve ter no maxímo 100 caracteres")]
        public string Complemento { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "O Bairro deve ter no maxímo 150 caracteres")]
        public string Bairro { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "O Cidade deve ter no maxímo 50 caracteres")]
        public string Cidade { get; set; }

        [Required]
        [MaxLength(2, ErrorMessage = "O Estado deve ter no maxímo 2 caracteres")]
        public string Estado { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "O País deve ter no maxímo 50 caracteres")]
        public string Pais { get; set; }
    }
}