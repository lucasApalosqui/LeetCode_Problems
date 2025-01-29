using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string operation) => operation switch
    {
        "+" => $"{operand1} + {operand2} = {(operand1 + operand2).ToString()}",
        "*" => $"{operand1} * {operand2} = {(operand1 * operand2).ToString()}",
        "/" => (operand2 != 0) ? $"{ operand1 } / { operand2 } = { (operand1 / operand2).ToString() }" : "Division by zero is not allowed.",
        "" => throw new ArgumentException(),
        null => throw new ArgumentNullException(),
        _ => throw new ArgumentOutOfRangeException()    
    };
}

