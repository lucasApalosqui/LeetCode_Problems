//https://leetcode.com/problems/roman-to-integer
//Roman To Integer
/*
    Neste desafio aprendi melhor como manipular dicionários e laços de repetição;
    Além de manipulação de strings retirando diretamente os caracteres da string; 
*/


// Teste de execução da solução
Solution sol = new Solution();
Console.WriteLine(sol.RomanToInt("III"));

public class Solution
{
    // Criação do dicionário com a chave sendo o char do numero romano e o valor sendo o numero que ele equivale
    Dictionary<char, int> numbers = new Dictionary<char, int>()
        {
            {'I', 1 },
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

    // criação do método que transforma um romano em um inteiro
    public int RomanToInt(string s)
    {

        var result = 0;
        // laço de repetição que irá correr por cada caractere que existe na string fornecida
        for (int i = 0; i < s.Length; i++)
        {
            // lógica que verifica se o numero romano atual é menor do que o proximo numero romano, para verificar se são um numero só;
            if (i < s.Length - 1 && numbers[s[i]] < numbers[s[i + 1]])
            {
                // Adiciona ao resultado o valor do proximo numero e subtrai pelo numero atual da sequencia, gerando assim o numero real que representa o romano
                result += numbers[s[i + 1]] - numbers[s[i]];
                i++;
            }
            else
                // se o numero nao se enquadra na lógica ele é somado ao resultado final
                result += numbers[s[i]];
        }

        return result;
    }
}