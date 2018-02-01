using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFR.Data.Models;
using TFR.WebServices.Models.Responses;

namespace TFR.WebServices.Models.Interfaces
{
    public interface IWebServiceResponseModel
    {
        string Query { get; set; }
        int From { get; set; }
        int Page { get; set; }
        int PageSize { get; set; }
        string Provider { get; set; }
        int Total { get; set; }
        IEnumerable<IStation> Matches { get; set; }
        double? MaxScore { get; set; }
    }
}
