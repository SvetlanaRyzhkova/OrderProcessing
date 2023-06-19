using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.Data;

namespace OrderProcessing.IntegrationTests
{
    [TestClass]
    public class OrderProcessingAppTests
    {
        [TestMethod]
        public void Run_CorrectValues_CorrectDataInOutputFile()
        {
            string cake = "C:\\Users\\svetl\\Documents\\MyProjects\\OrderProcessing\\OrderProcessing.IntegrationTests\\Orders\\Cake.csv";
            string icecream = "C:\\Users\\svetl\\Documents\\MyProjects\\OrderProcessing\\OrderProcessing.IntegrationTests\\Orders\\IceCream.csv";
            string output = "C:\\Users\\svetl\\Documents\\MyProjects\\OrderProcessing\\OrderProcessing.IntegrationTests\\Output.txt";
            string[,] productsCake = { {"sugar", "2" }, {"milk", "4" }, {"eggs", "10" } };
            string[,] productsIcecream = { {"sugar", "1" }, {"chocolate", "12" }, {"milk", "11" } };
            CSVFileGenerator generator = new CSVFileGenerator();
            generator.createCSVFile(cake, productsCake);
            generator.createCSVFile(icecream, productsIcecream);
            string[] args = { cake, icecream, "-o",  output};
            FileReader fileReader = new FileReader();
            FileWriter fileWriter = new FileWriter();
            OrderProcessingApp app = new OrderProcessingApp(fileWriter, fileReader);
            string[] result = { "Product,Quantity", "sugar,3", "milk,15", "eggs,10", "chocolate,12" };

            app.Run(args);

            using (StreamReader sr = new StreamReader(output))
            {
                for (int i = 0; i < result.Length; i++)
                {
                    string? line = sr.ReadLine();
                    StringAssert.Contains(line, result[i]);
                }
            }
        }

        public void Run_IncorrectValues_CorrectDataInOutputFile()
        {
            string cake = "C:\\Users\\svetl\\Documents\\MyProjects\\OrderProcessing\\OrderProcessing.IntegrationTests\\Orders\\Cake.csv";
            string icecream = "C:\\Users\\svetl\\Documents\\MyProjects\\OrderProcessing\\OrderProcessing.IntegrationTests\\Orders\\IceCream.csv";
            string output = "C:\\Users\\svetl\\Documents\\MyProjects\\OrderProcessing\\OrderProcessing.IntegrationTests\\Output.txt";
            string[,] productsCake = { { "sugar", "2" }, { "milk", "4" }, { "eggs", "10" } };
            string[,] productsIcecream = { { "sugar", "1" }, { "chocolate", "12" }, { "milk", "11" } };
            CSVFileGenerator generator = new CSVFileGenerator();
            generator.createCSVFile(cake, productsCake);
            generator.createCSVFile(icecream, productsIcecream);
            string[] args = { cake, icecream, "-o", output };
            FileReader fileReader = new FileReader();
            FileWriter fileWriter = new FileWriter();
            OrderProcessingApp app = new OrderProcessingApp(fileWriter, fileReader);
            string[] result = { "Product,Quantity", "sugar,3", "milk,15", "eggs,10", "chocolate,12" };

            app.Run(args);

            using (StreamReader sr = new StreamReader(output))
            {
                for (int i = 0; i < result.Length; i++)
                {
                    string? line = sr.ReadLine();
                    StringAssert.Contains(line, result[i]);
                }
            }
        }
    }
}