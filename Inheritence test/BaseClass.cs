using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritence_test
{
    public abstract class BaseClass
    {
        public virtual bool ObeyRobotsDotTxtForHost(
            string Host
        )
        {
            if (Host == "true")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
