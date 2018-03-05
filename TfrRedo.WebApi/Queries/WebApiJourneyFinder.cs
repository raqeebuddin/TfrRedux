using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TfrRedo.Services.Interfaces;
using TfrRedo.Services.SearchStations.Queries.JourneyFinder;
using TfrRedo.Services.SearchStations.Queries.stationFinder;
using TFR.Data.Models.Journey;

namespace TfrRedo.WebApi.Queries
{
    public class WebApiJourneyFinder : IWebApiJourneyFinder
    {
        public async Task<JourneyFinderResponseModel> JourneyFinderAsync(string departureStationIcsId,
            string arrivalStationIcsId)
        {
            try
            {
                var findJourneyApi = (
                $"https://api.tfl.gov.uk/journey/journeyresults/{departureStationIcsId}/to/{arrivalStationIcsId}?&mode=tube");

                using (var client = new WebClient())
                {
                    var json = client.DownloadString(findJourneyApi);
                    var journeys = JsonConvert.DeserializeObject<JourneyFinderResponseModel>(json);

                    return await Task.FromResult(journeys);
                }
            }
            catch (Exception e)
            {
                var emptySearchDeatils = new JourneyFinderResponseModel();

                emptySearchDeatils.Journeys.Add(new Journey()
                {
                    Id = 00000,
                    StartDateTime = DateTime.Now,
                    Duration = 0,
                    ArrivalDateTime = DateTime.Now
                });
                return emptySearchDeatils;
            }
        }
    }
}