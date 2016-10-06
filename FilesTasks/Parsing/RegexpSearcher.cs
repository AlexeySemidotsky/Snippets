using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FilesTasks.Parsing
{
    class RegexpSearcher
    {
        public static IEnumerable<T> Find<T>(string filePath, string regexpPattern, Func<string, Match, T> resultFactory)
        {
            return Find(TextFileReader.ReadLines(filePath), regexpPattern, resultFactory);
        }

        public static IEnumerable<T> Find<T>(IEnumerable<string> lines, string regexpPattern, Func<string, Match, T> resultFactory)
        {
            int counter = 0;

            foreach (var line in lines)
            {
                var match = Regex.Match(line, regexpPattern);
                if (match.Success)
                {
                    yield return resultFactory.Invoke(line, match);
                }

                counter++;

                if (counter % 10000 == 0) Console.WriteLine($"Обработано строк {counter}");
            }
        }
    }
}