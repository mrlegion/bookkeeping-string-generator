using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Domain.Model
{
    public class Saver : ISaver
    {
        private FileInfo _file;
        private FileStream _stream;

        public void InitFile(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));
            _file = new FileInfo(path);
            if (_file.Exists) _file.Delete();
            _file.Create();
        }

        public void SaveChanges()
        {
            _stream?.Close();
        }

        public void WriteLine(string line)
        {
            using (StreamWriter steam = new StreamWriter(_stream, Encoding.Unicode))
            {

            }
        }

        public void WriteLines(IEnumerable<string> lines)
        {
            throw new System.NotImplementedException();
        }
    }
}