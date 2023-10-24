using SmartSchool.WebAPI.Models;

namespace SmartShool.WebAPI.Models
{
    public class AlunoCurso
    {
        public AlunoCurso()
        {

        }

        public AlunoCurso(int alunoId, int cursoId)
        {
            this.AlunoId = alunoId;
            this.CursoId = CursoId;
        }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public DateTime DataInit { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
    }
}