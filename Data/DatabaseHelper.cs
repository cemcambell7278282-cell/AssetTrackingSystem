using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using AssetTrackingSystem.Models;

namespace AssetTrackingSystem.Data
{
    public static class DatabaseHelper
    {
        private static string connectionString = "Data Source=assets.db;Version=3;";

        public static void InsertAsset(Asset asset)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"INSERT INTO Assets 
                                (AssetId, DeviceName, Model, DeviceType, Manufacturer, IpAddress, Notes)
                                VALUES 
                                (@AssetId, @DeviceName, @Model, @DeviceType, @Manufacturer, @IpAddress, @Notes)";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AssetId", asset.AssetId);
                    command.Parameters.AddWithValue("@DeviceName", asset.DeviceName);
                    command.Parameters.AddWithValue("@Model", asset.Model);
                    command.Parameters.AddWithValue("@DeviceType", asset.DeviceType);
                    command.Parameters.AddWithValue("@Manufacturer", asset.Manufacturer);
                    command.Parameters.AddWithValue("@IpAddress", asset.IPAddress);
                    command.Parameters.AddWithValue("@Notes", asset.Notes);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

