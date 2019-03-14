using System;
using System.Collections.Generic;
using System.IO;
using Domain.Model;
using NUnit.Framework;

namespace SaverUnitTests
{
    [TestFixture]
    public class SaverTests
    {
        private string _path;
        private Saver _saver;

        [SetUp]
        public void Init()
        {
            _path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test.txt");
            _saver = new Saver();
        }

        [Test]
        public void SaverInitFile_Test()
        {
            _saver.InitFile(_path);

            Assert.IsTrue(File.Exists(_path)); 
        }

        [Test]
        public void SaverWriteLine_Test()
        {
            _saver.InitFile(_path);
            string testLine = "This is test line";
            _saver.WriteLine(testLine);
            bool check = false;

            using (StreamReader stream = new StreamReader(_path))
                check = stream.ReadLine() == testLine;

            Assert.IsTrue(check);
        }

        [Test]
        public void SaverWriteLines_Test()
        {
            _saver.InitFile(_path);
            List<string> testList = new List<string>() { "Row 1", "Row 2", "Row 3" };
            _saver.WriteLines(testList);

            using (StreamReader stream = new StreamReader(_path))
            {
                foreach (string s in testList)
                {
                    if (s != stream.ReadLine()) Assert.Fail();
                }
            }

            Assert.Pass();
        }
    }
}