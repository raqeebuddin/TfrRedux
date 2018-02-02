using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Stations
{
    public class Station : IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string IcsId { get; set; }
        public string Url { get; set; }
        public double? Lat { get; set; }
        public double? Lon { get; set; }
    }
}
