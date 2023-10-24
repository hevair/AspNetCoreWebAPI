using Microsoft.AspNetCore.Mvc;
using SmartShool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepositoryAluno 
    {
        public IEnumerable<Aluno> GetAllAlunos(bool includeDisciplina = false);
        public Aluno GetAlunoById(int alunoId, bool includeProfessor = false);
        public IEnumerable<Aluno> GetAllAlunoBydisciplina(int disciplinaId, bool includeProfessor = false);

    }
}