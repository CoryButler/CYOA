using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYOA
{
    public class PasswordMenu : Menu
    {
        private string _root;
        public PasswordMenu(string prompt = "", List<MenuChoice> choices = null) : base(prompt, choices)
        {
            _root = prompt.Substring(0, prompt.LastIndexOf("/") + 1);
        }

        public override string Display()
        {
            Settings.Color(FontColor.DEFAULT);
            Console.WriteLine("Start the game at you last choice.\n\nType in your password and press ENTER.\n\n");

            Settings.Color(FontColor.SELECTION);
            var password = Console.ReadLine().Trim().ToList();

            var elements = new List<int>();

            foreach (var p in password)
            {
                elements.Add(int.Parse(p.ToString()));
            }

            var seed = elements[0];
            elements.RemoveAt(0);

            elements.Reverse();

            StringBuilder sb = new StringBuilder();
            foreach (var e in elements)
            {
                var value = e - seed;
                if (value < 0) value += 10;
                sb.Append(value + "/");
            }
            sb.Remove(sb.Length - 1, 1);

            var path = sb.ToString();

            if (File.Exists(_root + path + ".txt"))
                return "./" + path;

            return "./MainMenu";
        }
    }
}
