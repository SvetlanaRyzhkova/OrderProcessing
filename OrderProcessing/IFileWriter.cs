using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing
{
    public interface IFileWriter
    {
        public Task writeInFile(string path, Dictionary<string, int> order);
    }
}
