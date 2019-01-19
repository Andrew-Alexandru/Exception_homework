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
            string fileName_number = "correctNumbers.txt";
            string fileName_incorrect = "incorrectNumbers.txt";
            if (!File.Exists(fileName_number))
            {
                Console.WriteLine("The text file with correct numbers does not exists");
                File.Create(fileName_number);
            }
            if (!File.Exists(fileName_incorrect))
            {
                Console.WriteLine("The text file with wrong numbers does not exists");
                File.Create(fileName_incorrect);
            }
            Console.ReadKey();
        }
    }
}
