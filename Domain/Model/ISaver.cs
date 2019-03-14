using System.Collections.Generic;

namespace Domain.Model
{
    public interface ISaver
    {
        void InitFile(string path);
        void SaveChanges();
        void WriteLine(string line);
        void WriteLines(IEnumerable<string> lines);
    }
}