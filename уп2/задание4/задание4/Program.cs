using System;

class Counter
{
    private int _value;

    public int Value
    {
        get { return _value; }
    }

    public Counter()
    {
        _value = 0;
    }

    public Counter(int startValue)
    {
        _value = startValue;
    }

    public void Increment()
    {
        _value++;
    }

    public void Decrement()
    {
        _value--;
    }
}

class Program
{
    static void Main()
    {
        Counter counter1 = new Counter();
        
        counter1.Increment();
        counter1.Increment();
        counter1.Increment();
        
        Console.WriteLine("Текущее значение счетчика 1: " + counter1.Value);

        Counter counter2 = new Counter(10);
        
        counter2.Decrement();
        counter2.Decrement();
        counter2.Decrement();
        counter2.Decrement();
        
        Console.WriteLine("Текущее значение счетчика 2: " + counter2.Value);
    }
}