using CsvHelper;
using OrderProcessing.Model;
using System.Globalization;

namespace OrderProcessing
{
    public class FileWriter: IFileWriter
    {
        public FileWriter() { } 
        public async Task writeInFile(string path, IEnumerable<Order> order)
        {
            using (StreamWriter writer = File.CreateText(path))
            {
                using (CsvWriter csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteHeader<Order>();
                    csv.NextRecord();
                    await csv.WriteRecordsAsync(order);
                }
            }
        }
    }
}
