using System.Collections.Generic;
using Domain.Stations;

namespace TfrRedo.ViewModels
{
    public interface IStationFinderResultPageViewModel
    {
        IList<Station> DepartureStations { get; set; }
        IList<Station> ArrivalStations { get; set; }
    }
}