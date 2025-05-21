using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

// Represents a word in the scripture
public class ScriptureWord
{
    public string Text { get; set; }
    public bool IsHidden { get; set; }

    public ScriptureWord(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public string GetDisplayText()
    {
        return IsHidden ? new string('_', Text.Length) : Text;
    }
}

// Represents a scripture reference
public class ScriptureReference
{
    public string Book { get; set; }
    public int Chapter { get; set; }
    public int StartVerse { get; set; }
    public int? EndVerse { get; set; }

    public ScriptureReference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = verse;
    }

    public ScriptureReference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        if (EndVerse.HasValue)
        {
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
        }
        else
        {
            return $"{Book} {Chapter}:{StartVerse}";
        }
    }
}

// Represents a scripture
public class Scripture
{
    public ScriptureReference Reference { get; set; }
    public ScriptureWord[] Words { get; set; }

    public Scripture(string referenceBook, int referenceChapter, int referenceVerse, string text)
    {
        Reference = new ScriptureReference(referenceBook, referenceChapter, referenceVerse);
        Words = text.Split(' ').Select(word => new ScriptureWord(word)).ToArray();
    }

    public Scripture(string referenceBook, int referenceChapter, int referenceStartVerse, int referenceEndVerse, string text)
    {
        Reference = new ScriptureReference(referenceBook, referenceChapter, referenceStartVerse, referenceEndVerse);
        Words = text.Split(' ').Select(word => new ScriptureWord(word)).ToArray();
    }

    public void HideRandomWords(int count)
    {
        var random = new Random();
        var visibleWords = Words.Where(word => !word.IsHidden).ToArray();
        var wordsToHide = visibleWords.OrderBy(word => random.Next()).Take(count);
        foreach (var word in wordsToHide)
        {
            word.IsHidden = true;
        }
    }

    public bool AreAllWordsHidden()
    {
        return Words.All(word => word.IsHidden);
    }

    public override string ToString()
    {
        return $"{Reference}\n{string.Join(" ", Words.Select(word => word.GetDisplayText()))}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        var scripture = new Scripture("John", 3, 16, "For God so loved the world that he gave his one and only Son that whoever believes in him shall not perish but have eternal life");
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture);
            Console.Write("Press Enter to hide more words or type 'quit' to exit: ");
            var input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                break;
            }
            scripture.HideRandomWords(3);
            if (scripture.AreAllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture);
                break;
            }
        }
    }
} 

