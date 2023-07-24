using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing
{
    public class FileWriter: IFileWriter
    {
        public FileWriter() { } 
        public async Task writeInFile(string path, Dictionary<string, int> order)
        {
            using (StreamWriter writer = File.CreateText(path))
            {
                await writer.WriteLineAsync(Constants.TITLE).ConfigureAwait(false);
                foreach (string key in order.Keys)
                {
                    await writer.WriteLineAsync($"{key},{order[key]}").ConfigureAwait(false);
                }
            }
        }
    }
}
