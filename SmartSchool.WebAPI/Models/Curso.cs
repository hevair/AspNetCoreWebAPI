using SmartShool.WebAPI.Models;

namespace SmartSchool.WebAPI.Models
{
    public class Curso
    {
        public Curso(){}
        public Curso(int id, String nome) 
        {
            this.Id = id;
            this.Nome = nome;
               
        }
        public int Id { get; set; }
        public String Nome { get; set; }
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}