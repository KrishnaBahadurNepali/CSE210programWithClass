using System;
using System.Data;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string first = Console.ReadLine();
        Console.Write("What is your last name? ");
        string last = Console.ReadLine();
        DateTime current_date_time=DateTime.Now;
        Console.Write($"Today date is:{current_date_time}\n");
        Console.WriteLine($"Your name is {last}, {first} {last}.");
        Console.WriteLine("Sorry for the late assignment due to my personal problems.");
    }
}