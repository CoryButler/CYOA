using System;
using System.IO;

namespace CYOA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            string link = "GameData/MainMenu";

            while (File.Exists(link +".txt"))
            {
                Console.Clear();
                MainMenu mainMeanu = new MainMenu();
                var foldername = mainMeanu.Display();
                if (!Directory.Exists("GameData/" + foldername)) break;
                if (!File.Exists("GameData/" + foldername + "/MainMenu.txt"))
                {
                    Settings.Color(FontColor.DEFAULT);
                    Console.WriteLine($"\nSorry, \"{foldername}\" is not formatted properly.\n\nPress ENTER to select a different story.");
                    Console.ReadLine();
                }
                else
                {
                    Story story = new Story(foldername);
                    story.Start();
                }
            }
        }
    }
}
