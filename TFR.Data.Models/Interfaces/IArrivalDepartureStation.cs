using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFR.Data.Models.Interfaces
{
    public interface IArrivalDepartureStation
    {
        int DepartureId { get; set; }
        string DepartureStation { get; set; }
        int ArrivalId { get; set; }
        string ArrivalStation { get; set; }

    }
}
