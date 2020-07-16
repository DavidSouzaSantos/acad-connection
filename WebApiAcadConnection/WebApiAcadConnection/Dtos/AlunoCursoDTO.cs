using System.ComponentModel.DataAnnotations;

namespace WebApiAcadConnection.Dtos
{
    public class AlunoCursoDTO
    {
        [Required]
        public AlunoDTO Aluno { get; set; }

        [Required]
        public CursoDTO Curso { get; set; }
    }
}