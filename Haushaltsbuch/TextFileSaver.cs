using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Haushaltsbuch
{
    public class TextFileSaver
    {
        public void SaveTextFile(string filename, List<string> data)
        {
            File.WriteAllLines(filename, data);
        }
    }
}