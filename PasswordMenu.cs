using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CYOA
{
    public class PasswordMenu : IMenu
    {
        private string _root;
        public PasswordMenu(string prompt = "")
        {
            _root = prompt.Substring(0, prompt.LastIndexOf("/") + 1);
        }

        public string Display()
        {
            Settings.Color(FontColor.DEFAULT);
            Console.WriteLine("Start the game at you last choice.\n\nType in your password and press ENTER.\n\n");

            Settings.Color(FontColor.SELECTION);
            var path = Bookmark.ToPath(Console.ReadLine().Trim());

            if (File.Exists(_root + path + ".txt"))
                return "./" + path;

            return "./MainMenu";
        }
    }
}
