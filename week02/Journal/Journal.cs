using System;
using System.Collections.Generic;

namespace Program
{
    public class Journal
    {
        public List<Entry> Entries { get; set; }

        public Journal()
        {
            Entries = new List<Entry>();
        }

        public void AddEntry(Entry entry)
        {
            Entries.Add(entry);
        }

        public void DisplayEntries()
        {
            foreach (var entry in Entries)
            {
                Console.WriteLine(entry.ToString());
            }
        }
    }
}