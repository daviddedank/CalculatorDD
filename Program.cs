using System;

namespace CalculatorDD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool open = true;
            while (open)
            {
                double result = CalculatorDD();

                if (result != double.MinValue)
                {
                    Console.WriteLine("The result is: " + result);
                }

                Console.WriteLine("Would you like to do another operation? Y/N");
                string ans = Console.ReadLine().Trim().ToUpper();
                if (ans == "YES" || ans == "Y")
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Application quitting...");
                    open = false;
                }
            }
        }

        static double CalculatorDD()
        {
            double num1 = GetValidNumber("Enter a number: ");
            double num2 = GetValidNumber("Enter another number: ");
            char sign = GetValidOperator("Enter an operator (+, -, *, x, /): ");

            double result = 0;
            switch (sign)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                case 'x':
                    result = num1 * num2;
                    break;
                case '/':
                    if (num2 == 0)
                    {
                        Console.WriteLine("Cannot divide by 0");
                        return double.MinValue;
                    }
                    result = num1 / num2;
                    break;
                default:
                    Console.WriteLine("Invalid operator.");
                    return double.MinValue;
            }
            return result;
        }

        static double GetValidNumber(string prompt)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    return Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Only numbers allowed, try again.");
                }
            }
        }

        static char GetValidOperator(string prompt)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    char sign = Convert.ToChar(Console.ReadLine().Trim());
                    if (sign == '+' || sign == '-' || sign == '*' || sign == 'x' || sign == '/')
                    {
                        return sign;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Use either +, -, *, x, or /.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Only one character allowed, try again.");
                }
            }
        }
    }
}
