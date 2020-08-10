using System.ComponentModel.DataAnnotations;

namespace WebApiAcadConnection.DTOs
{
    ///<summary>
    ///Classe Disciplina
    ///</summary>
    public class DisciplinaDTO
    {
        ///<summary>
        ///Código da Disciplina
        ///</summary>
        public int? Codigo { get; set; }

        ///<summary>
        ///Nome da Disciplina
        ///</summary>
        [Required]
        [MaxLength(150, ErrorMessage = "O Nome deve ter no maxímo 150 caracteres")]
        public string Nome { get; set; }

        ///<summary>
        ///Instituição da Disciplina
        ///</summary>
        [Required]
        public InstituicaoDTO Institucao { get; set; }

    }
}