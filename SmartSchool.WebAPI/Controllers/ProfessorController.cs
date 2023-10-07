using Microsoft.AspNetCore.Mvc;

namespace SmartShool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController: ControllerBase
    {
        public ProfessorController()
        {
            
        }

        [HttpGet]
        public IActionResult Get(){
            return Ok("Professor");
        }
    }
}