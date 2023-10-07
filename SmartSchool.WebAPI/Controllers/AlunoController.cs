using Microsoft.AspNetCore.Mvc;
using SmartShool.WebAPI.Models;

namespace SmartShool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {

        public List<Aluno> alunos = new List<Aluno>(){
            new Aluno(){
                Id = 1,
                Nome = "Hevair",
                SobreNome = "Rodrigues",
                Telefone = "123456789"
            },
            new Aluno(){
                Id = 2,
                Nome = "Mariazinha",
                SobreNome = "Joaninha",
                Telefone = "123456789"
            },
            new Aluno(){
                Id = 3,
                Nome = "Joaozinho",
                SobreNome = "Da mata",
                Telefone = "123456789"
            }
        };

        public AlunoController() {}

        [HttpGet]
        public IActionResult Get(){
            return Ok(alunos);
        }

         [HttpGet("{id}")]
        public IActionResult GetById(int id){

            var aluno = alunos.FirstOrDefault(a => a.Id == id);
            if(aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }

        [HttpPost("{id}")]
        public IActionResult Post(Aluno aluno){
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno){
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno){
            return Ok(aluno);
        }
    }
}