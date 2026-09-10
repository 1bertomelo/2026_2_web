using Exemplo01.Models;

namespace Exemplo01.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private static List<Aluno> ListaAlunos = 
            new List<Aluno>();

        public void Atualizar(Aluno aluno)
        {
            var resultado = ObterPorRa(aluno.RA);
            ListaAlunos.Remove(resultado);
            ListaAlunos.Add(aluno);
        }

        public void Cadastrar(Aluno aluno)
        {
            ListaAlunos.Add(aluno);
        }

        public void Deletar(string ra)
        {
            var resultado = ObterPorRa(ra);
            ListaAlunos.Remove(resultado);
        }

        public Aluno ObterPorRa(string ra)
        {
           return ListaAlunos.Where(a => a.RA == ra).FirstOrDefault();  
        }

        public List<Aluno> ObterTodos()
        {
            return ListaAlunos;
        }
    }
}
