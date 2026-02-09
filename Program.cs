using System;
using System.Windows.Forms;
using AssetTrackingSystem.Data;

namespace AssetTrackingSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // 🔹 Ensure DB + tables exist
            DatabaseHelper.InitializeDatabase();

            Application.Run(new AddAssetForm());
        }
    }
}
