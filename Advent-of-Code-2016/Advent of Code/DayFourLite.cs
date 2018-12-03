using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_Code
{
    public class DayFourLite
    {
        private string path = Directory.GetCurrentDirectory();
        private string[] input;

        public DayFourLite()
        {
            path = Path.Combine(path, "..\\..\\DayFourInput.txt");
            input = File.ReadAllLines(path);
        }

        public string puzzle()
        {
            int count = 0;
            int roomNorthPole = 0;

            foreach (string line in input)
            {
                string decryptedName = "";
                string checksum = Regex.Match(line, @"(?<=\[).+?(?=\])").Value;   //(?<=\[)  (?=\])
                int roomNumber = int.Parse(Regex.Match(line, @"\d+").Value);
                string room = Regex.Replace(line, @"\d+\[\w+\]|\-", string.Empty);
                room = string.Concat(room.OrderByDescending(character => room.Count(c => c == character)).ThenBy(character => character));

                foreach (char character in checksum)
                    if (room[0] == character)
                        room = room.Trim(character);

                if (room.Distinct().Count() == Regex.Replace(line, @"\d+\[\w+\]|\-", string.Empty).Distinct().Count() - 5) //obecna liczba znaków == poprzednia - 5
                    count += roomNumber;

                foreach (char character in line)
                    decryptedName += (char)(((character + (roomNumber % 26)) % 97) % 26 + 97);

                if (decryptedName.Contains("northpole"))
                    roomNorthPole = roomNumber;
            }
            return "Suma pokoi: " + count + "\nPokój North Pole: " + roomNorthPole;
        }
    }
}