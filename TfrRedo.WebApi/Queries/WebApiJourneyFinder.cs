using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Domain.Stations;
using TFR.Data.Models.Journey;
using TfrRedo.Services.Interfaces;
using TfrRedo.Services.SearchStations.Queries.JourneyFinder;

namespace TfrRedo.WebApi.Queries
{
    class WebApiJourneyFinder : iWebApiJourneyFinder
    {
        public JourneyFinderResponseModel JourneyFinder(Station station)
        {
            var journeyCall = String.Format(
              $"https://api.tfl.gov.uk/journey/journeyresults/{station.Name}/to/{station.Name}?&mode=tube");

            using (WebClient client = new WebClient())
            {
                var json = client.DownloadString(journeyCall);
                var journeys = Newtonsoft.Json.JsonConvert.DeserializeObject<JourneyFinderResponseModel>(json);


                return journeys;
            }
        }
    }
}
