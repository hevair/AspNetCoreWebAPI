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

        public AlunoController(SmartContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(){
            return Ok(_context.alunos);
        }

         [HttpGet("{id}")]
        public IActionResult GetById(int id){

            var aluno = _context.alunos.FirstOrDefault(a => a.Id == id);
            if(aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }

        [HttpPost()]
        public IActionResult Post(Aluno aluno){

            _context.Add(aluno);
            _context.SaveChanges();

            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno){

            var objectAluno = _context.alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);

            if(objectAluno == null){
                return BadRequest("Aluno não existe");
            }

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno){
            var objectAluno = _context.alunos.FirstOrDefault(a => a.Id == id);

            if(objectAluno == null){
                return BadRequest("Aluno não existe");
            }
            
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
         public IActionResult Delete(int id, Aluno aluno){
            var objectAluno = _context.alunos.FirstOrDefault(a => a.Id == id);

            if(objectAluno == null){
                return BadRequest("Aluno não existe");
            }
            
            _context.Remove(objectAluno);
            _context.SaveChanges();
            return Ok(objectAluno);
        }
    }
}