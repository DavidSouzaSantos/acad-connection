using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiAcadConnection.DTOs
{
    public class NotaDTO
    {
        public int Codigo { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "A Nota deve ser de 0 a 10")]
        public int Nota { get; set; }

        [Required]
        public AvaliacaoDTO Avaliacao { get; set; }

        [Required]
        public AlunoDTO Aluno { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}