using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using log4net;
using TfrRedo.Services.Interfaces;
using TFR.Data.Models.Journey;
using TfrRedo.DataAccessSql;

namespace TfrRedo.DataAccess
{
    public class DatabaseService : IDatabaseService
    {
        ILog log = log4net.LogManager.GetLogger(typeof(DatabaseService));
        private readonly TfrContext _tfrContext = new TfrContext();

        public void Save(Journey journey)
        {
            try
            {
                _tfrContext.Journey.Add(journey);
                _tfrContext.SaveChanges();
            }
            catch (Exception e)
            {
                log.Fatal($"Error in saving journey to data base. Exception = {e}");
                Console.WriteLine(e);
                throw;
            }
           
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