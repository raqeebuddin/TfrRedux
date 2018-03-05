using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TfrRedo.Services.Interfaces;
using TFR.Data.Models.Journey;
using TfrRedo.DataAccessSql;

namespace TfrRedo.DataAccess
{
    public class DatabaseService : IDatabaseService
    {
        private readonly TfrContext _tfrContext = new TfrContext();

        public void Save(Journey journey)
        {
            _tfrContext.Journey.Add(journey);
            _tfrContext.SaveChanges();
        }

        public void Delete(Journey journey)
        {
            _tfrContext.Journey.Remove(journey);
            _tfrContext.SaveChanges();
        }

        public IEnumerable<Journey> AllJourneys()
        {
            var journeys = _tfrContext.Journey.ToList();

            return journeys;
        }
    }
}