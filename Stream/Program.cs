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
        public static int CallTryParse(string stringToConvert)
        {
            int number;
            if (int.TryParse(stringToConvert, out number))
                Console.WriteLine(number);
            else
                Console.WriteLine("String could not be parsed.");
            return number;
        }
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
            StreamReader st = new StreamReader(fileName);
            string linevar;
            double isNumeric;
            while ((linevar = st.ReadLine()) != null)
            {
                if (CallTryParse(linevar)!= null)
                {
                    int result = CallTryParse(linevar);
                    using (StreamWriter sw = new StreamWriter(fileName_number))
                    {
                        sw.WriteLine(result);
                    }
                }
                else
                {
                    int result = CallTryParse(linevar);
                    using (StreamWriter sw = new StreamWriter(fileName_incorrect))
                    {
                        sw.WriteLine(result);
                    }

                }
            }
            Console.ReadKey();
        }
    }
}
