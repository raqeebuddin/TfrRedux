using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronWebScraper;

namespace Inheritencepp1
{
    public class DerivedWebScraper
: WebScraper
    {
        public new bool ObeyRobotsDotTxt = false;
        public override void Init()
        {
            
        }

        public override void Parse(Response response)
        {
            throw new NotImplementedException();
        }
    }
}
