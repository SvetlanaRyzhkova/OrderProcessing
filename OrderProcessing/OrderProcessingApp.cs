using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing
{
    public class OrderProcessingApp
    {
        private readonly IFileWriter fileWriter;
        private readonly IFileReader fileReader;
        public OrderProcessingApp(IFileWriter fileWriter, IFileReader fileReader) 
        { 
            this.fileWriter = fileWriter;
            this.fileReader = fileReader;
        }

        public void Run(string[] args)
        {
            var opts = Parser.Default.ParseArguments<CommandLineOptions>(args);
            IEnumerable<string> inputPathes = opts.Value.InputFiles;
            string outputPath = opts.Value.OutputFile;

            Dictionary<string, int> order = fileReader.readFiles(inputPathes);

            fileWriter.writeInFile(outputPath, order);
        }
    }
}
