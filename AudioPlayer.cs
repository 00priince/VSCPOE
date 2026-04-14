using System;
using System.IO;
using System.Media;

public class AudioPlayer
{
    public static void PlayGreeting()
    {
        Play("greeting.wav");
    }

    public static void PlayGoodbye()
    {
        Play("farewell.wav");
    }

    private static void Play(string fileName)
    {
        try
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Assets", fileName);

            Console.WriteLine($"[Audio] Looking for: {path}");

            if (!File.Exists(path))
            {
                Console.WriteLine("❌ Audio file not found: " + fileName);
                return;
            }

            using SoundPlayer player = new SoundPlayer(path);

            player.Load();      // IMPORTANT: forces file load
            player.PlaySync();  // waits until sound finishes
        }
        catch (Exception ex)
        {
            Console.WriteLine("Audio error: " + ex.Message);
        }
    }
}