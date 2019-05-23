using System;

namespace CYOA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            string link = "GameData/MainMenu";

            while (link != "ERROR")
            {
                try
                {
                    Console.Clear();
                    Passage passage = new Passage(link + ".txt");
                    link = (link + passage.Display()).ParsePath();
                }
                catch
                {
                    int seed = new Random().Next(10);
                    var password = "#####";
                    Passage passage = new Passage($"GAME OVER\n\nPassword: {password}", null);
                    link = passage.Display();
                    Console.ReadLine();
                }
            }
        }
    }
}
