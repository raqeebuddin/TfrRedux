using System.Threading.Tasks;
using Domain.Stations;
using TfrRedo.Services.SearchStations.Queries.stationFinder;

namespace TfrRedo.Services.Interfaces
{
    public interface iWebApiStationFinder
    {
        Task<StationFinderResponseModel> StationFinder(Station station);
    }
}