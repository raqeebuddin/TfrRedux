using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFR.Data.Models.Stations
{
    public class Station : IStation
    {
        public string StationId { get; set; }
        public string IcsId { get; set; }
        public string Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public double? Lat { get; set; }
        public double? Lon { get; set; }
        public string Fare { get; set; }
        public int? CaloriesBurned { get; set; }
    }
}
