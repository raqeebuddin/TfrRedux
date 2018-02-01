using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFR.Services.WebService.Helpers
{
    public class ApplicationSettings
    {
        public static string GetStationUri => (ConfigurationManager.AppSettings["GetStationUri"]);
        
    }
}
