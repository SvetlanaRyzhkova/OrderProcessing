using OrderProcessing;

public class Program
{
    static int Main(string[] args)
    {
        
        FileReader fileReader = new FileReader();
        FileWriter fileWriter = new FileWriter();
        OrderProcessingApp app = new OrderProcessingApp(fileWriter, fileReader);
        app.Run(args);
        
        return 0;
    }
}
