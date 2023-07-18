using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing
{
    public class FileReader: IFileReader
    {
        public FileReader() { }
        public async Task<Dictionary<string, int>> readFiles(IEnumerable<string> pathes)
        {
            Dictionary<string, int> order = new Dictionary<string, int>();
            foreach (string path in pathes)
            {
                await readFile(path, order).ConfigureAwait(false);
            }
            return order;
        }

        public async Task readFile(string path, Dictionary<string, int> order)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string? headerLine = await reader.ReadLineAsync().ConfigureAwait(false);
                string? line;
                while ((line = await reader.ReadLineAsync().ConfigureAwait(false)) != null)
                {
                    parseLine(line, order);
                }
            }
        }

        public void parseLine(string line, Dictionary<string, int> order)
        {
            string[] values = line.Split(",");
            string product = values[0];
            int quantity = int.Parse(values[1]);
            order[product] = order.TryGetValue(product, out int oldQuantity) ? oldQuantity + quantity : quantity;
        }

    }
}
