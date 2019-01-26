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
            bool success = int.TryParse(stringToConvert, out number);
            if (success)
            {
                Console.WriteLine("Succes");
                return number;
            }
            else
            {
                return 0;
            }
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
            var characters = new List<string>();// add a new list
            StreamReader st = new StreamReader(fileName);
            string linevar;
            while ((linevar = st.ReadLine()) != null)
            {
                characters.Add(linevar);// put in list
                if (CallTryParse(linevar) != 0)
                {
                    int result = CallTryParse(linevar);
                    using (StreamWriter sw = new StreamWriter(fileName_incorrect))
                    {
                        sw.WriteLine(result);
                    }

                }
                else
                {
                    int result = CallTryParse(linevar);
                    using (StreamWriter sw = new StreamWriter(fileName_number))
                    {
                        sw.WriteLine(result);
                    }
                }
            }
            foreach (var character in characters)
            {
                Console.WriteLine(character);
            }

            Console.ReadKey();
        }
    }
}
