﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Domain.Model
{
    public class Saver : ISaver
    {
        private string _file;

        public void InitFile(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));
            _file = path;
            File.Create(_file).Close();
        }

        public void WriteLine(string line)
        {
            using (StreamWriter steam = new StreamWriter(File.OpenWrite(_file), Encoding.Unicode))
            {
                steam.WriteLine(line);
            }
        }

        public void WriteLines(IEnumerable<string> lines)
        {
            using (StreamWriter stream = new StreamWriter(File.OpenWrite(_file), Encoding.Unicode))
            {
                foreach (string line in lines)
                {
                    stream.WriteLine(line);
                }
            }
        }
    }
}