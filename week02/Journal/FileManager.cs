using System;
using System.Collections.Generic;
using System.IO;

namespace Program
{
    public class FileManager
    {
        public void SaveJournal(List<Entry> entries, string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    foreach (var entry in entries)
                    {
                        writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving journal: " + ex.Message);
            }
        }

        public List<Entry> LoadJournal(string filename)
        {
            List<Entry> entries = new List<Entry>();

            try
            {
                if (File.Exists(filename))
                {
                    string[] lines = File.ReadAllLines(filename);

                    foreach (var line in lines)
                    {
                        string[] parts = line.Split('|');

                        if (parts.Length == 3)
                        {
                            Entry entry = new Entry(parts[1], parts[2], parts[0]);
                            entries.Add(entry);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("File not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading journal: " + ex.Message);
            }

            return entries;
        }
    }
}