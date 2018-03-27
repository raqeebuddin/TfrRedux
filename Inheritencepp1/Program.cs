using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritencepp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DerivedWebScraper instanceDerivedWebScraper = new DerivedWebScraper();
            
            Console.WriteLine(instanceDerivedWebScraper.ObeyRobotsDotTxt);
            Console.ReadLine();
        }
    }
}
