using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFR.Data.Models;

namespace TFR.ViewModels
{
    interface ILandingPageViewModel
    {
        IEnumerable<IStation> Stations { get; set; }
    }
}
