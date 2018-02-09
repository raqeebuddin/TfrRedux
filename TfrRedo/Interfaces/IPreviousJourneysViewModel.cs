using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFR.Data.Models.Journey;

namespace TfrRedo.ViewModels
{
    public interface IPreviousJourneysViewModel
    {
        List<Journey> Journeys { get; set; }
    }
    
}
