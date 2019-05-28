using System;
using System.Collections.Generic;

namespace CYOA
{
    public class Menu : IMenu
    {
        private string _prompt;
        private List<MenuChoice> _choices;

        public Menu(string prompt, List<MenuChoice> choices)
        {
            _prompt = prompt;
            _choices = choices;
        }

        public string Display()
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

            return "./" + _choices[currentChoiceIndex].Link;
        }
    }
}
