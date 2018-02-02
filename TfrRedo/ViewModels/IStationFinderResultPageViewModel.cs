using Domain.Stations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfrRedo.ViewModels
{
    public interface IStationFinderResultPageViewModel
    {
        IList<Station> Stations { get; set; }
    }
}
