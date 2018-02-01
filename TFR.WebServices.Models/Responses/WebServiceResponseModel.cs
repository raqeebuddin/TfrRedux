using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFR.Data.Models;
using TFR.Data.Models.Stations;
using TFR.WebServices.Models.Interfaces;

namespace TFR.WebServices.Models.Responses
{
    public class WebServiceResponseModel: IWebServiceResponseModel
    {
        public string Query { get; set; }
        public int From { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string Provider { get; set; }
        public int Total { get; set; }
        public IEnumerable<Station> Matches { get; set; }
        public double? MaxScore{ get; set;}
    }
    
}
