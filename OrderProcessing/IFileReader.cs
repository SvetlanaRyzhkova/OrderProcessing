using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing
{
    public interface IFileReader
    {
        public Dictionary<string, int> readFiles(IEnumerable<string> pathes);
        public void readFile(string path, ref Dictionary<string, int> order);
        public void parseLine(string line, ref Dictionary<string, int> order);
    }
}
