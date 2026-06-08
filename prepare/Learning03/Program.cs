using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction a = new Fraction();
        Fraction b = new Fraction(5);
        Fraction c = new Fraction(3, 4);
        Fraction d = new Fraction(1, 3);

        Console.WriteLine(a.GetFractionString());
        Console.WriteLine(a.GetDecimalValue());
        Console.WriteLine(b.GetFractionString());
        Console.WriteLine(b.GetDecimalValue());
        Console.WriteLine(c.GetFractionString());
        Console.WriteLine(c.GetDecimalValue());
        Console.WriteLine(d.GetFractionString());
        Console.WriteLine(d.GetDecimalValue());

        Fraction fraction = new Fraction();
        
        Random random = new Random();

        for (int i = 1; i <= 20; i++)
            {
                fraction.SetNumerator(random.Next(1, 11));
                fraction.SetDenominator(random.Next(1, 11));
                Console.WriteLine($"Fraction {i}: string: {fraction.GetFractionString()} Number: {fraction.GetDecimalValue()}");
            }
    }
}