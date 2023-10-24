using Microsoft.EntityFrameworkCore;
using SmartShool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class RepositoryProfessor : IRepositoryProfessor
    {
        private readonly SmartContext _context;

        public RepositoryProfessor(SmartContext context)
        {
            _context = context;
        }


        public IEnumerable<Professor> GetAllProfessores(bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;
               
                query =  query.Include(p => p.Disciplinas)
                                .ThenInclude(ad => ad.AlunoDisciplinas)
                                .ThenInclude(a => a.Aluno);
                 query.AsNoTracking().OrderBy(o => o);

                 return query.AsNoTracking().OrderBy(o => o).ToList();
        }

        public IEnumerable<Professor> GetAllProfessoresBydisciplina(int disciplinaId, bool includeAluno = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Professor> GetProfessoresById(int alunoId, bool includeAluno = false)
        {
            throw new NotImplementedException();
        }

    }
}