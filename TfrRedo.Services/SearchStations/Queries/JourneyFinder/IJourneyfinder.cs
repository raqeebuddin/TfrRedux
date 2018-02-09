using System.Collections.Generic;
using TFR.Data.Models.Journey;

namespace TfrRedo.Services.SearchStations.Queries.JourneyFinder
{
    public interface IJourneyfinder
    {
        Journey Get(string departureStationIcsId, string arrivalStationIcsId);
        List<Journey> GetAllJourneys();
    }
}
