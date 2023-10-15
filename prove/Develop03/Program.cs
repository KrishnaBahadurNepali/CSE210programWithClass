using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        while (!scripture.AllWordsHidden)
        {
            Console.Clear();
            scripture.DisplayWithHiddenWords();
            Console.Write("\nPress Enter to continue, or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWord();
        }
    }
}

class Scripture
{
    private readonly string reference;
    private readonly List<Word> words;
    private readonly Random random = new();

    public bool AllWordsHidden => words.All(word => word.IsHidden);

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void DisplayWithHiddenWords()
    {
        Console.WriteLine(reference);
        StringBuilder displayText = new();

        foreach (var word in words)
        {
            displayText.Append(word.IsHidden ? "____ " : word.Text + " ");
        }

        Console.WriteLine(displayText.ToString());
    }

    public void HideRandomWord()
    {
        List<Word> hiddenWords = words.Where(word => word.IsHidden).ToList();

        if (hiddenWords.Count > 0)
        {
            int index = random.Next(hiddenWords.Count);
            hiddenWords[index].IsHidden = false;
        }
    }
}

class Word
{
    public string Text { get; }
    public bool IsHidden { get; set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = true;
    }
}