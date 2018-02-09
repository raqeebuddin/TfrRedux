using System.Collections.Generic;
using TFR.Data.Models.Journey;

namespace TfrRedo.ViewModels
{
    public class PreviousJourneysViewModel : IPreviousJourneysViewModel
    {
        public IEnumerable<Journey> Journeys { get; set; }
    }
}