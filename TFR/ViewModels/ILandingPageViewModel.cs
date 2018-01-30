using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFR.Data.Models.Interfaces;

namespace TFR.ViewModels
{
    public interface ILandingPageViewModel
    {
        List<IArrivalDepartureStation> Stations { get; set; }
    }
}
