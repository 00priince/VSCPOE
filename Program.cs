using System;

class Program
{
    static void Main()
    {
        Console.Title = "Cybersecurity Chatbot";

        // Play greeting audio (safe call)
        try
        {
            AudioPlayer.PlayGreeting();
        }
        catch
        {
            Console.WriteLine("Audio could not be played.");
        }

        // Show logo (if exists)
        try
        {
            NeonUI.BootLogo();
        }
        catch
        {
            Console.WriteLine("____ Cybersecurity Bot ____");
        }

        Console.WriteLine("\nType 'exit', 'bye', or 'goodbye' to quit.\n");

        // Main chat loop
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("You: ");
            Console.ResetColor();

            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Please enter something.");
                continue;
            }

            string lower = input.Trim().ToLower();

            // EXIT / GOODBYE LOGIC
            if (lower is "exit" or "bye" or "goodbye")
            {
                Console.WriteLine("\nBot: Goodbye 👋 Stay safe online.");

                try
                {
                    AudioPlayer.PlayGoodbye();
                }
                catch
                {
                    Console.WriteLine("Goodbye audio could not be played.");
                }

                break;
            }

            // Get chatbot response
            string response = Chatbot.Start(input);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nBot:");
            Console.ResetColor();

            try
            {
                NeonUI.Bot(response);
            }
            catch
            {
                Console.WriteLine(response);
            }

            Console.WriteLine();
        }
    }
}
