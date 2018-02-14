using System.Collections.Generic;
using Domain.Stations;

namespace TfrRedo.Services.SearchStations.Queries.stationFinder
{
    public interface IStationFinder
    {
        List<StationFinderResponseModel> Get(IndexLandingPageModel departure, IndexLandingPageModel arrival);
    }
}