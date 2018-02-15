using System.Collections.Generic;
using System.Web.Mvc;
using Domain.Stations;

namespace TfrRedo.ViewModels
{
    public class StationFinderResultPageViewModel : IStationFinderResultPageViewModel
    {
        public string SelectedDepartureStationIcsId { get; set; }
        public string SelectedArrivalStationIcsId { get; set; }

        public IEnumerable<SelectListItem> DepartureStationItems => new SelectList(DepartureStations, "IcsId", "Name");

        public IEnumerable<SelectListItem> ArrivalStationItems => new SelectList(ArrivalStations, "IcsId", "Name");

        public IList<Station> DepartureStations { get; set; }
        public IList<Station> ArrivalStations { get; set; }
    }
}