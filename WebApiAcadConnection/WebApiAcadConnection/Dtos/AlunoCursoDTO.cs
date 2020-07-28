using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApiAcadConnection.DTOs
{
    public class AlunoCursoDTO
    {
        [Required]
        public AlunoDTO Aluno { get; set; }

        [Required]
        public CursoDTO Curso { get; set; }

        [DefaultValue(true)]
        public bool Ativo { get; set; }
    }
}