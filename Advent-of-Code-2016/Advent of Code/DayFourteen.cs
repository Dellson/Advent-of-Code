using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code
{
    class DayFourteen
    {
        private List<string> hashes = new List<string>();
        private string puzzleInput;

        public DayFourteen(string puzzleInput)
        {
            this.puzzleInput = puzzleInput;
        }

        public void puzzle()
        {
            using (MD5 md5Hash = MD5.Create())
            {
                int index = 0;
                int keysFound = 0;
                char key = ' ';
                
                while (keysFound < 64)
                {
                    string hash = "";
                    if (hashes.Count <= index)
                        //hashes.Add(GetMd5Hash(md5Hash, puzzleInput + index));  // zadanie 1
                        hashes.Add(stretchHash(md5Hash, puzzleInput + index));

                    hash = hashes[index];

                    if (findTriplet(hash, ref key))
                    {
                        if (findFiveOfAKind(md5Hash, key, index))
                        {
                            Console.WriteLine(index + " " + key);
                            keysFound++;
                        }
                    }
                    index++;
                }
                Console.WriteLine(index - 1);
            }
        }

        private bool findTriplet(string inputHash, ref char key)
        {
            for (int i = 0; i < inputHash.Length - 2; ++i)
            {
                if (inputHash[i] == inputHash[i + 1] && inputHash[i] == inputHash[i + 2])
                {
                    key = inputHash[i];
                    return true;
                }
            }
            return false;
        }

        private bool findFiveOfAKind(MD5 md5Hash, char key, int tripletPosition)
        {
            for (int j = tripletPosition + 1; j < 1001 + tripletPosition; ++j)
            {
                string hash = "";
                if (hashes.Count <= j)
                    //hashes.Add(GetMd5Hash(md5Hash, puzzleInput + j));  // zadanie 1
                    hashes.Add(stretchHash(md5Hash, puzzleInput + j));
                hash = hashes[j];

                for (int i = 0; i < hash.Length - 4; ++i)
                {
                    if (key == hash[i] && key == hash[i + 1] && key == hash[i + 2] && key == hash[i + 3] && key == hash[i + 4])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private string stretchHash(MD5 md5Hash, string hash)
        {
            for (int i = 0; i < 2017; ++i)
            {
                hash = GetMd5Hash(md5Hash, hash);
            }
            return hash;
        }

        private static string GetMd5Hash(MD5 md5Hash, string input)
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