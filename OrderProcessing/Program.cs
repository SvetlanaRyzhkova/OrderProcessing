using OrderProcessing;

public class Program
{
    static async Task Main(string[] args)
    {
        FileReader fileReader = new FileReader();
        FileWriter fileWriter = new FileWriter();
        OrderProcessingApp app = new OrderProcessingApp(fileWriter, fileReader);
        await app.Run(args).ConfigureAwait(false);
    }
}
