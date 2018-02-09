using System.Collections.Generic;
using TFR.Data.Models.Journey;

namespace TfrRedo.ViewModels
{
    public interface IPreviousJourneysViewModel
    {
        IEnumerable<Journey> Journeys { get; set; }
    }
}