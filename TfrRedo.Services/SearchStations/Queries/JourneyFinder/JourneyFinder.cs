using System.Collections.Generic;
using TFR.Data.Models.Journey;
using TfrRedo.Services.Interfaces;

namespace TfrRedo.Services.SearchStations.Queries.JourneyFinder
{
    public class JourneyFinder : IJourneyfinder
    {
        private readonly iWebApiJourneyFinder _webApiJourneyFinder;
        private readonly IDatabaseService _databaseService;

        public JourneyFinder(iWebApiJourneyFinder webApiJourneyFinder, IDatabaseService databaseService)
        {
            _webApiJourneyFinder = webApiJourneyFinder;
            _databaseService = databaseService;
        }

        public Journey Get(string departureStationIcsId, string arrivalStationIcsId)
        {
            var journeyDetailsAsync = _webApiJourneyFinder.JourneyFinder(departureStationIcsId, arrivalStationIcsId);
            var journeyDetails = journeyDetailsAsync.Result.Journeys[0];
            _databaseService.Save(journeyDetails);
           
            return journeyDetails;
        }

        public List<Journey> GetAllJourneys()
        {
            var journeys = _databaseService.AllJourneys();
            return journeys;
        }
    }
}
