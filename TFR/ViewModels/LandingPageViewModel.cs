using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFR.Data.Models.Interfaces;

namespace TFR.ViewModels
{
    public class LandingPageViewModel : ILandingPageViewModel
    {
        public List<IArrivalDepartureStation> Stations { get; set; }
    }
}