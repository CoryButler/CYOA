using System;

namespace CYOA
{
    public enum Sex { MALE, FEMALE };
    public class Player
    {
        public string Name = "Cory";
        public int Money = 100;
        public Sex sex = Sex.MALE;

        public string Location = "Davern Village";

        public void Display()
        {
            Settings.Color(FontColor.PLAYER);
            Console.WriteLine($"{Name}: ${Money} - {Location}\n");
        }
    }
}
