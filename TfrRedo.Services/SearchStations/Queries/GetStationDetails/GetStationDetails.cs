using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Stations;
using TfrRedo.Services.Interfaces;

namespace TfrRedo.Services.SearchStations.Queries.GetStationDetails
{
    public class GetStationDetails
        : IGetStationDetails
    {
        private readonly iWebApiStationFinder _webApiStationFinder;

        public GetStationDetails(iWebApiStationFinder webApiStationFinder)
        {
            _webApiStationFinder = webApiStationFinder;
        }

        public StationDetailModel Get(Station station)
        {
            var stationDetails = _webApiStationFinder.GetStationDetails(station);
            return stationDetails;
        }
    }
}
