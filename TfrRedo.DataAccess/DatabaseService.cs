using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFR.Data.Models.Journey;
using TfrRedo.Services.Interfaces;

namespace TfrRedo.DataAccess
{
    public class DatabaseService : IDatabaseService
    {
        private TfrContext _tfrContext = new TfrContext();
       
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
        public List<Journey> AllJourneys()
        {
            var journeys = _tfrContext.Journey.ToList();

            return journeys;
        }
    }
}
