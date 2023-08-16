using System.Globalization;
using CsvHelper;
using OrderProcessing.Model;

namespace OrderProcessing
{
    public class FileReader: IFileReader
    {
        public FileReader() { }
        public async Task<IEnumerable<Order>> readFiles(IEnumerable<string> pathes, bool ignore)
        {
            List<List<Order>> orders = new List<List<Order>>();
            List<Task> tasks = new List<Task>();
            foreach (string path in pathes)
            {
                List<Order> orderFromOneFile = new List<Order>();
                Task task = Task.Run(() =>
                {
                    if (ignore)
                    {
                        return readFileAndIgnoreWrongPath(path, orderFromOneFile);
                    }
                    else
                    {
                        return readFile(path, orderFromOneFile);
                    }
                });
                orders.Add(orderFromOneFile);
                tasks.Add(task);
            }
            await Task.WhenAll(tasks).ConfigureAwait(false);

            return orders.Aggregate((first, second) => first.Concat(second).ToList())
                .GroupBy(o => o.product).Select(o => new Order { product = o.Key, quantity = o.Sum(o => o.quantity) });
        }

        public async Task readFileAndIgnoreWrongPath(string path, List<Order> order)
        {
            try
            {
                await readFile(path, order).ConfigureAwait(false);
            }
            catch (DirectoryNotFoundException e)
            { 
                Console.WriteLine(e.Message);
            }
        }

        public async Task readFile(string path, List<Order> order)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    IAsyncEnumerable<Order> records = csv.GetRecordsAsync<Order>();
                    await foreach (Order record in records.ConfigureAwait(false))
                    {
                        order.Add(record);
                    }
                }
            }
        }
    }
}
