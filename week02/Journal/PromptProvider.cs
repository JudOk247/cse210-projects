using System;
using System.Collections.Generic;

namespace Program
{
    public class PromptProvider
    {
        private List<string> Prompts { get; set; }
        private Random Random { get; set; }

        public PromptProvider()
        {
            Prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?",
                "What did I learn today?",
                "What am I grateful for today?"
            };

            Random = new Random();
        }

        public string GetRandomPrompt()
        {
            return Prompts[Random.Next(Prompts.Count)];
        }
    }
}