using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    public class DayFour
    {
        private string path = Directory.GetCurrentDirectory();
        private string[] input;

        public DayFour()
        {
            path = Path.Combine(path, "..\\..\\");
            path += "DayFourInput.txt";

            input = File.ReadAllLines(path);
        }

        public int puzzleOne()
        {
            int count = 0;

            foreach (string room in input)
            {
                if (isRoomReal(room))
                {
                    count += getRoomNumber(room);
                }
            }
            return count;
        }

        public bool isRoomReal(string room)
        {
            bool isNowChecksum = false;
            string roomChecksum = "";
            string correctChecksum = "";
            Dictionary<char, int> letters = new Dictionary<char, int>();

            foreach (char character in room)
            {
                if (character == 91)
                    isNowChecksum = true;

                if (character >= 97 && character <= 122 && !isNowChecksum)
                {
                    if (!letters.ContainsKey(character))
                    {
                        letters.Add(character, 1);
                    }
                    else
                    {
                        letters[character]++;
                    }
                }

                if (isNowChecksum && character != 91 && character != 93)
                    roomChecksum += character;
            }

            for (int i = 0; i < 5; ++i)
            {
                char letter = '{';
                int max = 0;
                foreach (char key in letters.Keys)
                {
                    if (letters[key] > max)
                        max = letters[key];
                }

                //Console.WriteLine("MAX " + max);

                foreach (char key in letters.Keys)
                {
                    if (letters[key] == max && key < letter)
                        letter = key;
                }
                correctChecksum += letter;

                letters.Remove(correctChecksum[correctChecksum.Length - 1]);
            }

            /*foreach (char key in letters.Keys)
            {
                Console.WriteLine(key + " " + letters[key]);
            }*/

            Console.WriteLine(correctChecksum + " " + roomChecksum);

            /*char[] charChecksum = correctChecksum.ToArray();
            Array.Sort(charChecksum);
            correctChecksum = new string(charChecksum);*/

            return correctChecksum.Equals(roomChecksum);
        }

        public int puzzleTwo()
        {
            int count = 0;

            foreach (string room in input)
            {
                if (decryptRoomName(room) != 0)
                    Console.WriteLine(decryptRoomName(room));
            }

            //Console.WriteLine(decryptRoomName("qzmt-zixmtkozy-ivhz-343"));
            
            return count;
        }

        public int decryptRoomName(string room)
        {
            bool isNowChecksum = false;
            string realRoomName = "";

            foreach (char character in room)
            {
                if (character == 91)
                    isNowChecksum = true;

                if (character >= 97 && character <= 122 && !isNowChecksum && character != 45)
                {
                    int position = (((character - 97 + getRoomNumber(room))) % (122 - 97 + 1)) + 97;
                    realRoomName += (char)position;
                }
                if (character == 45)
                {
                    realRoomName += ' ';
                }
            }

            //Console.WriteLine(realRoomName);

            if (realRoomName.Contains("north") && realRoomName.Contains("pole"))
            {
                return getRoomNumber(room);
            }

            return 0;
        }

        private int getRoomNumber(string room)
        {
            return int.Parse(System.Text.RegularExpressions.Regex.Match(room, @"\d+").Value);
        }
    }
}
