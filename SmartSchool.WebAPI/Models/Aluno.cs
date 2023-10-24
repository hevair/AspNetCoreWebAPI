namespace SmartShool.WebAPI.Models
{
    public class Aluno
    {
        public Aluno() { }

        
        public Aluno(int id, int matricula, string nome, string sobreNome, string telefone, DateTime dataNasc) 
        {
            this.Id = id;
                this.Matricula = matricula;
                this.Nome = nome;
                this.SobreNome = sobreNome;
                this.Telefone = telefone;
                this.DataNasc = dataNasc;
               
        }
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public DateTime DataInit { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Activo { get; set; } = true;
        public IEnumerable<AlunoDisciplina> AlunoDiciplinas { get; set; }
    }
}