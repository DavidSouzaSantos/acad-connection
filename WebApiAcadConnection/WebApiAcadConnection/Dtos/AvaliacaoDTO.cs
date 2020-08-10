using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiAcadConnection.DTOs
{
    ///<summary>
    ///Classe Avaliação
    ///</summary>
    public class AvaliacaoDTO
    {
        ///<summary>
        ///Classe Avaliação
        ///</summary>
        public int? Codigo { get; set; }

        ///<summary>
        ///Nome da Avaliação
        ///</summary>
        [Required]
        [MaxLength(100, ErrorMessage = "O Nome deve ter no maxímo 100 caracteres")]
        public string Nome { get; set; }

        ///<summary>
        ///Descição da Avaliação
        ///</summary>
        [Required]
        [MaxLength(250, ErrorMessage = "O Descrição deve ter no maxímo 100 caracteres")]
        public string Descricao { get; set; }

        ///<summary>
        ///Peso da Nota Avaliação
        ///</summary>
        public int Peso { get; set; }

        ///<summary>
        ///Curso da Avaliação
        ///</summary>
        [Required]
        public CursoDTO Curso { get; set; }

        ///<summary>
        ///Data de Criação Avaliação
        ///</summary>
        public DateTime DataCriacao { get; set; }
    }
}