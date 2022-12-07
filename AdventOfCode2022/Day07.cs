using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2022
{
    class Day07
    {
        private static string[] _input;
        private static List<Directory> allDirs = new List<Directory> { new Directory("/", 0) };

        public static void Puzzle()
        {
            _input = Program.GetTextInputData("7");
            Puzzle1();
            Puzzle2();
        }

        private static void Puzzle1()
        {
            var depth = 0;
            var currentDirectory = allDirs.First();

            foreach (var line in _input.Skip(1))
            {
                if (line.StartsWith("$ cd"))
                {
                    var newDir = Regex.Match(line, @"\$ cd (\w+)").Groups[1].Value;
                    if (line.EndsWith(".."))
                    {
                        depth--;
                        currentDirectory = allDirs.Find(d => d.Depth == depth && d.InnerDirectories.ContainsValue(currentDirectory));
                    }
                    else
                    {
                        depth++;
                        currentDirectory = currentDirectory.InnerDirectories[newDir];
                    }
                }
                else if (line.StartsWith("dir"))
                {
                    var dirName = Regex.Match(line, @"dir (\w+)").Groups[1].Value;
                    if (!currentDirectory.InnerDirectories.ContainsKey(dirName))
                    {
                        var newDir = new Directory(dirName, depth + 1);
                        currentDirectory.InnerDirectories.Add(dirName, newDir);
                        allDirs.Add(newDir);
                    }
                }
                else if (!line.StartsWith("$ ls"))
                {
                    var fileMatch = Regex.Match(line, @"(\d+) (\w+\.?\w?)");
                    if (fileMatch.Groups.Count == 3)
                        currentDirectory.LevelOneFiles.Add(fileMatch.Groups[2].Value, Convert.ToInt32(fileMatch.Groups[1].Value));
                }
            }

            Console.WriteLine($"Puzzle 1 result: {allDirs.Sum(d => d.GetSize() <= 100000 ? d.GetSize() : 0)}");
        }

        private static void Puzzle2()
        {
            const int totalSpace = 70000000;
            const int minimalUnusedSpace = 30000000;
            int missingSpace = minimalUnusedSpace - (totalSpace - allDirs.First(d => d.Name == "/").GetTotalSize());

            Console.WriteLine($"Puzzle 2 answer: {allDirs.Where(d => d.GetSize() >= missingSpace).Min(d => d.GetSize())}");
        }

        private class Directory
        {
            public string Name;
            public int Depth;
            public Dictionary<string, Directory> InnerDirectories = new Dictionary<string, Directory>();
            public Dictionary<string, int> LevelOneFiles = new Dictionary<string, int>();

            public Directory(string name, int depth) { Name = name; Depth = depth; }

            public int GetTotalSize()
            {
                var innerDirsSize = 0;
                InnerDirectories.ToList().ForEach(kv => innerDirsSize += kv.Value.GetTotalSize());
                return LevelOneFiles.Values.Sum() + innerDirsSize;
            }

            public int GetSize()
            {
                var innerFilesSize = LevelOneFiles.Values.Sum();
                InnerDirectories.ToList().ForEach(kv => innerFilesSize += kv.Value.GetSize());
                return innerFilesSize;
            }
        }
    }
}
