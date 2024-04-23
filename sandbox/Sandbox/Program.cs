using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("what is your grade percentage? ");
        string grade = Console.ReadLine();
        int number = int.Parse(grade);
        string letter="";

        if (number >= 90 )
        {
            letter="A";

        }
        else if (number >= 80)
        {
            letter="B";
        }
        else if (number >= 70)
        {
            letter="C";
        }
        else if (number >= 60)
        {
            letter="D";
        }
        else 
        {
            letter="F";
        }
        Console.WriteLine($"your grade is {letter}");
        if (number >= 70)
        {
            Console.WriteLine("you passed!");
        }
        else
        {
            Console.WriteLine("good Luck Next time");
        }
    }
    
}