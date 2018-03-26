using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
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
            try

            {
                _tfrContext.Journey.Remove(journey);
                _tfrContext.SaveChanges();
            }
            catch (Exception e)
            {
                log.Error($"Cannot initiate Delete from data base. Error message: {e}");
            }
        }

        public IEnumerable<Journey> AllJourneys()
        {
            try
            {
                var journeys = _tfrContext.Journey.ToList();
                return journeys;
            }
            catch (Exception e)
            {
                log.Fatal($"Cannont retrrieve AllJourneys from Database. Error: {e}");
                return new List<Journey>()
                {
                    new Journey(){Id = 404, Duration = 0, StartDateTime = DateTime.Now, ArrivalDateTime = DateTime.Now }
                };
            }

        }
    }
}