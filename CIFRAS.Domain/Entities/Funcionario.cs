namespace CIFRAS.Domain.Entities
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public Cargo Cargo { get; set; }
        public bool Ativo { get; set; } = true;

        public void Excluir()
        {
            Ativo = false;
        }
    }
}