using System;
using System.Windows.Forms;
using SQLitePCL;
using AssetTrackingSystem.Data;

namespace AssetTrackingSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Batteries.Init(); // SQLite native DLL

            // ✅ Create Assets table if missing
            DatabaseHelper.InitializeDatabase();

            ApplicationConfiguration.Initialize();
            Application.Run(new AddAssetForm());
        }
    }
}
