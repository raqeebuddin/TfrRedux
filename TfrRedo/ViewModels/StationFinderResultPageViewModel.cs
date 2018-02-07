using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Stations;

namespace TfrRedo.ViewModels
{
    public class StationFinderResultPageViewModel : IStationFinderResultPageViewModel
    {
        public IList<Station> DepartureStations { get; set; }
        public IList<Station> ArrivalStations { get; set; }

        public string SelectedStationIcsId { get; set; }

        public IEnumerable<SelectListItem> DepartureStationItems
        {
            get { return new SelectList(DepartureStations, "IcsId", "Name"); }
        }

        public IEnumerable<SelectListItem> ArrivalStationItems
        {
            get { return new SelectList(ArrivalStations, "IcsId", "Name"); }
        }
    }
}