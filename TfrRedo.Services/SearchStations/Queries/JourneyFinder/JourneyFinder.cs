﻿using System.Collections.Generic;
using TfrRedo.Services.Interfaces;
using TFR.Data.Models.Journey;
using TfrRedo.DataAccessSql;

namespace TfrRedo.Services.SearchStations.Queries.JourneyFinder
{
    public class JourneyFinder : IJourneyfinder
    {
        private readonly IDatabaseService _databaseService;
        private readonly IWebApiJourneyFinder _webApiJourneyFinder;

        public JourneyFinder(IWebApiJourneyFinder webApiJourneyFinder, IDatabaseService databaseService)
        {
            _webApiJourneyFinder = webApiJourneyFinder;
            _databaseService = databaseService;
        }

        public Journey Get(string departureStationIcsId, string arrivalStationIcsId)
        {
            var journeyDetailsAsync = _webApiJourneyFinder.JourneyFinderAsync(departureStationIcsId, arrivalStationIcsId);
            var journeyDetails = journeyDetailsAsync.Result.Journeys[0];
            _databaseService.Save(journeyDetails);

            return journeyDetails;
        }

        public IEnumerable<Journey> GetAllJourneys()
        {
            var journeys = _databaseService.AllJourneys();
            return journeys; 
        }
    }
}