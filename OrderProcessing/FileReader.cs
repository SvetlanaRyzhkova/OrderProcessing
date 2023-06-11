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
        public Dictionary<string, int> readFiles(IEnumerable<string> pathes)
        {
            Dictionary<string, int> order = new Dictionary<string, int>();
            foreach (string path in pathes)
            {
                readFile(path, ref order);
            }
            return order;
        }

        public void readFile(string path, ref Dictionary<string, int> order)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string headerLine = reader.ReadLine();
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    parseLine(line, ref order);
                }
            }
        }

        public void parseLine(string line, ref Dictionary<string, int> order)
        {
            string[] values = line.Split(",");
            string product = values[0];
            int quantity = int.Parse(values[1]);
            order[product] = order.TryGetValue(product, out int oldQuantity) ? oldQuantity + quantity : quantity;
        }

    }
}
