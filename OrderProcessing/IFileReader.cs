using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing
{
    public interface IFileReader
    {
        public Task<Dictionary<string, int>> readFiles(IEnumerable<string> pathes);
        public Task readFile(string path, Dictionary<string, int> order);
        public void parseLine(string line, Dictionary<string, int> order);
    }
}
