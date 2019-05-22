using System;

namespace CYOA
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Passage("GameData/MainMenu.txt");
            var l = p.Display();

            if (l == "1") { Console.WriteLine("No, you don't.\n"); Console.ReadLine(); }

            Player player = new Player();
            string link = "0/0";
            while (link != "ERROR")
            {
                try
                {
                    Console.Clear();
                    var passage = new Passage("GameData/" + link + ".txt");
                    //player.Display();
                    link = passage.Display();
                }
                catch
                {
                    var passage = new Passage("GAME OVER", null);
                    link = passage.Display();
                    Console.ReadLine();
                }
            }
        }
    }
}
