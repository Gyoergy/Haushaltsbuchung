using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Haushaltsbuch
{
    public class TextFileProvider
    {
        public List<string> ReadTextFile(string filename)
        {
            return File.ReadLines(filename).ToList();
        }
    }
}