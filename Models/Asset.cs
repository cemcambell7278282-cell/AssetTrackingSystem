using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingSystem.Models
{
    public class Asset
    {
        public int AssetId { get; set; }
        public string DeviceName { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string DeviceType { get; set; }
        public string IPAddress { get; set; }
        public string Notes { get; set; }

        public int EmployeeId { get; set; }
    }
}

