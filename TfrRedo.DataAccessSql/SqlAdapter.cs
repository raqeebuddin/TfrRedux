using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Domain.Stations;

namespace TfrRedo.DataAccessSql
{
    public class SqlAdapter
    {
        private string _connectionString =
            @"Data Source = PC-00602\MSSQLSERVER1; Initial Catalog = TfrDatabase; Integrated Security=True"; 
        
        DataTable _dataTable = new DataTable();

        public void GetAll()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                var sqlDataAdapter = new SqlDataAdapter("SELECT Name FROM Station ORDER BY Name", sqlConnection);

                sqlDataAdapter.Fill(_dataTable);
            }
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

        public void Delete()
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
    }
}
