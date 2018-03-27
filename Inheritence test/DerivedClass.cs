using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritence_test
{
    public class DerivedClass:BaseClass
    {
        public DerivedClass()
        {
            this.ObeyRobotsDotTxtForHost("true");
        }
    }
}
