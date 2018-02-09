using System.Collections.Generic;
using TFR.Data.Models.Journey;

namespace TfrRedo.Services.SearchStations.Queries.JourneyFinder
{
    public class JourneyFinderResponseModel
    {
        public List<Journey> Journeys { get; set; }
    }
}