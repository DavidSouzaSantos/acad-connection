using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiAcadConnection.Dtos
{
    public class AvaliacaoDTO
    {
        public int Codigo { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "O Nome deve ter no maxímo 100 caracteres")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "O Descrição deve ter no maxímo 100 caracteres")]
        public string Descricao { get; set; }

        public int Peso { get; set; }

        [Required]
        public CursoDTO Curso { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}