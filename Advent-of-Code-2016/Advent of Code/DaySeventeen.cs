using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    class DaySeventeen
    {
        private string passcode;
        private Tuple<int, int> vaultPosition = new Tuple<int, int>(3, 3);
        private List<string> possiblePaths = new List<string>();
        private MD5 md5Hash;

        public DaySeventeen(string passcode)
        {
            this.passcode = passcode;

            using (MD5 md5Hash = MD5.Create())
            {
                this.md5Hash = md5Hash;
                puzzle(new Tuple<int, int>(0, 0), string.Empty);

                Console.WriteLine("The shortest path: " + possiblePaths.OrderBy(path => path.Length).First().Length);
                Console.WriteLine("The longest path: " + possiblePaths.OrderByDescending(path => path.Length).First().Length);
            }
        }

        public void puzzle(Tuple<int, int> currentPosition, string currentPath)
        {
            List<bool> doorStatus = new List<bool>();
            doorStatus = determineSpaceType(currentPosition, currentPath);

            if (currentPosition.Item1 == vaultPosition.Item1 && currentPosition.Item2 == vaultPosition.Item2)
            {
                possiblePaths.Add(currentPath);
                return;
            }

            if (doorStatus[0] && currentPosition.Item2 != 0)
            {
                puzzle(new Tuple<int, int>(currentPosition.Item1, currentPosition.Item2 - 1), currentPath + "U");
            }
            if (doorStatus[1] && currentPosition.Item2 != 3)
            {
                puzzle(new Tuple<int, int>(currentPosition.Item1, currentPosition.Item2 + 1), currentPath + "D");
            }
            if (doorStatus[2] && currentPosition.Item1 != 0)
            {
                puzzle(new Tuple<int, int>(currentPosition.Item1 - 1, currentPosition.Item2), currentPath + "L");
            }
            if (doorStatus[3] && currentPosition.Item1 != 3)
            {
                puzzle(new Tuple<int, int>(currentPosition.Item1 + 1, currentPosition.Item2), currentPath + "R");
            }
        }

        //UDLR
        private List<bool> determineSpaceType(Tuple<int, int> currentPosition, string currentPath)
        {
            List<bool> doorStatus = new List<bool>();
            string hash = GetMd5Hash(md5Hash, passcode + currentPath);

            for (int i = 0; i < 4; ++i)
            {
                if (hash[i] >= 'b' && hash[i] <= 'f')
                    doorStatus.Add(true);
                else
                    doorStatus.Add(false);
            }
            return doorStatus;
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
