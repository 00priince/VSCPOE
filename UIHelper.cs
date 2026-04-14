using System;
using System.Threading;

public static class NeonUI
{
    public static void BootLogo()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;

        Console.WriteLine("╔══════════════════════════════╗");
        Console.WriteLine("║        NEONCORE v1.0         ║");
        Console.WriteLine("║   Cybersecurity Assistant    ║");
        Console.WriteLine("╚══════════════════════════════╝");

        Console.ResetColor();

        Console.WriteLine();
        TypeLine(">> system: online");
        TypeLine(">> firewall: active");
        TypeLine(">> assistant: ready");
        Console.WriteLine();
    }

    public static void TypeLine(string text, int speed = 25)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;

        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(speed);
        }

        Console.ResetColor();
        Console.WriteLine();
    }

    public static void Prompt()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("user@neoncore > ");
        Console.ResetColor();
    }

    public static void Bot(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("neoncore > ");
        Console.ResetColor();

        TypeLine(message, 15);
    }

    public static void Loading(string text = "processing")
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write(text);

        for (int i = 0; i < 3; i++)
        {
            Thread.Sleep(300);
            Console.Write(".");
        }

        Console.WriteLine();
        Console.ResetColor();
    }
}