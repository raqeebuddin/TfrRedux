using Domain.Stations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfrRedo.Services.SearchStations.Queries.stationFinder
{
    public class StationFinderResponseModel
    {
        public string Query { get; set; }
        public int From { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string Provider { get; set; }
        public int Total { get; set; }
        public IList<Station> Matches { get; set; }
        public double? MaxScore { get; set; }
    }
}
