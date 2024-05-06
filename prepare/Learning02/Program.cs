using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
    public string Emotion { get; set; }

    public JournalEntry(string prompt, string response, string date, string emotion)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
        Emotion = emotion;
    }

    public override string ToString()
    {
        return $"{Date}: {Prompt}\nEmotion: {Emotion}\n{Response}\n";
    }
}

class Journal
{
    private List<JournalEntry> entries;

    public Journal()
    {
        entries = new List<JournalEntry>();
    }

    public void AddEntry(JournalEntry entry)
    {
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string fileName)
    {
        try
        {
            string directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string fullPath = Path.Combine(directory, fileName);

            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Emotion}|{entry.Response}");
                }
            }
            Console.WriteLine("Journal saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    public void LoadFromFile(string fileName)
    {
        try
        {
            string directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string fullPath = Path.Combine(directory, fileName);

            entries.Clear();
            using (StreamReader reader = new StreamReader(fullPath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    entries.Add(new JournalEntry(parts[1], parts[3], parts[0], parts[2]));
                }
            }
            Console.WriteLine("Journal loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }

    public string GetRandomPrompt()
    {
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Random random = new Random();
        int index = random.Next(prompts.Length);
        return prompts[index];
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal entries");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");

            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = journal.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("Enter your response: ");
                    string response = Console.ReadLine();
                    Console.Write("Enter the date (MM/DD/YYYY): ");
                    string date = Console.ReadLine();
                    Console.Write("Enter your emotion for the day: ");
                    string emotion = Console.ReadLine();

                    JournalEntry entry = new JournalEntry(prompt, response, date, emotion);
                    journal.AddEntry(entry);
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter file name to save: ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveToFile(saveFileName);
                    break;
                case "4":
                    Console.Write("Enter file name to load: ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadFromFile(loadFileName);
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

// I showed creativity by adding to my program codes that ask for the user emotions and also displaying 
//it alongside the output.