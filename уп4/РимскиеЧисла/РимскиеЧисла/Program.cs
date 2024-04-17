using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите римское число: ");
        string romanNumeral = Console.ReadLine();

        int decimalValue = 0;
        int prevValue = 0;

        int length = romanNumeral.Length;

        for (int i = length - 1; i >= 0; --i)
        {
            int currentValue = 0;

            switch (romanNumeral[i])
            {
                case 'I':
                    currentValue = 1;
                    break;
                case 'V':
                    currentValue = 5;
                    break;
                case 'X':
                    currentValue = 10;
                    break;
                case 'L':
                    currentValue = 50;
                    break;
                case 'C':
                    currentValue = 100;
                    break;
                case 'D':
                    currentValue = 500;
                    break;
                case 'M':
                    currentValue = 1000;
                    break;
                default:
                {
                    Console.Write("Ошибка: неверный символ в римском числе.\n");
                    return;
                }
            }

            if (currentValue < prevValue)
            {
                decimalValue -= currentValue;
            }
            else
            {
                decimalValue += currentValue;
            }

            prevValue = currentValue;
        }

        Console.WriteLine($"Десятичное знаечение: {decimalValue}");
    }
}