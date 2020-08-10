using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApiAcadConnection.DTOs
{
    ///<summary>
    ///Classe de relação de aluno e curso
    ///</summary>
    public class AlunoCursoDTO
    {
        ///<summary>
        ///Aluno
        ///</summary>
        [Required]
        public AlunoDTO Aluno { get; set; }

        ///<summary>
        ///Curso
        ///</summary>
        [Required]
        public CursoDTO Curso { get; set; }

        ///<summary>
        ///Relação Ativa
        ///</summary>
        [DefaultValue(true)]
        public bool Ativo { get; set; }
    }
}