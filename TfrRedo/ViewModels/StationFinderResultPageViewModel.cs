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
        public IList<Station> Stations { get; set; }

        public string SelectedStationIcsId { get; set; }

        public IEnumerable<SelectListItem> StationItems
        {
            get { return new SelectList(Stations, "IcsId", "Name"); }
        }
    }
}