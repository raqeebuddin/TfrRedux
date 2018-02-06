using Domain.Legs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFR.Data.Models.Journey;

namespace TfrRedo.Services.SearchStations.Queries.JourneyFinder
{
    public class JourneyFinderResponseModel
    {
       
        public List<Journey> Journeys { get; set; }
    }
}
