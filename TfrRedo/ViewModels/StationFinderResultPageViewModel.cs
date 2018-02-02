using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Stations;

namespace TfrRedo.ViewModels
{
    public class StationFinderResultPageViewModel : IStationFinderResultPageViewModel
    {
        public IList<Station> Stations { get; set; }
    }
}