using System.Collections.Generic;
using System.IO;

namespace Advent_of_Code
{
    public class DaySeven
    {
        private string path = Directory.GetCurrentDirectory();
        private List<string[]> ipAddressSubnets = new List<string[]>();

        public DaySeven()
        {
            path = Path.Combine(path, "..\\..\\");
            path += "DaySevenInput.txt";
            foreach (string ipAddress in File.ReadAllLines(path))
                ipAddressSubnets.Add(ipAddress.Split('[', ']'));
        }
        
        public int puzzleOne()
        {
            int numberOfTLSsupporters = 0;

            foreach (string[] ipAddress in ipAddressSubnets)
            {
                int nonHypernetABBA = 0;
                int hypernetABBA = 0;

                for (int i = 0; i < ipAddress.Length; ++i)
                {
                    if (isABBA(ipAddress[i]))
                    {
                        if (i % 2 == 0)
                            nonHypernetABBA++;
                        else
                            hypernetABBA++;
                    }       
                }

                if (nonHypernetABBA > 0 && hypernetABBA == 0)
                    numberOfTLSsupporters++;
            }
            return numberOfTLSsupporters;
        }

        public int puzzleTwo()
        {
            int numberOfSSLsupporters = 0;

            foreach (string[] ipAddress in ipAddressSubnets)
            {
                List<string> supernetABAs = new List<string>();
                List<string> hypernetABAs = new List<string>();

                for (int i = 0; i < ipAddress.Length; ++i)
                {
                    if (i % 2 == 0)
                        supernetABAs.AddRange(isABA(ipAddress[i]));
                    else
                        hypernetABAs.AddRange(isABA(ipAddress[i]));
                }

                if (isBAB(supernetABAs, hypernetABAs))
                    numberOfSSLsupporters++;
            }
            return numberOfSSLsupporters;
        }

        private List<string> severSequence(string sequence, int blockSize)
        {
            List<string> sequences = new List<string>();

            for (int i = blockSize - 1; i < sequence.Length; ++i)
            {
                sequences.Add(sequence.Substring(i - blockSize + 1, blockSize));
            }
            return sequences;
        }

        private bool isABBA(string sequence)
        {
            List<string> sequences = severSequence(sequence, 4);

            foreach (string probableABBA in sequences)
            {
                if (probableABBA[0] == probableABBA[3] &&
                    probableABBA[1] == probableABBA[2] &&
                    probableABBA[0] != probableABBA[1])
                {
                    return true;
                }
            }
            return false;
        }

        private List<string> isABA(string sequence)
        {
            List<string> sequences = severSequence(sequence, 3);
            List<string> foundABAs = new List<string>();
            
            foreach (string probableABA in sequences)
            {
                if (probableABA[0] == probableABA[2] &&
                    probableABA[0] != probableABA[1])
                {
                    foundABAs.Add(probableABA);
                }
            }
            return foundABAs;
        }

        private bool isBAB(List<string> supernetABAs, List<string> hypernetABAs)
        {
            foreach (string supernetABA in supernetABAs)
            {
                foreach (string hypernetABA in hypernetABAs)
                {
                    if (supernetABA[0] == hypernetABA[1] &&
                        supernetABA[1] == hypernetABA[0])
                        return true;
                }
            }
            return false;
        }
    }
}