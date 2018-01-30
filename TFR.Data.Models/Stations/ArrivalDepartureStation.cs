using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFR.Data.Models.Interfaces;

namespace TFR.Data.Models.Stations
{
    class ArrivalDepartureStation : IArrivalDepartureStation
    {
        public int DepartureId { get; set; }
        public string DepartureStation { get; set; }
        public int ArrivalId { get; set; }
        public string ArrivalStation { get; set; }
    }
}
