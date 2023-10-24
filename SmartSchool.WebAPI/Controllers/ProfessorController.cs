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
    public class ProfessorController: ControllerBase
    {
        private readonly SmartContext _context;
        private readonly IRepository _repo;
        private readonly IRepositoryProfessor _repoProf;
        private readonly IMapper _mapper;

        public ProfessorController(SmartContext context, IRepository repository, IRepositoryProfessor repoProf, IMapper mapper) {
            _context = context;
            _repo = repository;
            _repoProf = repoProf;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult Get(){
            var prof = _repoProf.GetAllProfessores();
            var profDTO = _mapper.Map<IEnumerable<ProfessorDTO>>(prof);
            return Ok(profDTO);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            var prof = _context.Professores.FirstOrDefault(p => p.Id == id);
            if(prof == null) return BadRequest("Professor não encontrado");
            var profDTO = _mapper.Map<ProfessorDTO>(prof);
            return Ok(profDTO);
        }

        [HttpPost()]
        public  IActionResult Post(ProfessorRegistrarDTO professorDTO){
            
            var prof = _mapper.Map<Professor>(professorDTO);
             _context.Add(prof);
             _context.SaveChanges();

            return Ok(prof);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorDTO professorDTO){
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);

            if(prof == null) return BadRequest("Professor não encontrado");

            var profDTO = _mapper.Map<Professor>(professorDTO);
            _context.Update(profDTO);
            _context.SaveChanges();

            return Ok(profDTO);

        }

        [HttpDelete("{id}")]
         public IActionResult Delete(int id, Professor professor){
            var prof = _context.Alunos.FirstOrDefault(a => a.Id == id);

            if(prof == null){
                return BadRequest("Professor não existe");
            }
            
            _context.Remove(prof);
            _context.SaveChanges();
            return Ok(professor);
        }
    }
}