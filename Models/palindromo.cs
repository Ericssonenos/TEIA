using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeiaC153201.Models
{
    public class palindromo
    {
        public string texto { get; set; }
        public bool IsPalindrome()
        {
            // 1. Verificar se a string é um palíndromo.

            // 2. A especificações não aponta se esta string ponde contar apenas uma palavra  
            // 3. Com base na pesquisa sobre o tema, existe frases palíndromos, exe: A base do teto desaba
            // 4. Desta forma será analisado o texto como um todo.
            // 5. Neste constesto não é considerado o espaço segundo texto no site: https://www.todamateria.com.br/palindromo/
            // 6. Também não é considerado se o caracter é maículo ou minúsculo
            // 7. Diante o fato de não constar o espaço, iremos retirar e deixar tudo mínúculo 

            // 8. Com base nos parâmetros acima vamos retirar os espaços e deixar tudo minúsculo
            texto = texto.Replace(" ", "").ToLower();

            // 9. Analisar  se a string é igual à sua inversa
            // 10. Número de carateres /2 
            int nCaractersPelaMetade = texto.Length / 2;

            // 11. Loop para percorrer do cada caracter até a metade, comparando com a outra metade
            for (int i = 0; i < nCaractersPelaMetade; i++)
            {
                // 12. indiceInverso representa o indice do caracter inverso da string
                int indiceInverso = texto.Length - i - 1;
                // 13. Se o caracter do lado esquerdo for diferente do carater do lado direito retorna falso
                if (texto[i] != texto[indiceInverso])
                {
                    return false;
                }
            }
            // 14. Se passar por todo o loop com o caracter do lado direito ser igual ao lado 
            return true;

        }

        public Dictionary<char, int> ContarCaracter()
        {
            Dictionary<char, int> lista = new Dictionary<char, int>();

            foreach (char caracter in texto)
            {
                if (lista.ContainsKey(caracter))
                {
                    lista[caracter]++;
                }
                else
                {
                    lista[caracter] = 1;
                }
            }
            return lista;
        }
    }
}