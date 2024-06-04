using System;
using System.Collections.Generic;

// Base Activity Class
public abstract class Activity
{
    private DateTime date;
    private int minutes;

    public Activity(DateTime date, int minutes)
    {
        this.date = date;
        this.minutes = minutes;
    }

    public DateTime GetDate() => date;
    public int GetMinutes() => minutes;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{date.ToString("dd MMM yyyy")} {this.GetType().Name} ({minutes} min): Distance {GetDistance():0.0} miles, Speed {GetSpeed():0.0} mph, Pace {GetPace():0.0} min per mile";
    }
}

// Derived Running Class
public class Running : Activity
{
    private double distance;

    public Running(DateTime date, int minutes, double distance)
        : base(date, minutes)
    {
        this.distance = distance;
    }

    public override double GetDistance() => distance;

    public override double GetSpeed() => (distance / GetMinutes()) * 60;

    public override double GetPace() => GetMinutes() / distance;
}

// Derived Cycling Class
public class Cycling : Activity
{
    private double speed;

    public Cycling(DateTime date, int minutes, double speed)
        : base(date, minutes)
    {
        this.speed = speed;
    }

    public override double GetDistance() => (speed / 60) * GetMinutes();

    public override double GetSpeed() => speed;

    public override double GetPace() => 60 / speed;
}

// Derived Swimming Class
public class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        this.laps = laps;
    }

    public override double GetDistance() => laps * 50 / 1000.0 * 0.62;

    public override double GetSpeed() => (GetDistance() / GetMinutes()) * 60;

    public override double GetPace() => GetMinutes() / GetDistance();
}

// Main Program
public class Program
{
    public static void Main(string[] args)
    {
        // Create activities
        var running = new Running(new DateTime(2024, 6, 3), 30, 3.0);
        var cycling = new Cycling(new DateTime(2024, 6, 3), 45, 15.0);
        var swimming = new Swimming(new DateTime(2024, 6, 3), 20, 40);

        // Add activities to list
        var activities = new List<Activity> { running, cycling, swimming };

        // Display summaries for each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
