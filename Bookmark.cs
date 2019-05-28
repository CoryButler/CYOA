using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYOA
{
    public static class Bookmark
    {
        public static string ToBookmark(string path)
        {
            string password = string.Empty;
            int seed = new Random().Next(1, 10);
            path = path.Substring(0, path.LastIndexOf('/')); // get current folder
            path = path.Substring(0, path.LastIndexOf('/')); // get parent folder

            var chars = path.Replace("GameData", "").Replace("ThunderCats", "").Replace("/", "");
            if (chars.Length > 0)
            {
                List<int> ints = new List<int>();

                foreach (var c in chars)
                {
                    var i = int.Parse(c.ToString()) + seed;
                    if (i >= 10) i -= 10;
                    ints.Add(i);
                }

                password = string.Join("", ints.ToArray());
            }
            return password;
        }

        public static string ToPath(string bookmarkCode)
        {
            if (bookmarkCode.Length == 0) return "";

            var elements = new List<int>();

            foreach (var p in bookmarkCode)
            {
                elements.Add(int.Parse(p.ToString()));
            }

            var seed = elements[0];

            StringBuilder sb = new StringBuilder();
            foreach (var e in elements)
            {
                var value = e - seed;
                if (value < 0) value += 10;
                sb.Append(value + "/");
            }
            sb.Append("0");

            var path = sb.ToString();
            return path;
        }
    }
}
