using Exemplo01.Models;

namespace Exemplo01.Repositories
{
    public interface IAlunoRepository
    {
        public void Cadastrar(Aluno aluno);
        public List<Aluno> ObterTodos();

        public void Atualizar(Aluno aluno);
        public void Deletar(string ra);

        public Aluno ObterPorRa(string ra);
    }
}
