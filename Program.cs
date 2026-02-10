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

            // ✅ Initialize ALL database tables here
            DatabaseHelper.InitializeDatabase();

            Application.Run(new MainForm());
        }
    }
}
