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
            string link = "GameData/" + _root + "/MainMenu";

            while (File.Exists(link +".txt"))
            {
                Console.Clear();
                Passage passage = new Passage(link + ".txt");
                link = (link + passage.Display()).ParsePath();
            }

            if (link.Substring(link.LastIndexOf('/') + 1) != "ERROR")
            {
                Console.Clear();

                var bookmarkCode = Bookmark.ToBookmark(link, _root);
                string message = "Game Over";
                message += bookmarkCode != "" ? $"\n\nBookmark Code: {bookmarkCode}" : "";

                Passage p = new Passage(message, null);
                link = p.Display();
                Console.ReadLine();
            }
        }
    }
}
