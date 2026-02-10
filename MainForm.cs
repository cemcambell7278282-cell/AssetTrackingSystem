using AssetTrackingSystem.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetTrackingSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ApplyRolePermissions();
        }

        private void ApplyRolePermissions()
        {
            if (Session.CurrentUser == null)
            {
                MessageBox.Show("Unauthorized access.");
                Application.Exit();
                return;
            }

            // USER role = read-only
            if (Session.CurrentUser.Role == "User")
            {
                btnAddAsset.Enabled = false;     // Hardware
                btnAddSoftware.Enabled = false;  // Software
                btnViewAssets.Enabled = true; // Users can view
            }

            // ADMIN role = full access
            if (Session.CurrentUser.Role == "Admin")
            {
                btnAddAsset.Enabled = true;
                btnAddSoftware.Enabled = true;
            }
        }

        private void btnAddAsset_Click(object sender, EventArgs e)
        {
            new AddAssetForm().ShowDialog();
        }

        private void btnAddSoftware_Click(object sender, EventArgs e)
        {
            new AddSoftwareForm().ShowDialog();
        }

        private void btnViewAssets_Click(object sender, EventArgs e)
        {
            new ViewAssetsForm().ShowDialog();
        }

    }
}
