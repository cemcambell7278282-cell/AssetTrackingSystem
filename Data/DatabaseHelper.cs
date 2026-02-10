using System;
using System.Collections.Generic;
using System.Data.SQLite;
using AssetTrackingSystem.Models;

namespace AssetTrackingSystem.Data
{
    public static class DatabaseHelper
    {
        private static string connectionString = "Data Source=assets.db;Version=3;";

        // ===================== INITIALIZATION =====================
        public static void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Enable foreign keys
                using (var pragma = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection))
                {
                    pragma.ExecuteNonQuery();
                }

                string createAssetsTable = @"
                CREATE TABLE IF NOT EXISTS Assets (
                    AssetId INTEGER PRIMARY KEY AUTOINCREMENT,
                    DeviceName TEXT NOT NULL,
                    Model TEXT NOT NULL,
                    DeviceType TEXT NOT NULL,
                    Manufacturer TEXT NOT NULL,
                    IpAddress TEXT,
                    Notes TEXT
                );";

                string createSoftwareAssetsTable = @"
                CREATE TABLE IF NOT EXISTS SoftwareAssets (
                    SoftwareAssetId INTEGER PRIMARY KEY AUTOINCREMENT,
                    OperatingSystem TEXT NOT NULL,
                    Version TEXT NOT NULL,
                    Manufacturer TEXT NOT NULL,
                    AssetId INTEGER NOT NULL,
                    LinkedDate TEXT NOT NULL,
                    FOREIGN KEY (AssetId) REFERENCES Assets(AssetId)
                );";

                using (var cmd = new SQLiteCommand(connection))
                {
                    cmd.CommandText = createAssetsTable;
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = createSoftwareAssetsTable;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ===================== HARDWARE =====================
        public static void InsertAsset(Asset asset)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
                INSERT INTO Assets 
                (DeviceName, Model, DeviceType, Manufacturer, IpAddress, Notes)
                VALUES 
                (@DeviceName, @Model, @DeviceType, @Manufacturer, @IpAddress, @Notes);";

                using (var command = new SQLiteCommand(query, connection))
                {
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

        public static List<Asset> GetAllAssets()
        {
            var assets = new List<Asset>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT AssetId, DeviceName FROM Assets";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        assets.Add(new Asset
                        {
                            AssetId = reader.GetInt32(0),
                            DeviceName = reader.GetString(1)
                        });
                    }
                }
            }

            return assets;
        }

        // ===================== SOFTWARE =====================
        public static void InsertSoftwareAsset(SoftwareAsset software)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
                INSERT INTO SoftwareAssets
                (OperatingSystem, Version, Manufacturer, AssetId, LinkedDate)
                VALUES
                (@OperatingSystem, @Version, @Manufacturer, @AssetId, @LinkedDate);";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OperatingSystem", software.OperatingSystem);
                    command.Parameters.AddWithValue("@Version", software.Version);
                    command.Parameters.AddWithValue("@Manufacturer", software.Manufacturer);
                    command.Parameters.AddWithValue("@AssetId", software.AssetId);
                    command.Parameters.AddWithValue("@LinkedDate",
                        software.LinkedDate.ToString("yyyy-MM-dd"));

                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<SoftwareAsset> GetSoftwareByAssetId(int assetId)
        {
            var softwareList = new List<SoftwareAsset>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
                SELECT SoftwareAssetId, OperatingSystem, Version, Manufacturer, AssetId, LinkedDate
                FROM SoftwareAssets
                WHERE AssetId = @AssetId;";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AssetId", assetId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime linkedDate;
                            DateTime.TryParse(reader["LinkedDate"].ToString(), out linkedDate);

                            softwareList.Add(new SoftwareAsset
                            {
                                SoftwareAssetId = Convert.ToInt32(reader["SoftwareAssetId"]),
                                OperatingSystem = reader["OperatingSystem"].ToString(),
                                Version = reader["Version"].ToString(),
                                Manufacturer = reader["Manufacturer"].ToString(),
                                AssetId = Convert.ToInt32(reader["AssetId"]),
                                LinkedDate = linkedDate
                            });
                        }
                    }
                }
            }

            return softwareList;
        }

        public static void UpdateSoftwareAsset(SoftwareAsset software)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
                UPDATE SoftwareAssets
                SET OperatingSystem = @OperatingSystem,
                    Version = @Version,
                    Manufacturer = @Manufacturer,
                    AssetId = @AssetId
                WHERE SoftwareAssetId = @SoftwareAssetId;";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OperatingSystem", software.OperatingSystem);
                    command.Parameters.AddWithValue("@Version", software.Version);
                    command.Parameters.AddWithValue("@Manufacturer", software.Manufacturer);
                    command.Parameters.AddWithValue("@AssetId", software.AssetId);
                    command.Parameters.AddWithValue("@SoftwareAssetId", software.SoftwareAssetId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteSoftwareAsset(int softwareAssetId)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM SoftwareAssets WHERE SoftwareAssetId = @id";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", softwareAssetId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
