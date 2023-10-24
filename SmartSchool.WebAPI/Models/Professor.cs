namespace SmartShool.WebAPI.Models
{
    public class Professor
    {
        public Professor() { }
        public Professor(int id, int registro, string nome, string sobreNome) 
        {
            this.Id = id;
            this.Registro = registro;
            this.Nome = nome;
            this.SobreNome = sobreNome;
        }
        public int Id { get; set; }
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataInit { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Activo { get; set; } = true;
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}