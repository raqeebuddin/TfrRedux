using Domain.Stations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TfrRedo.Services.SearchStations.Queries.GetStationDetails;

namespace TfrRedo.Services.Interfaces
{
    public interface iWebApiStationFinder
    {
        StationFinderResponseModel GetStationDetails(Station statiion);
    }
}
