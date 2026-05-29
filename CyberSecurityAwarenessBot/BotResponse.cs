
using System;
using System.Collections.Generic;

namespace CyberSecurityAwarenessBot
{
    public class BotResponse
    {
        private Random rand = new Random();

        private Dictionary<string, List<string>> responses =
            new Dictionary<string, List<string>>()
        {
            {
                "password",
                new List<string>()
                {
                    "Use strong passwords with symbols and numbers.",
                    "Never reuse passwords across websites.",
                    "Enable two-factor authentication whenever possible."
                }
            },

            {
                "phishing",
                new List<string>()
                {
                    "Never click suspicious links.",
                    "Verify the sender before opening attachments.",
                    "Banks never ask for passwords via email."
                }
            },

            {
                "privacy",
                new List<string>()
                {
                    "Review your social media privacy settings.",
                    "Avoid sharing personal information publicly.",
                    "Use secure websites that begin with HTTPS."
                }
            }
        };

        public string GetResponse(string input)
        {
            input = input.ToLower();

            foreach (var keyword in responses.Keys)
            {
                if (input.Contains(keyword))
                {
                    List<string> list = responses[keyword];
                    return list[rand.Next(list.Count)];
                }
            }

            if (input.Contains("worried"))
            {
                return "It is understandable to feel worried. Let me help you stay safe online.";
            }

            if (input.Contains("hello"))
            {
                return "Hello! How can I help you today?";
            }

            return "I'm not sure I understand. Can you try rephrasing?";
        }
    }
}
