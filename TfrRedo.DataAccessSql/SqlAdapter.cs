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

        public DataTable GetAll()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                var sqlDataAdapter = new SqlDataAdapter("SELECT Name FROM Station ORDER BY Name", sqlConnection);
                sqlDataAdapter.Fill(_dataTable);
            }

            return _dataTable;
        }

        public void Insert()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                string modelName = "Barking";
                sqlConnection.Open();
                string query = "INSERT INTO Station(Name) VALUES(@Name)";
                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Name", modelName);
                sqlCommand.ExecuteNonQuery();
            }

        }

        public void GetById()
        {
            var stationDto = new Station(); //temp used for DTO for application itself
            var dataTable = new DataTable();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
              
                int stationId = 2;

                string query = "SELECT FROM  Station WHERE StationId = @StationId";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@StationId", stationId);
                sqlDataAdapter.Fill(dataTable);
            }

            // copy data over from the data table to the DTO to be used by the pplication

            if (dataTable.Rows.Count == 1)
            {
                stationDto.Id = Convert.ToString(dataTable.Rows[0][0].ToString());
                stationDto.Name = dataTable.Rows[0][1].ToString();
            }
            else
            {
                stationDto.Name = "no Stations available";
            }

            //YOU CAN RETURN THE STATIONdTO
        }

        public void Save(Journey journey)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                string query = "EXEC  [dbo].[SaveStations] @StartDatetime, @Duration, @ArrivalDatetime";
                var sqlCommand = new SqlCommand(query, sqlConnection);
    /*            sqlCommand.Parameters.AddWithValue("@Id", journey.Id)*/;
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

                int stationId = 2;
                string stationName = "Raq";

                string query = "DELETE FROM Station WHERE StationId = @StationId";
                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@StationId", stationId);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public IEnumerable<Journey> AllJourneys()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                var sqlDataAdapter = new SqlDataAdapter("SELECT Name FROM Station ORDER BY Name", sqlConnection);
                sqlDataAdapter.Fill(_dataTable);
            }

            List<Journey> target = _dataTable.AsEnumerable()
                .Select(row => new Journey()
                {
                    Id = row.Field<int?>(0).GetValueOrDefault(),
                    StartDateTime = row.Field<DateTime?>(1).GetValueOrDefault(),
                    Duration = row.Field<int?>(2).GetValueOrDefault(),
                    Legs = new List<Leg>(),
                    LegsCycle = new List<Leg>(),
                    LegsTrain = new List<Leg>()
                }).ToList();

            return target;
        }

        public void Update()
        { 
            using (var sqlConnection = new SqlConnection(_connectionString))
            {

                int stationId = 2;
                string stationName = "Raq";

                string query = "UPDATE Station SET  StationId = @StationId, Name = @StationName";
                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@StationId", stationId);
                sqlCommand.Parameters.AddWithValue("@Name", stationName);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
