namespace SmartSchool.WebAPI.Dtos
{
    public class ProfessorRegistrarDTO
    {
        public int Id { get; set; }
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataInit { get; set; }
        public DateTime? DataFim { get; set; } 
        public bool Activo { get; set; }
    }
}