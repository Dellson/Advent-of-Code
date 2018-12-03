using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    class DaySixteen
    {
        private List<bool> data;
        private const int diskSpace = 35651584;

        public DaySixteen(string input)
        {
            data = new List<bool>();

            foreach (char character in input)
            {
                if (character.Equals('0'))
                    data.Add(false);
                if (character.Equals('1'))
                    data.Add(true);
            }
        }

        public string puzzle()
        {
            List<bool> copyOfData = new List<bool>();
            while (data.Count < diskSpace)
            {
                copyOfData = data.Select(character => !character).ToList();
                copyOfData.Reverse();

                data.Add(false);
                data = data.Concat(copyOfData).ToList();
            }
            data.RemoveRange(diskSpace, -(diskSpace - data.Count));

            return stringBuilder(calculateChecksum(data));
        }

        private List<bool> calculateChecksum(List<bool> data)
        {
            if (data.Count % 2 != 0)
                return data;
            
            List<bool> checksum = new List<bool>();

            for (int i = 0; i < data.Count; i += 2)
                checksum.Add(data[i] == data[i + 1]);

            if (data.Count % 2 == 0)
                checksum = calculateChecksum(checksum);

            return checksum;
        }

        private string stringBuilder(List<bool> data)
        {
            string listRepresentation = "";

            foreach (bool character in data)
            {
                if (character)
                    listRepresentation += "1";
                else
                    listRepresentation += "0";
            }
            return listRepresentation;
        }
    }
}
