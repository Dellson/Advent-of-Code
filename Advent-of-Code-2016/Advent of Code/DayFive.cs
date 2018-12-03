using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    static class DayFive
    {
        static public string puzzleOne(string input)
        {
            string output = "";
            int index = 0;
            const int numberOfZeroes = 5;

            using (MD5 md5Hash = MD5.Create())
            {
                while (output.Length < 8)
                {
                    string hash = GetMd5Hash(md5Hash, input + index);

                    //uproszczone - zamiast pętli dla zwiększenia wydajnosci
                    if (hash[0] == '0' &&
                        hash[1] == '0' &&
                        hash[2] == '0' &&
                        hash[3] == '0' &&
                        hash[4] == '0')
                    {
                        output += hash[numberOfZeroes];
                        Console.WriteLine(output);
                    }                    

                    index++;
                }
            }
            return output;
        }

        static public string puzzleTwo(string input)
        {
            string output = "";
            char[] positionedOutput = new char[8] { '_', '_', '_', '_', '_', '_', '_', '_' };
            int index = 0;
            int nonFoundCharacters = positionedOutput.Length;
            const int numberOfZeroes = 5;

            using (MD5 md5Hash = MD5.Create())
            {
                while (0 < nonFoundCharacters)
                {
                    string hash = GetMd5Hash(md5Hash, input + index);

                    //uproszczone - zamiast pętli dla zwiększenia wydajnosci
                    if (hash[0] == '0' &&
                        hash[1] == '0' &&
                        hash[2] == '0' &&
                        hash[3] == '0' &&
                        hash[4] == '0')
                    {
                        if (hash[numberOfZeroes] >= '0' && hash[numberOfZeroes] <= '7' &&
                            positionedOutput[(int)char.GetNumericValue(hash[numberOfZeroes])] == '_')
                        {
                            positionedOutput[(int)char.GetNumericValue(hash[numberOfZeroes])] = hash[numberOfZeroes + 1];
                            nonFoundCharacters--;
                        }

                        foreach (char character in positionedOutput)
                        {
                            Console.Write(character);
                        }
                        Console.WriteLine();
                    }

                    index++;
                }
            }

            foreach (char character in positionedOutput)
            {
                output += character;
            }

            return output;
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
