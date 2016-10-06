using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FilesTasks.Parsing
{
    class TextFileReader
    {
        public static IEnumerable<string> ReadLines(string filePath, int codepage = 1251)
        {
            var file = new StreamReader(filePath, Encoding.GetEncoding(codepage));
            string line;

            while ((line = file.ReadLine()) != null)
            {
                yield return line;
            }

            file.Close();
        }
    }
}
