using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFR.Data.Models.Journey;

namespace TfrRedo.ViewModels
{
    public class PreviousJourneysViewModel:IPreviousJourneysViewModel
    {
        public List<Journey> Journeys { get; set; }
    }
}