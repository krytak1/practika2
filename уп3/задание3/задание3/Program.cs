using System;

class Calculation
{
    private string _calculationLine;
    
    public string CalculationLine
    {
        get { return _calculationLine; }
        set { _calculationLine = value; }
    }
    
    public void SetCalculationLine(string newLine)
    {
        _calculationLine = newLine;
    }
    
    public void SetLastSymbolCalculationLine(char symbol)
    {
        _calculationLine += symbol;
    }
    
    public string GetCalculationLine()
    {
        return _calculationLine;
    }
    
    public char GetLastSymbol()
    {
        if (!string.IsNullOrEmpty(_calculationLine))
        {
            return _calculationLine[_calculationLine.Length - 1];
        }
        else
        {
            throw new InvalidOperationException("Строка пуста.");
        }
    }
    
    public void DeleteLastSymbol()
    {
        if (!string.IsNullOrEmpty(_calculationLine))
        {
            _calculationLine = _calculationLine.Substring(0, _calculationLine.Length - 1);
        }
    }
}

class Program
{
    static void Main()
    {
        Calculation calculation = new Calculation();
        
        calculation.SetCalculationLine("2 + 3 * 4");
        
        calculation.SetLastSymbolCalculationLine(' ');
        calculation.SetLastSymbolCalculationLine('=');
        
        Console.WriteLine("Строка: " + calculation.GetCalculationLine());
        
        Console.WriteLine("Последний символ: " + calculation.GetLastSymbol());
        
        calculation.DeleteLastSymbol();
        calculation.DeleteLastSymbol();

        Console.WriteLine("Строка после удаления последних двух символов: " + calculation.GetCalculationLine());
    }
}
