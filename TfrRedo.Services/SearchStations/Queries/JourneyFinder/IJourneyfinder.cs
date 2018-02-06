using Domain.Stations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFR.Data.Models.Journey;

namespace TfrRedo.Services.SearchStations.Queries.JourneyFinder
{
    public interface IJourneyfinder
    {
       Journey Get(string stationIcsId);
    }
}
