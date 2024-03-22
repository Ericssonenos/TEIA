using Microsoft.AspNetCore.Mvc;
using TeiaC153201.Models;

namespace TeiaC153201.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TEIAController : ControllerBase
    {

        [HttpPost(Name = "TEIA")]
        // estou usando Jobject para certificar que o retorno será Json
        public IActionResult Post([FromBody] palindromo dados)
        {
            if (dados.texto == null || dados.texto.Length == 0)
            {
                return BadRequest("Parâmetros texto é obrigatorio");
            }

            // Verifica se a string é um palíndromo
            bool palindromo = dados.IsPalindrome();

            // Conta a ocorrência de cada caractere
            Dictionary<char, int> charCount = dados.ContarCaracter();

            // Monta o objeto de resposta
            var response = new
            {
                palindromo = palindromo,
                ocorrencias_caracteres = charCount
            };

            return Ok(response);
        }
    }
}