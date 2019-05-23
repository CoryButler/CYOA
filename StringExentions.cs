using System;

namespace CYOA
{
    public static class StringExentions
    {
        public static string ParsePath(this string str)
        {
            if (str.Contains("./"))
            {
                var segments = str.Split(new string[] { "./" }, StringSplitOptions.None);
                if (segments[0].Contains("/"))
                {
                    segments[0] = segments[0].Substring(0, segments[0].LastIndexOf('/') + 1);
                }
                str = segments[0] + segments[1];
            }

            return str;
        }
    }
}
