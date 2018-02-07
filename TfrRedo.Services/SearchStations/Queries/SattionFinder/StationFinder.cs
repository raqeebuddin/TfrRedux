using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Stations;
using TfrRedo.Services.Interfaces;

namespace TfrRedo.Services.SearchStations.Queries.stationFinder
{
    public class StationFinder
        : IStationFinder
    {
        private readonly iWebApiStationFinder _webApiStationFinder;
        public StationFinder(
            iWebApiStationFinder webApiStationFinder)
        {
            _webApiStationFinder = webApiStationFinder;

        }

        public StationFinderResponseModel Get(Station station)
        {
            var stationDetailsAsync = _webApiStationFinder.stationFinder(station);
            var stationDetails = stationDetailsAsync.Result;
            return stationDetails;
        }

    }
}
