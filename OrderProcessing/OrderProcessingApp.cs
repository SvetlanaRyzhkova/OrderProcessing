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

        public async Task Run(string[] args)
        {
            await Parser.Default.ParseArguments<CommandLineOptions>(args).WithParsedAsync(async (CommandLineOptions opts) =>
            {
                IEnumerable<string> inputPathes = opts.InputFiles;
                string outputPath = opts.OutputFile;

                Dictionary<string, int> order = await fileReader.readFiles(inputPathes, opts.Ignore).ConfigureAwait(false);

                await fileWriter.writeInFile(outputPath, order).ConfigureAwait(false);

            }).ConfigureAwait(false);
        }
    }
}
