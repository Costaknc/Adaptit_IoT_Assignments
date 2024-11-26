using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DatabaseTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string ip_to_find = "127.0.0.1";
            //string city = "Athens";
            //string country = "Greece";
            //string continent = "Europe";
            //double lat = 16.876;
            //double lon = 14.223;

            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "KPET-LAPTOP\\SQLEXPRESS",
                IntegratedSecurity = true,
                InitialCatalog = "IpDetails",
                TrustServerCertificate = true
            };

            var connectionString = builder.ConnectionString;

            try
            {
                await using var conn = new SqlConnection(connectionString);
                await conn.OpenAsync();

                //var query = "INSERT INTO IpDetails (IP, City, Country, Continent, Lat, Lon) VALUES (@IP, @City, @Country, @Continent, @Lat, @Lon);";
                //using (var command = new SqlCommand(query, conn))
                //{
                //    command.Parameters.AddWithValue("@IP", ip);
                //    command.Parameters.AddWithValue("@City", city);
                //    command.Parameters.AddWithValue("@Country", country);
                //    command.Parameters.AddWithValue("@Continent", continent);
                //    command.Parameters.AddWithValue("@Lat", lat);
                //    command.Parameters.AddWithValue("@Lon", lon);

                //    command.ExecuteNonQuery();
                //}

                //string query = "SELECT IP, City, Country, Continent, Lat, Lon FROM IpDetails WHERE IP = @IP";
                //using (var command = new SqlCommand(query, conn))
                //{
                //    command.Parameters.AddWithValue("@IP", ip_to_find);

                //    using (var reader = command.ExecuteReader())
                //    {
                //        if (reader.Read())
                //        {
                //            string ip = reader.GetString(reader.GetOrdinal("IP"));
                //            string city = reader.GetString(reader.GetOrdinal("City"));
                //            string country = reader.GetString(reader.GetOrdinal("Country"));
                //            string continent = reader.GetString(reader.GetOrdinal("Continent"));
                //            double lat = reader.GetDouble(reader.GetOrdinal("Lat"));
                //            double lon = reader.GetDouble(reader.GetOrdinal("Lon"));

                //            Console.WriteLine($"IP: {ip}, City: {city}, Country: {country}, Continent: {continent}, Latitude: {lat}, Longitude: {lon}");
                //        }
                //        else
                //        {
                //            Console.WriteLine("No record found with the specified IP.");
                //        }
                //    }
                //}
            }
            catch (SqlException e) /*when (e.Number ==  specific_error_number )*/
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
        }
    }
}