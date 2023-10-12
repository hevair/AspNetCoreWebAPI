using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartShool.WebAPI.Models;

namespace SmartShool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController: ControllerBase
    {
        private readonly SmartContext _context;

        public ProfessorController(SmartContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IActionResult Get(){
            var prof = _context.professores;

            return Ok(prof);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            var prof = _context.professores.FirstOrDefault(p => p.Id == id);
            return Ok(prof);
        }

        [HttpPost()]
        public  IActionResult Post(Professor professor){

             _context.Add(professor);
             _context.SaveChanges();

            return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor){
            var prof = _context.professores.AsNoTracking().FirstOrDefault(p => p.Id == id);

            if(prof == null) return BadRequest("Professor não encontrado");

            _context.Update(professor);
            _context.SaveChanges();

            return Ok(professor);

        }

        [HttpDelete("{id}")]
         public IActionResult Delete(int id, Professor professor){
            var prof = _context.alunos.FirstOrDefault(a => a.Id == id);

            if(prof == null){
                return BadRequest("Professor não existe");
            }
            
            _context.Remove(prof);
            _context.SaveChanges();
            return Ok(professor);
        }
    }
}