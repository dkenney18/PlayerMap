using System;

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
            string[] chars = Enum.GetNames(typeof(Blocks));
            return chars[random.Next(chars.Length)].Substring(0, 2);
        }
    }
}