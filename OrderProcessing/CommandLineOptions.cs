using CommandLine.Text;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OrderProcessing
{
    public class CommandLineOptions
    {
        [Value(index: 0, Required = true, HelpText = "Input files to read.")]
        public IEnumerable<string> InputFiles { get; set; }

        [Option(shortName:'o', longName: "Output file", Required = true, HelpText = "Output file to save.")]
        public string OutputFile { get; set; }

    }
}
