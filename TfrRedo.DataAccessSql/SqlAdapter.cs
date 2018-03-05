using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Domain.Stations;
using System.Configuration;
using System.Linq;
using Domain.Legs;
using TFR.Data.Models.Journey;

namespace TfrRedo.DataAccessSql
{
    public class SqlAdapter:ISqlAdapter
    {
        private readonly string _connectionString  = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
        DataTable _dataTable = new DataTable();
        public void Save(Journey journey)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                string query = "EXEC  [dbo].[SaveStations] @StartDatetime, @Duration, @ArrivalDatetime";
                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@StartDateTime", journey.StartDateTime);
                sqlCommand.Parameters.AddWithValue("@Duration", journey.Duration);
                sqlCommand.Parameters.AddWithValue("@ArrivalDatetime", journey.ArrivalDateTime);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void Delete(Journey journey)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Station WHERE StationId = @StationId";
                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@StationId", journey.Id);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public IEnumerable<Journey> AllJourneys()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                var sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Journeys ORDER BY id", sqlConnection);
                sqlDataAdapter.Fill(_dataTable);
            }

            List<Journey> journeys = _dataTable.AsEnumerable()
                .Select(row => new Journey()
                {
                    Id = row.Field<int?>(0).GetValueOrDefault(),
                    StartDateTime = row.Field<DateTime?>(1).GetValueOrDefault(),
                    Duration = row.Field<int?>(2).GetValueOrDefault(),
                    Legs = new List<Leg>(),
                    LegsCycle = new List<Leg>(),
                    LegsTrain = new List<Leg>()
                }).ToList();

            return journeys;
        }
    }
}
