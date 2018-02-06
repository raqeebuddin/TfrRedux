using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Domain.Stations;
using TFR.Data.Models.Journey;
using TfrRedo.Services.Interfaces;
using TfrRedo.Services.SearchStations.Queries.JourneyFinder;

namespace TfrRedo.WebApi.Queries
{
    public class WebApiJourneyFinder  /*iWebApiJourneyFinder*/
    {
        
        public  async Task<JourneyFinderResponseModel>JourneyFinder(string stationIcsId)
        {
            var journeyCall = String.Format(
              $"https://api.tfl.gov.uk/journey/journeyresults/{stationIcsId}/to/1000013?&mode=tube");

            using (WebClient client = new WebClient())
            {
                var json = await client.DownloadStringTaskAsync(journeyCall);
                var  journeys =  Newtonsoft.Json.JsonConvert.DeserializeObject<JourneyFinderResponseModel>(json);

                return journeys;
            }
        }
    }
}
