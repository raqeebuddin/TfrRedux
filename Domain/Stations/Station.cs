using Domain.Common;

namespace Domain.Stations
{
    public class Station : IEntity
    {
        public string Name { get; set; }
        public string IcsId { get; set; }
        public string Url { get; set; }
        public double? Lat { get; set; }
        public double? Lon { get; set; }
        public string Id { get; set; }
    }
}