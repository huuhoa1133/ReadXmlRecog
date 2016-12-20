using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadXmlRecog
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ReadXmlModel read = new ReadXmlModel();
            read.LoadXml("RecogCharacterPlus.xml");


            List<double> w12 = read.GetW12();
            List<double> bias2 = read.GetBias2();
            List<double> w23 = read.GetW23();
            List<double> bias3 = read.GetBias3();

            Console.ReadLine();
        }
    }
}
