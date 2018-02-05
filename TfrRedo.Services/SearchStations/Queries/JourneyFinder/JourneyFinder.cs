using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Stations;
using TFR.Data.Models.Journey;
using TfrRedo.Services.Interfaces;

namespace TfrRedo.Services.SearchStations.Queries.JourneyFinder
{
    public class JourneyFinder : IJourneyfinder
    {
        private readonly iWebApiJourneyFinder _webApiJourneyFinder;
        public JourneyFinder(
            iWebApiJourneyFinder webApiJourneyFinder)
        {
            _webApiJourneyFinder = webApiJourneyFinder;
        }
        public Journey Get(string stationIcsId)
        {
            var journeyDetails = _webApiJourneyFinder.JourneyFinder(stationIcsId);

            return journeyDetails.Journeys[0];
        }
    }
}
