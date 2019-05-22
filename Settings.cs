using System;
using System.Collections.Generic;

namespace CYOA
{
    public enum FontColor { DEFAULT, MENU, PLAYER };

    public static class Settings
    {
        private static Dictionary<FontColor, ConsoleColor> _colors = new Dictionary<FontColor, ConsoleColor> {
            { FontColor.DEFAULT, ConsoleColor.Yellow },
            { FontColor.MENU, ConsoleColor.DarkYellow },
            { FontColor.PLAYER, ConsoleColor.DarkYellow } };

        public static void Color(FontColor fontColor) => Console.ForegroundColor = _colors[fontColor];
    }
}
