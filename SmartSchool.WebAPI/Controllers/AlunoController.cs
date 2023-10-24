using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Dtos;
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
        private readonly IMapper _mapper;

        public AlunoController(SmartContext context, IRepository repository, IRepositoryAluno repoAluno, IMapper mapper) {
            _context = context;
            _repo = repository;
            _repoAluno = repoAluno;
            _mapper = mapper;


        }

        [HttpGet]
        public IActionResult Get(){

            var alunos = _repoAluno.GetAllAlunos();
            var alunoDTO  = _mapper.Map<IEnumerable<AlunoDTO>>(alunos);
            return Ok(alunoDTO);
        }

         [HttpGet("{id}")]
        public IActionResult GetById(int id){

             var aluno = _repoAluno.GetAlunoById(id);
            var alunoDTO  = _mapper.Map<AlunoDTO>(aluno);
            return Ok(alunoDTO);
        }

        [HttpPost()]
        public IActionResult Post(AlunoRegistrarDTO alunoDTO){

            var aluno = _mapper.Map<Aluno>(alunoDTO);

            _repo.Add(aluno);
            if(_repo.SaveChanges()) return Created($"/api/aluno/{alunoDTO.Id}", _mapper.Map<AlunoDTO>(aluno));
            
            return BadRequest("Não foi possivel salvar Aluno");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoRegistrarDTO alunoDTO){

            var aluno = _repoAluno.GetAlunoById(id);

            if(aluno == null) return BadRequest("Não foi possivel Encontrar Aluno");

            aluno = _mapper.Map<Aluno>(alunoDTO);

             _repo.Update(id, aluno);
            if(_repo.SaveChanges()) return Created($"/api/aluno/{alunoDTO.Id}", _mapper.Map<AlunoDTO>(aluno));

            
            return BadRequest("Não foi possivel salvar Aluno");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, AlunoRegistrarDTO alunoDTO){

            var aluno = _repoAluno.GetAlunoById(id);

            if(aluno == null) return BadRequest("Não foi possivel Encontrar Aluno");

             _mapper.Map(alunoDTO, aluno);
             
            _repo.Update(id,aluno);
            if(_repo.SaveChanges()) return Created($"/api/aluno/{alunoDTO.Id}", _mapper.Map<AlunoDTO>(aluno));
            
            return BadRequest("Não foi possivel Atualizar Aluno");
        }

        [HttpDelete("{id}")]
         public IActionResult Delete(int id, AlunoDTO alunoDTO){
            var aluno = _repoAluno.GetAlunoById(id);

            if(aluno == null) return BadRequest("Não foi possivel Encontrar Aluno");

             _mapper.Map(alunoDTO, aluno);

             _repo.Delete(id,aluno);
            if(_repo.SaveChanges()) return Ok(_mapper.Map<AlunoDTO>(aluno));
            
            return BadRequest("Não foi possivel Deletar Aluno");
        }
    }
}