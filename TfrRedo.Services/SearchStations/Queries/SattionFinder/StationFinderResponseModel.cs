﻿using Domain.Stations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfrRedo.Services.SearchStations.Queries.stationFinder
{
    public class StationFinderResponseModel
    {
        public IList<Station> Matches { get; set; }
    }
}