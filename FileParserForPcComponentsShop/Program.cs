using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileParserForPcComponentsShop
{
    class Program
    {
        static void FirstPartParser(StreamReader sr, int lineSkipLength)
        {
            string line;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                if (line.Contains("name:"))
                Console.WriteLine(line);
            }
        }
        static void Main(string[] args)
        {
            string path = @"C:\Users\Алексей\Desktop\Корпуса.txt";
            StreamReader sr = new StreamReader(path, Encoding.Default);
            FirstPartParser(sr, 5);
            sr.Close();
            
            Console.ReadLine();
        }
    }
}
