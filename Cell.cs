using System;
using System.Linq;

namespace PlayerMap
{
    public class Cell
    {
        public string space;
        public string prev_space;
        private static readonly Random random = new();
        public Cell()
        {
            space = RandomString(1);
        }

        public void ChangeSpace(string newSpace)
        {
            prev_space = space;
            space = newSpace;
        }

        public void RevertSpace()
        {
            space = prev_space;
        }

        public string GetSpace()
        {
            return space;
        }
        public static string RandomString(int length)
        {
            // S = stone
            // I = iron
            // G = gold
            // E = emaerald
            // D = diamond
            const string chars = "SGIDE";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}