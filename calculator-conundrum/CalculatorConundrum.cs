using System;

namespace CalculatorConundrum;

public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string operation)
    {
        try
        {
            if (string.IsNullOrEmpty(operation))
            {
                if (operation == string.Empty)
                {
                    throw new ArgumentException("Operation cannot be empty");
                }

                throw new ArgumentNullException(nameof(operation));
            }

            if (operation == "/" && operand2 == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }

            var result = operation switch
            {
                "+" => operand1 + operand2,
                "*" => operand1 * operand2,
                "/" => operand1 / operand2,
                _ => throw new ArgumentOutOfRangeException(nameof(operation))
            };

            return $"{operand1} {operation} {operand2} = {result}";
        }
        catch (DivideByZeroException e)
        {
            return e.Message;
        }
    }
}