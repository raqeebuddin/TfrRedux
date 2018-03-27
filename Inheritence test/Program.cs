using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritence_test
{
    class Program
    {
        static void Main(string[] args)
        {
            DerivedClass derivedInstance = new DerivedClass();
            Console.WriteLine($"value of the instatntiated Derived Class = {derivedInstance.ObeyRobotsDotTxtForHost} ");
           
        }
    }
}
