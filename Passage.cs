using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CYOA
{
    public class Passage
    {
        private const string _menuDelimiter = "===";
        private const string _passwordDelimiter = "***";
        private readonly string Text;
        private readonly IMenu Menu;

        public Passage(string text, IMenu menu)
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
                if (lines[i] == _menuDelimiter || lines[i] == _passwordDelimiter) break;
                Text += lines[i] + "\n";
                i++;
            }

            i++;

            if (lines.Any(line => line == _menuDelimiter)) Menu = BuildMenu(lines, i);
            else if (lines.Any(line => line == _passwordDelimiter)) Menu = BuildPassword(filepath);
            else Menu = BuildConitnue(filepath);
        }

        public string Display()
        {
            Settings.Color(FontColor.DEFAULT);
            Console.WriteLine(Text);
            return Menu != null ? Menu.Display() : "ERROR";
        }

        private Menu BuildConitnue(string filepath)
        {
            var filename = filepath.Substring(filepath.LastIndexOf('/') + 1);
            filename = filename.Substring(0, filename.LastIndexOf('.'));
            var fileId = int.Parse(filename) + 1;
            return new Menu("", new List<MenuChoice> { new MenuChoice("Continue", fileId.ToString()) });
        }

        private Menu BuildMenu(List<string> lines, int index)
        {
            var prompt = lines[index];
            index++;
            List<MenuChoice> choices = new List<MenuChoice>();
            while (index < lines.Count)
            {
                choices.Add(new MenuChoice(lines[index], lines[index + 1]));
                index += 2;
            }

            return new Menu(prompt, choices);
        }

        private IMenu BuildPassword(string filepath)
        {
            return new PasswordMenu(filepath);
        }
    }
}
