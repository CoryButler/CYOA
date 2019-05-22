namespace CYOA
{
    public class MenuChoice
    {
        public readonly string Text;
        public readonly string Link;

        public MenuChoice(string text, string link)
        {
            Text = text;
            Link = link;
        }
    }
}
