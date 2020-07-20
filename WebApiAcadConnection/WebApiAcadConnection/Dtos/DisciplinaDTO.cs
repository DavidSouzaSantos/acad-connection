using System.ComponentModel.DataAnnotations;

namespace WebApiAcadConnection.DTOs
{
    public class DisciplinaDTO
    {
        public int? Codigo { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "O Nome deve ter no maxímo 150 caracteres")]
        public string Nome { get; set; }

        [Required]
        public InstituicaoDTO Institucao { get; set; }

    }
}