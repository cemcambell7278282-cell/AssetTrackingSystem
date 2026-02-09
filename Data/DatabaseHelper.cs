using System.Data.SQLite;
using AssetTrackingSystem.Models;

namespace AssetTrackingSystem.Data
{
    public static class DatabaseHelper
    {
        private static string connectionString = "Data Source=assets.db;Version=3;";

        // ✅ Call this once at app startup
        public static void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Assets (
                    AssetId INTEGER PRIMARY KEY,
                    DeviceName TEXT,
                    Model TEXT,
                    DeviceType TEXT,
                    Manufacturer TEXT,
                    IpAddress TEXT,
                    Notes TEXT
                );";

                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void InsertAsset(Asset asset)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
                INSERT INTO Assets 
                (AssetId, DeviceName, Model, DeviceType, Manufacturer, IpAddress, Notes)
                VALUES 
                (@AssetId, @DeviceName, @Model, @DeviceType, @Manufacturer, @IpAddress, @Notes);";

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
