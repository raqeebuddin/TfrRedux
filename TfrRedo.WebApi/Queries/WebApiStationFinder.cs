using System;
using System.Net;
using System.Threading.Tasks;
using Domain.Stations;
using Newtonsoft.Json;
using TfrRedo.Services.Interfaces;
using TfrRedo.Services.SearchStations.Queries.stationFinder;

namespace TfrRedo.WebApi.Queries
{
    public class WebApiStationFinder : IWebApiStationFinder
    {    public async Task<StationFinderResponseModel>StationFinder(Station station)
        {
            try
            {
                var findStationApi =(
                                $"https://api.tfl.gov.uk/Stoppoint/Search/{station.Name}?modes=tube&useMultiModalCall=false");
                using (var client = new WebClient())
                {
                    var json = client.DownloadString(findStationApi);
                    var searchDetails = JsonConvert.DeserializeObject<StationFinderResponseModel>(json);

                    return await Task.FromResult(searchDetails);
                }
            }
            catch (Exception e)
            {
                var emptySearchDeatils = new StationFinderResponseModel();

                emptySearchDeatils.Matches[0].Name = "No stattions availble";
                emptySearchDeatils.Matches[0].Id = e.ToString();
                return emptySearchDeatils;
            }
        }
    }
}