using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFR.Data.Models
{
    public interface IStation
    {
        string StationId { get; set; }
        string IcsId { get; set; }
        string Id { get; set; }
        string Url { get; set; }
        string Name { get; set; }
        double? Lat { get; set; }
        double? Lon { get; set; }
        string Fare { get; set; }
        Nullable<int> CaloriesBurned { get; set; }
    }
}
