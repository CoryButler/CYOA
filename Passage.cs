using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


using System.Text;
using System.Threading.Tasks;

namespace CYOA
{
    public class Passage
    {
        private const string _menuDelimiter = "===";
        public readonly string Text;
        public readonly Menu Menu;

        public Passage(string text, Menu menu)
        {
            Text = text;
            Menu = menu;
        }

        public Passage(string filepath)
        {
            var lines = File.ReadAllLines(filepath).ToList();

            int i = 0;
            while (i < lines.Count)
            {
                if (lines[i] == _menuDelimiter) break;
                Text += lines[i] + "\n";
                i++;
            }

            if (++i < lines.Count)
            {
                var prompt = lines[i];
                i++;
                List<MenuChoice> choices = new List<MenuChoice>();
                while (i < lines.Count)
                {
                    choices.Add(new MenuChoice(lines[i], lines[i + 1]));
                    i += 2;
                }

                Menu = new Menu(prompt, choices);
            }
            else
            {
                var root = filepath.Substring(filepath.IndexOf('/') + 1);
                root = root.Substring(0, root.LastIndexOf('/') + 1);
                var filename = filepath.Substring(filepath.LastIndexOf('/') + 1);
                filename = filename.Substring(0, filename.LastIndexOf('.'));
                var fileId = int.Parse(filename) + 1;
                Menu = new Menu("", new List<MenuChoice> { new MenuChoice("Continue", (root + fileId)) });
            }
        }

        public string Display()
        {
            Settings.Color(FontColor.DEFAULT);
            Console.WriteLine(Text);
            return Menu != null ? Menu.Display() : "ERROR";
        }
    }
}
