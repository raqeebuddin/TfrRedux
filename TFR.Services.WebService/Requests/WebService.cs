using Newtonsoft.Json;
using System;
using System.Net;
using TFR.Data.Models;
using TFR.Services.WebService.Helpers;
using TFR.Services.WebService.Interfaces;
using TFR.WebServices.Models.Responses;

namespace TFR.Services.WebService.Requests
{
    public class WebService : IWebService
    {
        private readonly string _getStationUri = ApplicationSettings.GetStationUri;

        public void GetJourneyList(IStation departure, IStation arrival)
        {
          
        }

        public WebServiceResponseModel GetStation(IStation station)
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
