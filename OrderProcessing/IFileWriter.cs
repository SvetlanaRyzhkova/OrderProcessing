using OrderProcessing.Model;

namespace OrderProcessing
{
    public interface IFileWriter
    {
        public Task writeInFile(string path, IEnumerable<Order> order);
    }
}
