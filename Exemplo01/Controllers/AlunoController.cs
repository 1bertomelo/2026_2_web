using Exemplo01.Models;
using Exemplo01.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Exemplo01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    { 
       private readonly IAlunoRepository _alunoRepository;

        #region Métodos GET


        [HttpGet]
        [Route("Saudacao")]

        public IActionResult Saudacao(string nome)
        {
            return Ok("Oi " + nome);
        }

        [HttpGet]
        [Route("OutraSaudacao")]
        public IActionResult OutraSaudacao(string nome) 
        {
            return Ok("Fala comigooo " + nome);
        }
       

        [HttpGet]
        [Route("ListarAlunos")]
        public IActionResult ListarAlunos()
        {
            return Ok(_alunoRepository.ObterTodos());
        }

        [HttpGet]
        [Route("obterPorRa")]
        public IActionResult obterporRa(string ra)
        {
            //antes
            //var resultado = ListaAlunos.Where(a => a.RA == ra).FirstOrDefault();
            //Agora com repository
            var resultado = _alunoRepository.ObterPorRa(ra);

            if (resultado is null)
            {
                return NotFound("Aluno não encontrado");
            }
            return Ok(resultado);
        }

        #endregion
        [HttpPost]
        public IActionResult Cadastrar(Aluno aluno) 
        {
            var resultado = _alunoRepository.ObterPorRa(aluno.RA);

            if (resultado is null)
            {
                _alunoRepository.Cadastrar(aluno);
                return Ok("Cadastrado com sucesso");
            }
            return BadRequest("RA já cadastrado");

        }

        [HttpPut]
        [Route("Atualizar")]
        public IActionResult Atualizar(Aluno aluno) 
        {

            var resultado = _alunoRepository.ObterPorRa(aluno.RA);

            if (resultado is null)
                return NotFound("Ra informado não existe");
            _alunoRepository.Atualizar(aluno);
          
            return Ok("Dados atualizados com sucesso");
        }

        [HttpDelete()]
        [Route("Remover/{ra}")]
        public IActionResult Remover(string ra)
        {
            var resultado = _alunoRepository.ObterPorRa(ra);

            if ( resultado is null)
                return NotFound("Ra informado não existe");

            _alunoRepository.Deletar(ra);          
            return Ok("Aluno removido com sucesso");
        }

    }
}
