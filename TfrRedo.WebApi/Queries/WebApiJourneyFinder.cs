using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TfrRedo.Services.Interfaces;
using TfrRedo.Services.SearchStations.Queries.JourneyFinder;

namespace TfrRedo.WebApi.Queries
{
    public class WebApiJourneyFinder : IWebApiJourneyFinder
    {
        public async Task<JourneyFinderResponseModel> JourneyFinderAsync(string departureStationIcsId,
            string arrivalStationIcsId)
        {
            var journeyCall = string.Format(
                $"https://api.tfl.gov.uk/journey/journeyresults/{departureStationIcsId}/to/{arrivalStationIcsId}?&mode=tube");

            using (var client = new WebClient())
            {
                var json = client.DownloadString(journeyCall);
                var journeys = JsonConvert.DeserializeObject<JourneyFinderResponseModel>(json);

                return await Task.FromResult(journeys);
            }
        }
    }
}