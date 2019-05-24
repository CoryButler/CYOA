using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace CYOA
{
    public class MainMenu : Menu
    {
        private string _prompt;
        private List<MenuChoice> _choices;

        public MainMenu(string prompt = "", List<MenuChoice> choices = null) : base(prompt, choices)
        {
            _prompt = "Welcome to the CYOA Engine!";
            var directories = Directory.GetDirectories("GameData").ToList();
            if (directories.Count == 0) _prompt += "\n\nSorry, there are no stories available.";
            else
            {
                _choices = new List<MenuChoice>();
                var i = 0;
                foreach (var directory in directories)
                {
                    var folderName = directory.Substring(directory.LastIndexOf('\\') + 1);
                    _choices.Add(new MenuChoice(folderName, folderName));
                    i++;
                }
                _choices.Add(new MenuChoice("Quit", "?"));
            }
        }

        public override string Display()
        {
            Settings.Color(FontColor.DEFAULT);
            Console.WriteLine(_prompt);

            bool isChoiceConfirmed = false;
            int currentChoiceIndex = 0;
            while (!isChoiceConfirmed)
            {
                for (var i = 0; i < _choices.Count; i++)
                {
                    if (currentChoiceIndex == i)
                    {
                        Settings.Color(FontColor.SELECTION);
                        Console.Write("> ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }

                    Console.WriteLine(_choices[i].Text);
                    Settings.Color(FontColor.MENU);
                }
                
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        currentChoiceIndex -= 1;
                        if (currentChoiceIndex < 0) currentChoiceIndex += _choices.Count;
                        break;
                    case ConsoleKey.DownArrow:
                        currentChoiceIndex = (currentChoiceIndex + 1) % _choices.Count;
                        break;
                    case ConsoleKey.Enter:
                        isChoiceConfirmed = true;
                        break;
                }

                if (!isChoiceConfirmed) Console.CursorTop -= _choices.Count;
            }

            return _choices[currentChoiceIndex].Link;
        }
    }
}
