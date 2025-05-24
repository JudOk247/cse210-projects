using System;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            var journal = new Journal();
            var promptProvider = new PromptProvider();
            var fileManager = new FileManager();

            while (true)
            {
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Exit");

                Console.Write("Choose an option: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        var prompt = promptProvider.GetRandomPrompt();
                        Console.WriteLine(prompt);
                        var response = Console.ReadLine();
                        var entry = new Entry(prompt, response, DateTime.Now.ToString("yyyy-MM-dd"));
                        journal.AddEntry(entry);
                        break;
                    case "2":
                        journal.DisplayEntries();
                        break;
                    case "3":
                        Console.Write("Enter filename: ");
                        var filename = Console.ReadLine();
                        try
                        {
                            fileManager.SaveJournal(journal.Entries, filename);
                            Console.WriteLine("Journal saved successfully.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error saving journal: " + ex.Message);
                        }
                        break;
                    case "4":
                        Console.Write("Enter filename: ");
                        filename = Console.ReadLine();
                        try
                        {
                            var loadedEntries = fileManager.LoadJournal(filename);
                            if (loadedEntries != null)
                            {
                                journal.Entries = loadedEntries;
                                Console.WriteLine("Journal loaded successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to load journal.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error loading journal: " + ex.Message);
                        }
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }
            }
        }
    }
}