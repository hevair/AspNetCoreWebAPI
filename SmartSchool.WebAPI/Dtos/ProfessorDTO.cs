namespace SmartSchool.WebAPI.Dtos
{
    public class ProfessorDTO
    {
        public int Id { get; set; }
        public int Registro { get; set; }
        public string Nome { get; set; } 
        public string Telefone { get; set; }
        public DateTime DataInit { get; set; } 
        public bool Activo { get; set; }
    }
}