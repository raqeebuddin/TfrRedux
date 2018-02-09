using System.Net;
using System.Threading.Tasks;
using Domain.Stations;
using Newtonsoft.Json;
using TfrRedo.Services.Interfaces;
using TfrRedo.Services.SearchStations.Queries.stationFinder;

namespace TfrRedo.WebApi.Queries
{
    public class WebApiStationFinder : iWebApiStationFinder
    {
        public async Task<StationFinderResponseModel> stationFinder(Station statiion)
        {
            var _restUri = string.Format(
                $"https://api.tfl.gov.uk/Stoppoint/Search/{statiion.Name}?modes=tube&useMultiModalCall=false");
            using (var client = new WebClient())
            {
                var json = client.DownloadString(_restUri);
                var searchDetails = JsonConvert.DeserializeObject<StationFinderResponseModel>(json);

                return await Task.FromResult(searchDetails);
            }
        }
    }
}