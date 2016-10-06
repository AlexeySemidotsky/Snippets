using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace FilesTasks.Parsing.Tests
{
    [TestFixture]
    public class RegexpSearcherTests
    {
        [Test]
        public void Find_Lines_From_File_By_Regexp()
        {
            var testEntities = new List<TestEntity>()
            {
                new TestEntity("ERROR", 1234, new Guid("aeda1ea5-b49d-48cc-88d8-42e3970b2ea8")),
                new TestEntity("ERROR", 43, Guid.NewGuid()),
                new TestEntity("WARNING", 1212, Guid.NewGuid()),
                new TestEntity("ERROR", 54321, new Guid("dfa2259a-921c-4372-a4cc-5922bbdc51de"))
            };

            string filePath = "D:\\Logs\\RegexpSearcherTest.txt";

            var stringBuilder = new StringBuilder();
            testEntities.ForEach(e => stringBuilder.AppendLine($"{e.Data} in line {e.Line}, with id {e.Id}"));
            File.WriteAllText(filePath, stringBuilder.ToString());

            string regexpFull = "ERROR.*";
            string regexpDetails = @".*in line.*(\d{4,5}).* with id (.{36})";

            var lines = RegexpSearcher.Find(RegexpSearcher.Find(TextFileReader.ReadLines(filePath), regexpFull, (line, match) => line), regexpDetails, (s, match) =>
            {
                var line = Int32.Parse(match.Groups[1].Value);
                var id = Guid.Parse(match.Groups[2].Value);
                return new TestEntity(s, line, id);
            }).ToList();

            Assert.AreEqual(2, lines.Count);
            Assert.AreEqual(lines[0].Line, 1234);
            Assert.AreEqual(lines[0].Id, new Guid("aeda1ea5-b49d-48cc-88d8-42e3970b2ea8"));
            Assert.AreEqual(lines[1].Line, 4321);
            Assert.AreEqual(lines[1].Id, new Guid("dfa2259a-921c-4372-a4cc-5922bbdc51de"));
        }
    }

    class TestEntity
    {
        public TestEntity(string data, int line, Guid id)
        {
            Data = data;
            Line = line;
            Id = id;
        }

        public string Data { get; set; }
        public int Line { get; set; }
        public Guid Id { get; set; }
    }
}
