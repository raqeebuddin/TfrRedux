using System.Collections.Generic;
using Domain.Stations;

namespace TfrRedo.ViewModels
{
    public interface IStationFinderResultPageViewModel
    {
        IList<IndexLandingPageModel> DepartureStations { get; set; }
        IList<IndexLandingPageModel> ArrivalStations { get; set; }
    }
}