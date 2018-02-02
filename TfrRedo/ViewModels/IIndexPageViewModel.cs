using Domain.Stations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfrRedo.ViewModels
{
    interface IIndexPageViewModel
    {
        Station Arrival { get; set; }
    }
}
