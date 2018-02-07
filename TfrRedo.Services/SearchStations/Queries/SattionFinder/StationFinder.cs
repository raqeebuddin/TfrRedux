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

        public List<StationFinderResponseModel> Get(Station departure, Station arrival)
        {
            List<StationFinderResponseModel> departureArrivalStationList = new List<StationFinderResponseModel>();

            var departureStationDetailsAsync = _webApiStationFinder.stationFinder(departure);
            var arrivalStationDetailsAsync = _webApiStationFinder.stationFinder(arrival);

            var departureStationDetails = departureStationDetailsAsync.Result;
            var arrivalStationDetails = arrivalStationDetailsAsync.Result;
            departureArrivalStationList.Add(departureStationDetails);
            departureArrivalStationList.Add(arrivalStationDetails);

            return departureArrivalStationList;
        }
    }
}
