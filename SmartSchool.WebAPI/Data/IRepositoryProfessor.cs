using SmartShool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepositoryProfessor
    {
        public IEnumerable<Professor> GetAllProfessores(bool includeAluno = false);
        public IEnumerable<Professor> GetProfessoresById(int alunoId, bool includeAluno = false);
        public IEnumerable<Professor> GetAllProfessoresBydisciplina(int disciplinaId, bool includeAluno = false);
    }
}