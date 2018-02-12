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
        public async Task<StationFinderResponseModel> StationFinder(Station statiion)
        {
            var findStattionApi = string.Format(
                $"https://api.tfl.gov.uk/Stoppoint/Search/{statiion.Name}?modes=tube&useMultiModalCall=false");
            using (var client = new WebClient())
            {
                var json = await client.DownloadStringTaskAsync(findStattionApi);
                var searchDetails = JsonConvert.DeserializeObject<StationFinderResponseModel>(json);

                return (searchDetails);
            }
        }
    }
}