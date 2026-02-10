using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AssetTrackingSystem.Data;
using AssetTrackingSystem.Models;

namespace AssetTrackingSystem
{
    public partial class ViewAssetsForm : Form
    {
        public ViewAssetsForm()
        {
            InitializeComponent();
            Load += ViewAssetsForm_Load;
            dgvHardware.SelectionChanged += dgvHardware_SelectionChanged;
        }

        private void ViewAssetsForm_Load(object sender, EventArgs e)
        {
            dgvHardware.ReadOnly = true;
            dgvSoftware.ReadOnly = true;

            dgvHardware.AutoGenerateColumns = true;
            dgvSoftware.AutoGenerateColumns = true;

            dgvHardware.DataSource = DatabaseHelper.GetAllAssets();
        }

        private void dgvHardware_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHardware.SelectedRows.Count == 0)
                return;

            int assetId =
                Convert.ToInt32(dgvHardware.SelectedRows[0].Cells["AssetId"].Value);

            dgvSoftware.DataSource =
                DatabaseHelper.GetSoftwareByAssetId(assetId);
        }
    }
}

