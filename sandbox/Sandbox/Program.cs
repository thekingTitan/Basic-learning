using System;
using System.Collections.Generic;
using System.Threading;

abstract class MindfulnessActivity
{
    protected string Name { get; set; }
    protected string Description { get; set; }

    public MindfulnessActivity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void Start(int duration)
    {
        Console.WriteLine($"Starting {Name} activity:");
        Console.WriteLine(Description);
        Pause(3);
        Perform(duration);
        Console.WriteLine($"Good job! You completed the {Name} activity for {duration} seconds.");
    }

    protected void Pause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine($"Pausing for {i} seconds...");
            Thread.Sleep(1000);
        }
    }

    protected abstract void Perform(int duration);
}

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void Perform(int duration)
    {
        while (duration > 0)
        {
            Console.WriteLine("Breathe in...");
            Pause(3);
            Console.WriteLine("Breathe out...");
            Pause(3);
            duration -= 6;
        }
    }
}

class ReflectionActivity : MindfulnessActivity
{
    private static readonly string[] Prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] Questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    protected override void Perform(int duration)
    {
        while (duration > 0)
        {
            string prompt = Prompts[new Random().Next(0, Prompts.Length)];
            Console.WriteLine(prompt);
            Pause(3);
            foreach (string question in Questions)
            {
                Console.WriteLine(question);
                Pause(5);
            }
            duration -= 30;
        }
    }
}

class ListingActivity : MindfulnessActivity
{
    private static readonly string[] Prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    protected override void Perform(int duration)
    {
        while (duration > 0)
        {
            string prompt = Prompts[new Random().Next(0, Prompts.Length)];
            Console.WriteLine(prompt);
            Pause(3);
            Console.WriteLine("Begin listing...");
            List<string> items = new List<string>();
            while (true)
            {
                Console.Write("Enter an item or 'done' to finish: ");
                string item = Console.ReadLine();
                if (item.ToLower() == "done")
                    break;
                items.Add(item);
            }
            Console.WriteLine($"Number of items listed: {items.Count}");
            duration -= items.Count * 5; // Subtract 5 seconds per item listed
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Mindfulness App");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an activity or '4' to exit: ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                BreathingActivity activity = new BreathingActivity();
                Console.Write("Enter the duration in seconds: ");
                int duration = int.Parse(Console.ReadLine());
                activity.Start(duration);
            }
            else if (choice == "2")
            {
                ReflectionActivity activity = new ReflectionActivity();
                Console.Write("Enter the duration in seconds: ");
                int duration = int.Parse(Console.ReadLine());
                activity.Start(duration);
            }
            else if (choice == "3")
            {
                ListingActivity activity = new ListingActivity();
                Console.Write("Enter the duration in seconds: ");
                int duration = int.Parse(Console.ReadLine());
                activity.Start(duration);
            }
            else if (choice == "4")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please choose again.");
            }
        }
    }
}

// My countdown is how i showed creativity.... i decided to use another method of countdown//