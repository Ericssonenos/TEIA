using Microsoft.AspNetCore.Mvc;
using TeiaC153201.Models;


namespace TeiaC153201.Controllers
{
    [ApiController]
    [Route("api")]
    // Implementação das operações dentro do metodo post
    // Tirei o nome do Controller para Seguir especificação de exemplo : http://seruservidro.com/api/manipulacao-string
    public class TEIAController : ControllerBase
    {
        // Seguir especificação de exemplo : http://seruservidro.com/api/manipulacao-string
        [HttpPost("manipulacao-string")]
        public IActionResult Post([FromBody] palindromo dados)
        {
            // foi atribuido a camada models para melhorar a legibilidade do código

            // tratamento de casos de strings vazias ou nulas
            if (dados.texto == null || dados.texto.Length == 0)
            {
                return BadRequest("Parâmetros texto é obrigatorio");
            }

            // Verifica se a string é um palíndromo
            bool palindromo = dados.IsPalindrome();

            // Conta a ocorrência de cada caractere da string
            // Foi o utilizado o Char para melhor eficência da solução em termos de tempo de execuçao e uso da memómria
            Dictionary<char, int> charCount = dados.ContarCaracter();

            // Monta o objeto de resposta
            var resposta = new
            {
                palindromo = palindromo,
                ocorrencias_caracteres = charCount
            };

            return Ok(resposta);
        }
    }
}