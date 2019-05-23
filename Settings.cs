using System;
using System.Collections.Generic;

namespace CYOA
{
    public enum FontColor { DEFAULT, MENU, SELECTION, STATS };

    public static class Settings
    {
        private static Dictionary<FontColor, ConsoleColor> _colors = new Dictionary<FontColor, ConsoleColor> {
            { FontColor.DEFAULT, ConsoleColor.Yellow },
            { FontColor.MENU, ConsoleColor.Gray },
            { FontColor.SELECTION, ConsoleColor.Cyan },
            { FontColor.STATS, ConsoleColor.DarkBlue } };

        public static void Color(FontColor fontColor) => Console.ForegroundColor = _colors[fontColor];
    }
}
