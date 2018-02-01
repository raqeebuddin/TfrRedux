using Newtonsoft.Json;
using System;
using System.Net;
using TFR.Data.Models;
using TFR.Data.Models.Stations;
using TFR.WebServices.Models.Interfaces;
using TFR.WebServices.Models.Responses;

namespace TFR.WebServices.Models.Requests
{
    public class WebService : IWebService
    {

        public void GetJourneyList(IStation departure, IStation arrival)
        {
          
        }

        public WebServiceResponseModel GetStation(Station station)
        {
            var _uri = String.Format(
                     $"https://api.tfl.gov.uk/Stoppoint/Search/{station.Name}?modes=tube&useMultiModalCall=false");
            using (WebClient client = new WebClient())
            {
                var json = client.DownloadString(_uri);
                var  data = JsonConvert.DeserializeObject<WebServiceResponseModel>(json);

                return data;
            }
        }
    }
}
