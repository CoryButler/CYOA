using System;
using System.IO;

namespace CYOA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            var foldername = "";

            while (foldername != "?")
            {
                Console.Clear();
                MainMenu mainMeanu = new MainMenu();
                foldername = mainMeanu.Display();

                if (foldername == "?") return;

                if (!File.Exists("GameData/" + foldername + "/MainMenu.txt"))
                {
                    Settings.Color(FontColor.DEFAULT);
                    Console.WriteLine($"\nSorry, \"{foldername}\" is not formatted properly.\n\nPress ENTER to select a different story.");
                    Console.ReadLine();
                }
                else
                {
                    Story story = new Story(foldername);
                }
            }
        }
    }
}
