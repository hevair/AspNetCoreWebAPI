using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartShool.WebAPI.Models;

namespace SmartShool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly SmartContext _context;
        private readonly IRepository _repo;
        private readonly IRepositoryAluno _repoAluno;

        public AlunoController(SmartContext context, IRepository repository, IRepositoryAluno repoAluno) {
            _context = context;
            _repo = repository;
            _repoAluno = repoAluno;

        }

        [HttpGet]
        public IActionResult Get(){
            return Ok(_repoAluno.GetAllAlunos(false));
        }

         [HttpGet("{id}")]
        public IActionResult GetById(int id){

             var aluno = _repoAluno.GetAlunoById(id);
            return Ok(aluno);
        }

        [HttpPost()]
        public IActionResult Post(Aluno aluno){

            _repo.Add(aluno);
            if(_repo.SaveChanges()) return Ok(aluno);
            
            return BadRequest("Não foi possivel salvar Aluno");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno){

             _repo.Add(aluno);
            if(_repo.SaveChanges()) return Ok(aluno);
            
            return BadRequest("Não foi possivel salvar Aluno");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno){
            _repo.Update(id,aluno);
            if(_repo.SaveChanges()) return Ok(aluno);
            
            return BadRequest("Não foi possivel Atualizar Aluno");
        }

        [HttpDelete("{id}")]
         public IActionResult Delete(int id, Aluno aluno){
             _repo.Delete(id,aluno);
            if(_repo.SaveChanges()) return Ok(aluno);
            
            return BadRequest("Não foi possivel Deletar Aluno");
        }
    }
}