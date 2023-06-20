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

        public int Run(string[] args)
        {
            var opts = Parser.Default.ParseArguments<CommandLineOptions>(args);
            if (opts.Value == null) return 0;
            IEnumerable<string> inputPathes = opts.Value.InputFiles;
            string outputPath = opts.Value.OutputFile;

            Dictionary<string, int> order = fileReader.readFiles(inputPathes);

            fileWriter.writeInFile(outputPath, order);

            return 0;
        }
    }
}
