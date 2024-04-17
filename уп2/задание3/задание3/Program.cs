using System;
class NumberPair
{
    public int FirstNumber { get; set; }
    public int SecondNumber { get; set; }

    public NumberPair(int firstNumber, int secondNumber)
    {
        FirstNumber = firstNumber;
        SecondNumber = secondNumber;
    }

    public void ChangeNumbers(int firstNumber, int secondNumber)
    {
        FirstNumber = firstNumber;
        SecondNumber = secondNumber;
    }

    public void PrintNumbers()
    {
        Console.WriteLine($"\nПервое число: {FirstNumber}");
        Console.WriteLine($"Второе число: {SecondNumber}");
    }

    public int GetSum()
    {
        return FirstNumber + SecondNumber;
    }

    public int GetMax()
    {
        return Math.Max(FirstNumber, SecondNumber);
    }
}

class Program
{
    static void Main()
    {
        NumberPair numbers = new NumberPair(10, 20);
        numbers.PrintNumbers();
        numbers.ChangeNumbers(30, 40);
        numbers.PrintNumbers();
        Console.WriteLine($"\nСумма значений чисел: {numbers.GetSum()}");
        Console.WriteLine($"\nНаибольшее значение: {numbers.GetMax()}");
    }
}
