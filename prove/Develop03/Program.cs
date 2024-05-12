using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        // Create a new Scripture object
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world...");

        // Continue prompting the user until all words are hidden
        while (!scripture.AllWordsHidden)
        {
            // Clear the console screen
            Console.Clear();

            // Display the scripture with hidden words
            Console.WriteLine(scripture.GetHiddenScripture());

            // Prompt the user to press enter or type "quit"
            Console.WriteLine("Press Enter to reveal more words or type 'quit' to end:");
            string input = Console.ReadLine();

            // End the program if the user types "quit"
            if (input.ToLower() == "quit")
            {
                return;
            }

            // Otherwise, hide a few more words in the scripture
            scripture.HideRandomWords();
        }

        // All words are hidden, display a random inspirational quote
        Console.Clear();
        Console.WriteLine("Congratulations! You've revealed all the words.");
        Console.WriteLine("Here's a random inspirational quote:");
        Console.WriteLine(GetRandomInspirationalQuote());
    }

    public static string GetRandomInspirationalQuote()
    {
        // List of inspirational quotes
        List<string> quotes = new List<string>
        {
            "The only way to do great work is to love what you do. - Steve Jobs",
            "Believe you can and you're halfway there. - Theodore Roosevelt",
            "You are never too old to set another goal or to dream a new dream. - C.S. Lewis",
            "The future belongs to those who believe in the beauty of their dreams. - Eleanor Roosevelt",
            "Success is not the key to happiness. Happiness is the key to success. If you love what you are doing, you will be successful. - Albert Schweitzer"
            // Add more quotes as needed
        };

        // Get a random quote
        Random rand = new Random();
        int index = rand.Next(quotes.Count);
        return quotes[index];
    }
}

// Class to represent a single word in the scripture
public class Word
{
    public string Text { get; set; }
    public bool IsHidden { get; set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }
}

// Class to represent a scripture reference (e.g., "John 3:16")
public class Reference
{
    public string Book { get; set; }
    public int Chapter { get; set; }
    public int StartVerse { get; set; }
    public int? EndVerse { get; set; }

    public Reference(string reference)
    {
        // Parse the reference string into book, chapter, and start/end verse
        // Example reference format: "John 3:16" or "Proverbs 3:5-6"
        // Implementation omitted for brevity
    }

    public override string ToString()
    {
        // Return the reference in the format "Book Chapter:StartVerse-EndVerse"
        return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
    }
}

// Class to represent a scripture passage
public class Scripture
{
    private string _text;
    private List<Word> _words;
    private Reference _reference;

    public bool AllWordsHidden => _words.All(word => word.IsHidden);

    public Scripture(string reference, string text)
    {
        _reference = new Reference(reference);
        _text = text;
        _words = _text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords()
    {
        // Get a list of visible words (i.e., words that are not yet hidden)
        var visibleWords = _words.Where(word => !word.IsHidden).ToList();

        // If there are no visible words, return early
        if (visibleWords.Count == 0)
        {
            return;
        }

        // Randomly select a word from the visible words list
        Random rand = new Random();
        int index = rand.Next(visibleWords.Count);
        visibleWords[index].IsHidden = true;
    }

    public string GetHiddenScripture()
    {
        // Return the scripture text with hidden words
        return string.Join(" ", _words.Select(word => word.IsHidden ? "_____" : word.Text));
    }
}
