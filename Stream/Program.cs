using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stream
{
    class Program
    {
        static void Main(string[] args)
        {

            string fileName = "numbers.txt";
            if(!File.Exists(fileName))
            {
                Console.WriteLine("The text file does not exists");
            }
            using (StreamReader sr = new StreamReader(fileName))
            {
               string line;
               while((line = sr.ReadLine()) != null)
               {
                 Console.WriteLine(line);
               }
            }
            Console.ReadKey();
        }
    }
}
