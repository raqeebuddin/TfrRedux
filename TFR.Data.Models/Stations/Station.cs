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
        public int Id { get; set; }
        public string NaptanId { get; set; }
        public string IcsId { get; set; }
        public string Name { get; set; }
        public string Fare { get; set; }
        public int? CaloriesBurned { get; set; }
    }
}
