﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing
{
    public class FileWriter: IFileWriter
    {
        public FileWriter() { } 
        public void writeInFile(string path, Dictionary<string, int> order)
        {
            using (StreamWriter writer = File.CreateText(path))
            {
                writer.WriteLine("Product,Quantity");
                foreach (string key in order.Keys)
                {
                    writer.WriteLine(key + "," + order[key]);
                }
            }
        }
    }
}
