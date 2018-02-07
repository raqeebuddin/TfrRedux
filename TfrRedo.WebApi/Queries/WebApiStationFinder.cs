using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
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
            var _restUri = String.Format(
                $"https://api.tfl.gov.uk/Stoppoint/Search/{statiion.Name}?modes=tube&useMultiModalCall=false");
            using (WebClient client = new WebClient())
            {
                var json = client.DownloadString(_restUri);
                var searchDetails = JsonConvert.DeserializeObject<StationFinderResponseModel>(json);

                return await Task.FromResult(searchDetails);
            }
        }
    }

}
