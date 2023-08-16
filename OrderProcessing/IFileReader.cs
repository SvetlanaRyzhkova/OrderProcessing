using OrderProcessing.Model;

namespace OrderProcessing
{
    public interface IFileReader
    {
        public Task<IEnumerable<Order>> readFiles(IEnumerable<string> pathes, bool ignore);
        public Task readFileAndIgnoreWrongPath(string path, List<Order> order);
        public Task readFile(string path, List<Order> order);
    }
}
