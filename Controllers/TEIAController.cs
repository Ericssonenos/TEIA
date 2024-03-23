using Microsoft.AspNetCore.Mvc;
using TeiaC153201.Models;


namespace TeiaC153201.Controllers
{
    [ApiController]
    [Route("api")]
    // Implementa��o das opera��es dentro do metodo post
    // Tirei o nome do Controller para Seguir especifica��o de exemplo : http://seruservidro.com/api/manipulacao-string
    public class TEIAController : ControllerBase
    {
        // Seguir especifica��o de exemplo : http://seruservidro.com/api/manipulacao-string
        [HttpPost("manipulacao-string")]
        public IActionResult Post([FromBody] palindromo dados)
        {
            // foi atribuido a camada models para melhorar a legibilidade do c�digo

            // tratamento de casos de strings vazias ou nulas
            if (dados.texto == null || dados.texto.Length == 0)
            {
                return BadRequest("Par�metros texto � obrigatorio");
            }

            // Verifica se a string � um pal�ndromo
            bool palindromo = dados.IsPalindrome();

            // Conta a ocorr�ncia de cada caractere da string
            // Foi o utilizado o Char para melhor efic�ncia da solu��o em termos de tempo de execu�ao e uso da mem�mria
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