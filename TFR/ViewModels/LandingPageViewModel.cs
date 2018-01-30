using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFR.Data.Models;

namespace TFR.ViewModels
{
    public class LandingPageViewModel : ILandingPageViewModel
    {
        public IEnumerable<IStation> Stations { get; set; }
    }
}