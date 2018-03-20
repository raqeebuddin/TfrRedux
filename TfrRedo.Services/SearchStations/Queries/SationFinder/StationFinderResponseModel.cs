using System.Collections.Generic;
using Domain.Stations;

namespace TfrRedo.Services.SearchStations.Queries.stationFinder
{
    public class StationFinderResponseModel
    {
        public IList<Station> Matches { get; set; }
    }
}