namespace SmartSchool.WebAPI.Dtos
{
    public class AlunoRegistrarDTO
    {
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public DateTime DataInit { get; set; } 
        public DateTime? DataFim { get; set; }
        public bool Activo { get; set; }
    }
}