using System;
using System.Text;

public static class Identifier
{
    private static bool IsGreekLowercase(char c) => (c >= 'α' && c <= 'ω'); //Verifica se o char é uma letra grega minuscula
    public static string Clean(string identifier)
    {
        StringBuilder sb = new StringBuilder();
        var isAfterDash = false; //verifica se o char aparece após um '-'
        foreach (var c in identifier)
        {
            sb.Append(c switch
            {
                _ when IsGreekLowercase(c) => default, //se for uma letra grega minuscula, não adiciona no stringBuilder
                _ when isAfterDash => char.ToUpperInvariant(c), //Converte o seguinte caractere para maiusculo
                _ when char.IsWhiteSpace(c) => '_', //transforma o char em '_' caso seja um espaço em branco
                _ when char.IsControl(c) => "CTRL", // Se for um char de comando substitui por CTRL
                _ when char.IsLetter(c) => c, //Adiciona o char se o mesmo for uma letra
                _ => default,
            });
            isAfterDash = c.Equals('-'); // seta a variavel como true se o char for '-'
        }
        return sb.ToString();
    }
}
