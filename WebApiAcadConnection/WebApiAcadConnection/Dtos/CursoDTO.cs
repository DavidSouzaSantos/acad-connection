using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiAcadConnection.DTOs
{
    ///<summary>
    ///Classe Curso
    ///</summary>
    public class CursoDTO
    {
        ///<summary>
        ///Classe Curso
        ///</summary>
        public int? Codigo { get; set; }

        ///<summary>
        ///Nome do Curso
        ///</summary>
        [Required]
        [MaxLength(100, ErrorMessage = "O Nome deve ter no maxímo 100 caracteres")]
        public string Nome { get; set; }

        ///<summary>
        ///Descrição do Curso
        ///</summary>
        [Required]
        [MaxLength(250, ErrorMessage = "O Descrição deve ter no maxímo 100 caracteres")]
        public string Descricao { get; set; }

        ///<summary>
        ///Data do Inicio do Curso
        ///</summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        ///<summary>
        ///Data do Termino do Curso
        ///</summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataFim { get; set; }

        ///<summary>
        ///Duração do Curso
        ///</summary>
        public int Duracao { get; set; }

        ///<summary>
        ///Professor do Curso
        ///</summary>
        [Required]
        public ProfessorDTO Professor { get; set; }

        ///<summary>
        ///Classe Curso
        ///</summary>
        [Required]
        public DisciplinaDTO Disciplina { get; set; }

        ///<summary>
        ///Instituição Curso
        ///</summary>
        [Required]
        public InstituicaoDTO Instituicao { get; set; }

        ///<summary>
        ///Data de Criação Curso
        ///</summary>
        public DateTime DataCriacao { get; set; }

    }
}