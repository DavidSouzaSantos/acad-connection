using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiAcadConnection.DTOs
{
    ///<summary>
    ///Classe Nota
    ///</summary>
    public class NotaDTO
    {
        ///<summary>
        ///Código da Nota
        ///</summary>
        public int? Codigo { get; set; }

        ///<summary>
        ///Nota
        ///</summary>
        [Required]
        [Range(0, 10, ErrorMessage = "A nota deve ser de 0 a 10")]
        public int Nota { get; set; }

        ///<summary>
        ///Avaliação relacionado a Nota
        ///</summary>
        [Required]
        public AvaliacaoDTO Avaliacao { get; set; }

        ///<summary>
        ///Aluno relacionado a Nota
        ///</summary>
        [Required]
        public AlunoDTO Aluno { get; set; }

        ///<summary>
        ///Data da Criação da Nota
        ///</summary>
        public DateTime DataCriacao { get; set; }
    }
}