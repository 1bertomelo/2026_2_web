using Exemplo01.Validations;
using System.ComponentModel.DataAnnotations;

namespace Exemplo01.Models
{
    //classe anemica
    public class Aluno
    {

        //if (string.IsNullOrEmpty(aluno.Nome))
        //    return BadRequest("Nome do aluno é obrigatório");
        [StringLength(50, ErrorMessage = "Nome deve ter no máximo 50 caracteres")]
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "RA é obrigatório")]
        public string RA { get; set; }
        [IdadeValidation(ErrorMessage = "Idade invalida")]
        public int idade { get; set; }
    }
}
