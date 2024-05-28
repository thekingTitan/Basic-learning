using System;
using System.Collections.Generic;

// Base class for all goals
public abstract class Goal
{
    protected string name;
    protected int points;
    protected string description;

    public Goal(string name, int points, string description)
    {
        this.name = name;
        this.points = points;
        this.description = description;
    }

    public abstract void RecordEvent();

    public string Name { get { return name; } }
    public int Points { get { return points; } }
    public string Description { get { return description; } }
}

// Simple goal that can be marked complete
public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points, string description) 
        : base(name, points, description) { }

    public override void RecordEvent()
    {
        Console.WriteLine($"Completed {name} and earned {points} points!");
    }
}

// Eternal goal that is never complete
public class EternalGoal : Goal
{
    public EternalGoal(string name, int points, string description) 
        : base(name, points, description) { }

    public override void RecordEvent()
    {
        Console.WriteLine($"Recorded {name} and earned {points} points!");
    }
}

// Checklist goal that must be accomplished a certain number of times
public class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;

    public ChecklistGoal(string name, int points, string description, int targetCount) 
        : base(name, points, description)
    {
        this.targetCount = targetCount;
        this.currentCount = 0;
    }

    public override void RecordEvent()
    {
        currentCount++;
        if (currentCount == targetCount)
        {
            Console.WriteLine($"Completed {name} and earned {points * targetCount} points!");
        }
        else
        {
            Console.WriteLine($"Recorded {name} and earned {points} points! ({currentCount}/{targetCount})");
        }
    }

    public int CurrentCount { get { return currentCount; } }
    public int TargetCount { get { return targetCount; } }
}

// Creative goal that requires user rating for creative effort
public class CreativeGoal : Goal
{
    public CreativeGoal(string name, int points, string description)
        : base(name, points, description) { }

    public override void RecordEvent()
    {
        Console.WriteLine($"Completed creative goal: {name}");
        Console.WriteLine("Please rate your creative effort from 1 to 10:");
        int rating;
        while (!int.TryParse(Console.ReadLine(), out rating) || rating < 1 || rating > 10)
        {
            Console.WriteLine("Invalid rating. Please enter a number between 1 and 10.");
        }
        int finalPoints = points + rating;
        Console.WriteLine($"You rated your creativity as {rating}/10. Earned {finalPoints} points!");
    }
}

// Program class to manage goals and user score
public class EternalQuest
{
    private List<Goal> goals;
    private int score;

    public EternalQuest()
    {
        goals = new List<Goal>();
        score = 0;
    }

    public void CreateGoal(string name, int points, string description, GoalType type)
    {
        Goal goal;
        switch (type)
        {
            case GoalType.Simple:
                goal = new SimpleGoal(name, points, description);
                break;
            case GoalType.Eternal:
                goal = new EternalGoal(name, points, description);
                break;
            case GoalType.Checklist:
                goal = new ChecklistGoal(name, points, description, 5); // default target count of 5
                break;
            case GoalType.Creative:
                goal = new CreativeGoal(name, points, description);
                break;
            default:
                Console.WriteLine("Invalid goal type");
                return;
        }
        goals.Add(goal);
    }

    public void RecordEvent(string name)
    {
        Goal goal = goals.Find(g => g.Name == name);
        if (goal != null)
        {
            goal.RecordEvent();
            score += goal.Points;
        }
        else
        {
            Console.WriteLine("Goal not found");
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Goals:");
        foreach (Goal goal in goals)
        {
            if (goal is ChecklistGoal checklistGoal)
            {
                Console.WriteLine($"[{checklistGoal.CurrentCount}/{checklistGoal.TargetCount}] {goal.Name} ({goal.Points} points) - {goal.Description}");
            }
            else
            {
                Console.WriteLine($"[X] {goal.Name} ({goal.Points} points) - {goal.Description}");
            }
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Score: {score} points");
    }

    public enum GoalType { Simple, Eternal, Checklist, Creative }
}

class Program
{
    static void Main(string[] args)
    {
        EternalQuest quest = new EternalQuest();
        bool quit = false;

        Console.WriteLine("Welcome to Eternal Quest!");

        while (!quit)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");

            Console.Write("Enter your choice: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    CreateNewGoal(quest);
                    break;
                case 2:
                    quest.DisplayGoals();
                    break;
                case 3:
                    RecordEvent(quest);
                    break;
                case 4:
                    Console.WriteLine("Saving goals...");
                    // Add code to save goals
                    break;
                case 5:
                    Console.WriteLine("Loading goals...");
                    // Add code to load goals
                    break;
                case 6:
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                    break;
            }
        }
    }

    static void CreateNewGoal(EternalQuest quest)
    {
        Console.WriteLine("\nCreate New Goal:");
        Console.WriteLine("Enter goal name:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter points for completing the goal:");
        int points = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter a description for the goal:");
        string description = Console.ReadLine();
        Console.WriteLine("Select goal type (simple, eternal, checklist, or creative):");
        string typeInput = Console.ReadLine().ToLower();
        EternalQuest.GoalType type;
        switch (typeInput)
        {
            case "simple":
                type = EternalQuest.GoalType.Simple;
                break;
            case "eternal":
                type = EternalQuest.GoalType.Eternal;
                break;
            case "checklist":
                type = EternalQuest.GoalType.Checklist;
                break;
            case "creative":
                type = EternalQuest.GoalType.Creative;
                break;
            default:
                Console.WriteLine("Invalid goal type. Creating as simple goal.");
                type = EternalQuest.GoalType.Simple;
                break;
        }
        quest.CreateGoal(name, points, description, type);
        Console.WriteLine("Goal created successfully!");
    }

    static void RecordEvent(EternalQuest quest)
    {
        Console.WriteLine("\nRecord Event:");
        Console.WriteLine("Enter the name of the goal you completed:");
        string eventName = Console.ReadLine();
        quest.RecordEvent(eventName);
    }
}

// creativity was shown
// i had my program listing "creativity" among the options of (simple, eternal or checklist) and also asking the user to rate their craetivty.
// the program the sum up the rating of the user along side with the point earn from doin the activity.