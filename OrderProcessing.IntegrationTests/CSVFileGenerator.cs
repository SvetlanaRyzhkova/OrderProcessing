using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.IntegrationTests
{
    public class CSVFileGenerator
    {
        public void createCSVFile(string path, string[,] data)
        {
            using (StreamWriter writer = File.CreateText(path))
            {
                writer.WriteLine(Constants.TITLE);
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    writer.WriteLine($"{data[i,0]},{data[i, 1]}");
                }
            }
        }
    }
}
