using System;
using System.Text;

// Address Class
public class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public override string ToString()
    {
        return $"{street}, {city}, {state}, {country}";
    }
}

// Base Event Class
public abstract class Event
{
    private string title;
    private string description;
    private DateTime date;
    private string time;
    private Address address;

    public Event(string title, string description, DateTime date, string time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public string GetStandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time}\nAddress: {address}";
    }

    public abstract string GetFullDetails();
    public abstract string GetShortDescription();

    protected string GetTitle()
    {
        return title;
    }

    protected DateTime GetDate()
    {
        return date;
    }
}

// Derived Lecture Class
public class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nEvent Type: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
    }

    public override string GetShortDescription()
    {
        return $"Event Type: Lecture\nTitle: {GetTitle()}\nDate: {GetDate().ToShortDateString()}";
    }
}

// Derived Reception Class
public class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nEvent Type: Reception\nRSVP Email: {rsvpEmail}";
    }

    public override string GetShortDescription()
    {
        return $"Event Type: Reception\nTitle: {GetTitle()}\nDate: {GetDate().ToShortDateString()}";
    }
}

// Derived OutdoorGathering Class
public class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string description, DateTime date, string time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        this.weatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nEvent Type: Outdoor Gathering\nWeather Forecast: {weatherForecast}";
    }

    public override string GetShortDescription()
    {
        return $"Event Type: Outdoor Gathering\nTitle: {GetTitle()}\nDate: {GetDate().ToShortDateString()}";
    }
}

// Main Program
public class Program
{
    public static void Main(string[] args)
    {
        // Create addresses
        var address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        var address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");

        // Create events
        var lecture = new Lecture("Tech Talk", "A talk on the latest in technology", new DateTime(2024, 6, 15), "10:00 AM", address1, "Dr. Smith", 100);
        var reception = new Reception("Networking Event", "An event to network with industry professionals", new DateTime(2024, 7, 20), "6:00 PM", address2, "rsvp@example.com");
        var outdoorGathering = new OutdoorGathering("Summer Picnic", "A fun outdoor picnic", new DateTime(2024, 8, 10), "12:00 PM", address1, "Sunny with a chance of clouds");

        // Display event details
        DisplayEventDetails(lecture);
        DisplayEventDetails(reception);
        DisplayEventDetails(outdoorGathering);
    }

    private static void DisplayEventDetails(Event ev)
    {
        Console.WriteLine(ev.GetStandardDetails());
        Console.WriteLine(ev.GetFullDetails());
        Console.WriteLine(ev.GetShortDescription());
        Console.WriteLine();
    }
}
