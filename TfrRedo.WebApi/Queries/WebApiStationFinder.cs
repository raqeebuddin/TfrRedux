using System;
using System.Net;
using System.Threading.Tasks;
using Domain.Stations;
using log4net;
using Newtonsoft.Json;
using TfrRedo.Services.Interfaces;
using TfrRedo.Services.SearchStations.Queries.stationFinder;

namespace TfrRedo.WebApi.Queries
{
    public class WebApiStationFinder : IWebApiStationFinder
    {
        ILog log = log4net.LogManager.GetLogger(typeof(WebApiStationFinder));
        public async Task<StationFinderResponseModel> StationFinder(Station station)
        {
            try
            {
                var findStationApi = (
                                $"https://api.tfl.gov.uk/Stoppoint/Search/{station.Name}?modes=tube&useMultiModalCall=false");
                using (var client = new WebClient())
                {
                    var json = client.DownloadString(findStationApi);
                    var searchDetails = JsonConvert.DeserializeObject<StationFinderResponseModel>(json);
                    log.Debug($"Station finder has returned {searchDetails.Matches[1].Name} sucessfully");
                    return await Task.FromResult(searchDetails);
                }
            }
            catch (Exception e)
            {
                log.Fatal($"Error from Stationfinder method/ for station.name of: {station.Name}/ system information: {e}");
                var emptySearchDeatils = new StationFinderResponseModel();
                emptySearchDeatils.Matches[0].Name = "No stattions availble";
                emptySearchDeatils.Matches[0].Id = e.ToString();
                return emptySearchDeatils;
            }
        }
    }
}