using System;
using System.Collections.Generic;

public static class Chatbot
{
    private static Random rand = new Random();
    private static string userName = "";

    // INTENT MAP
    private static readonly Dictionary<string, string[]> intents = new()
    {
        ["greeting"] = new[] { "hi", "hello", "hey", "yo" },
        ["definition"] = new[] { "what is", "define", "meaning", "explain" },
        ["password"] = new[] { "password", "login", "credentials", "pass" },
        ["phishing"] = new[] { "phishing", "scam", "fake", "fraud" },
        ["roast"] = new[] { "boring", "stupid bot", "you dumb", "useless" },
        ["joke"] = new[] { "joke", "funny", "make me laugh" },
        ["help"] = new[] { "help", "what can you do" },
        ["bye"] = new[] { "bye", "exit", "goodbye" }
    };

    public static string Start(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return "Say something... I can’t read silence yet 😭";

        input = input.ToLower().Trim();

        CaptureName(input);

        string intent = DetectIntent(input);

        return Respond(intent, input);
    }

    // ================= INTENT DETECTION =================

    private static string DetectIntent(string input)
    {
        foreach (var intent in intents)
        {
            foreach (var keyword in intent.Value)
            {
                if (input.Contains(keyword))
                    return intent.Key;
            }
        }
        return "unknown";
    }

    // ================= RESPONSE ENGINE =================

    private static string Respond(string intent, string input)
    {
        return intent switch
        {
            "greeting" =>
                RandomPick(new[]
                {
                    $"Hey {Name()} 👋",
                    "Hello human. I was just thinking about cybersecurity… as one does.",
                    "Hi. I’m 87% sure you’re safe today 😄"
                }),

            "definition" =>
                HandleDefinition(input),

            "password" =>
                RandomPick(new[]
                {
                    "A password is basically your digital toothbrush — don’t let anyone borrow it.",
                    "Use long passwords. '123456' is not a password, it’s an invitation.",
                    "If your password is your pet’s name… hackers already know it."
                }),

            "phishing" =>
                RandomPick(new[]
                {
                    "Phishing = digital fishing… and you are the fish if you're not careful 🐟",
                    "If an email screams URGENT in caps… it's probably a scam yelling at you.",
                    "Never click links from strangers. Even in emails. Especially in emails."
                }),

            "joke" =>
                RandomPick(new[]
                {
                    "Why do hackers love dark mode? Because light attracts bugs 😎",
                    "I told my password to my friend… now it’s not a secret anymore.",
                    "Cybersecurity joke: I changed my password… to 'incorrect'. Now I always remember it."
                }),

            "roast" =>
                RandomPick(new[]
                {
                    "I’m not saying you're bad at cybersecurity… but please don’t use 'password123'.",
                    "I would insult you… but your firewall is already down emotionally 😭",
                    "I’ve seen stronger passwords on sticky notes at coffee shops."
                }),

            "help" =>
                "You can ask me about passwords, phishing, cybersecurity definitions, or ask for jokes 😄",

            "bye" =>
                $"Goodbye {Name()}. Don’t click suspicious links on your way out 👀",

            _ =>
                SmartFallback(input)
        };
    }

    // ================= DEFINITIONS =================

    private static string HandleDefinition(string input)
    {
        if (input.Contains("password"))
            return DefinitionBlock(
                "Password",
                "A secret string used to verify identity.",
                "It protects your accounts from unauthorized access.",
                "Example: T7#x9Lm!Q2"
            );

        if (input.Contains("phishing"))
            return DefinitionBlock(
                "Phishing",
                "A cyberattack where attackers pretend to be trusted sources.",
                "They trick users into giving sensitive data like passwords.",
                "Example: Fake bank login page email."
            );

        if (input.Contains("cybersecurity"))
            return DefinitionBlock(
                "Cybersecurity",
                "The practice of protecting systems and data from attacks.",
                "It includes tools, habits, and systems that prevent hacking.",
                "Example: Antivirus, firewalls, strong passwords."
            );

        return "I can define things like 'password', 'phishing', or 'cybersecurity'. Try one 😄";
    }

    

    private static void CaptureName(string input)
    {
        if (input.StartsWith("my name is "))
            userName = input.Replace("my name is ", "").Trim();

        if (input.StartsWith("call me "))
            userName = input.Replace("call me ", "").Trim();
    }

    private static string Name()
    {
        return string.IsNullOrWhiteSpace(userName) ? "friend" : Capitalize(userName);
    }

    

    private static string SmartFallback(string input)
    {
        if (input.Contains("?"))
        {
            return "That’s a good question 🤔 I don’t fully know that yet, but I can help with cybersecurity topics.";
        }

        if (input.Length < 4)
        {
            return "You’re being mysterious… expand a little 😄";
        }

        if (input.Contains("hack"))
        {
            return "Hacking is a broad topic — but most real hackers are just good at social engineering (tricking people).";
        }

        return RandomPick(new[]
        {
            "I’m not fully sure what you mean… try rephrasing that.",
            "That one went over my firewall 😭 try again.",
            "Interesting input… but I need more context."
        });
    }

    

    private static string RandomPick(string[] options)
    {
        return options[rand.Next(options.Length)];
    }

    private static string Capitalize(string text)
    {
        if (string.IsNullOrEmpty(text)) return text;
        return char.ToUpper(text[0]) + text.Substring(1);
    }

    private static string DefinitionBlock(string term, string def, string explanation, string example)
    {
        return
$@"📘 {term}
Definition: {def};
Explanation: {explanation}
Example: {example}";
    }
}