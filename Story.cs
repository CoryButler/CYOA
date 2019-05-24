using System;
using System.Collections.Generic;
using System.IO;

namespace CYOA
{
    public class Story
    {
        private string _root;

        public Story(string rootFolder)
        {
            _root = rootFolder;
        }

        public string Start()
        { 
            string link = "GameData/" + _root + "/MainMenu";

            while (File.Exists(link +".txt"))
            {
                Console.Clear();
                Passage passage = new Passage(link + ".txt");
                link = (link + passage.Display()).ParsePath();
            }
                Console.Clear();

            int seed = new Random().Next(1, 10);
            var path = link.Substring(0, link.LastIndexOf('/')); // get current folder
            path = path.Substring(0, path.LastIndexOf('/')); // get parent folder

            var chars = path.Replace("GameData", "").Replace("ThunderCats", "").Replace("/", "");

            Passage p = null;

            if (chars.Length > 0)
            {
                List<int> ints = new List<int>();

                foreach (var c in chars)
                {
                    var i = int.Parse(c.ToString()) + seed;
                    if (i >= 10) i -= 10;
                    ints.Add(i);
                }

                var password = string.Join("", ints.ToArray());
                p = new Passage($"GAME OVER\n\nBookmark: {password}", null);
            }
            else
            {
                p = new Passage("GAME OVER", null);
            }

            link = p.Display();
            Console.ReadLine();

            return "";
        }
    }
}
