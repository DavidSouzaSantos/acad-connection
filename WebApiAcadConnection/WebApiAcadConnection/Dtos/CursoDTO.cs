using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiAcadConnection.DTOs
{
    public class CursoDTO
    {
        public int? Codigo { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "O Nome deve ter no maxímo 100 caracteres")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "O Descrição deve ter no maxímo 100 caracteres")]
        public string Descricao { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataFim { get; set; }

        public int Duracao { get; set; }

        [Required]
        public ProfessorDTO Professor { get; set; }

        [Required]
        public DisciplinaDTO Disciplina { get; set; }

        [Required]
        public InstituicaoDTO Instituicao { get; set; }

        public DateTime DataCriacao { get; set; }

    }
}