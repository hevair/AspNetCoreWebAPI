using Microsoft.EntityFrameworkCore;
using SmartShool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class RepositoryAluno: IRepositoryAluno
    {
         private readonly SmartContext _context;
         
        public RepositoryAluno(SmartContext context)
        {
            _context = context;
        }

         public IEnumerable<Aluno> GetAllAlunos(bool includeProfessor)
        {
                 IQueryable<Aluno> query = _context.alunos;
               
                query =  query.Include(a =>  a.AlunoDiciplinas)
                                .ThenInclude(ad => ad.Disciplina)
                                .ThenInclude(p => p.Professor);
                 query.AsNoTracking().OrderBy(o => o);

                 return query.AsNoTracking().OrderBy(o => o).ToList();
            
        }

         public IEnumerable<Aluno> GetAlunoById(int alunoId, bool includeProfessor = false)
        {
                 IQueryable<Aluno> query = _context.alunos;
               
                query =  query.Include(a =>  a.AlunoDiciplinas)
                                .ThenInclude(ad => ad.Disciplina)
                                .ThenInclude(p => p.Professor);
                 query.AsNoTracking().OrderBy(o => o);

                 return query.AsNoTracking().OrderBy(o => o)
                 .Where(a => a.Id == alunoId)
                 .ToList();
            
        }

          public IEnumerable<Aluno> GetAllAlunoBydisciplina(int disciplinaId, bool includeProfessor = false)
        {
                 IQueryable<Aluno> query = _context.alunos;
               
                query =  query.Include(a =>  a.AlunoDiciplinas)
                                .ThenInclude(ad => ad.Disciplina)
                                .ThenInclude(p => p.Professor);
                 query.AsNoTracking().OrderBy(o => o);

                 return query.AsNoTracking().OrderBy(o => o)
                 .Where(a => a.AlunoDiciplinas.Any(ad => ad.DisciplinaId == disciplinaId))
                 .ToList();
            
        }

    }
}