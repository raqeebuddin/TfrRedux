using System.Threading.Tasks;
using TfrRedo.Services.SearchStations.Queries.JourneyFinder;

namespace TfrRedo.Services.Interfaces
{
    public interface IWebApiJourneyFinder
    {
        Task<JourneyFinderResponseModel> JourneyFinderAsync(string dartureStationIcsId, string arrivalIcsId);
    }
}