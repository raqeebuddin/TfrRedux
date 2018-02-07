using Domain.Stations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TfrRedo.Services.SearchStations.Queries.JourneyFinder;

namespace TfrRedo.Services.Interfaces
{
    public interface iWebApiJourneyFinder
    {
         Task<JourneyFinderResponseModel> JourneyFinder(string dartureStationIcsId, string arrivalIcsId);
    }
}
