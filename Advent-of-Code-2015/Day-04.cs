using System;
using System.Security.Cryptography;
using System.Text;

namespace Advent_of_Code_2015
{
    class Day_04
    {
        private static string input = System.IO.File.ReadAllLines(Program.InputFolderPath + "Day-04-input.txt")[0];

        public static void BothStars()
        {
            int index = 0;
            using (MD5 md5Hash = MD5.Create()) { for (; !GetMd5Hash(md5Hash, input + index).StartsWith("00000"); index++) { } }
            Console.WriteLine(index);
        }
        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));

            return sBuilder.ToString();
        }
    }
}
