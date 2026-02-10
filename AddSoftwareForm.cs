using System;
using System.Windows.Forms;
using AssetTrackingSystem.Models;
using AssetTrackingSystem.Data;
using AssetTrackingSystem.Security;

namespace AssetTrackingSystem
{
    public partial class AddSoftwareForm : Form
    {
        private bool IsAdmin =>
    Session.CurrentUser.Role
        .Trim()
        .Equals("Admin", StringComparison.OrdinalIgnoreCase);

        public AddSoftwareForm()
        {
            InitializeComponent();

            if (Session.CurrentUser == null)
            {
                MessageBox.Show("Unauthorized access.");
                Close();
                return;
            }

            ApplyRolePermissions();

            cmbHardwareAsset.SelectedIndexChanged += cmbHardwareAsset_SelectedIndexChanged;
            dgvSoftware.CellClick += dgvSoftware_CellClick;
            Load += AddSoftwareForm_Load;
        }

        // ================= FORM LOAD =================

        private void AddSoftwareForm_Load(object sender, EventArgs e)
        {
            var assets = DatabaseHelper.GetAllAssets();

            if (assets.Count == 0)
            {
                MessageBox.Show("Please add a hardware asset first.");
                Close();
                return;
            }

            cmbHardwareAsset.DataSource = assets;
            cmbHardwareAsset.DisplayMember = "DeviceName";
            cmbHardwareAsset.ValueMember = "AssetId";
        }

        // ================= ADD SOFTWARE =================

        private void btnAddSoftware_Click(object sender, EventArgs e)
        {
            if (!IsAdmin)
            {
                MessageBox.Show("You do not have permission to add software.");
                return;
            }

            if (!ValidateInputs())
                return;

            SoftwareAsset software = new SoftwareAsset
            {
                OperatingSystem = txtOSName.Text.Trim(),
                Version = txtVersion.Text.Trim(),
                Manufacturer = txtManufacturer.Text.Trim(),
                AssetId = (int)cmbHardwareAsset.SelectedValue,
                LinkedDate = DateTime.Now
            };

            DatabaseHelper.InsertSoftwareAsset(software);

            MessageBox.Show("Software asset added successfully!");

            ClearForm();
            ReloadSoftwareGrid();
        }

        // ================= LOAD SOFTWARE PER HARDWARE =================

        private void cmbHardwareAsset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHardwareAsset.SelectedItem is not Asset asset)
                return;

            dgvSoftware.DataSource =
                DatabaseHelper.GetSoftwareByAssetId(asset.AssetId);
        }

        // ================= LOAD SELECTED SOFTWARE =================

        private void dgvSoftware_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            txtOSName.Text =
                dgvSoftware.Rows[e.RowIndex].Cells["OperatingSystem"].Value.ToString();

            txtVersion.Text =
                dgvSoftware.Rows[e.RowIndex].Cells["Version"].Value.ToString();

            txtManufacturer.Text =
                dgvSoftware.Rows[e.RowIndex].Cells["Manufacturer"].Value.ToString();

            cmbHardwareAsset.SelectedValue =
                Convert.ToInt32(dgvSoftware.Rows[e.RowIndex].Cells["AssetId"].Value);
        }

        // ================= EDIT SOFTWARE =================

        private void btnEditSoftware_Click(object sender, EventArgs e)
        {
            if (!IsAdmin)
            {
                MessageBox.Show("You do not have permission to edit software.");
                return;
            }

            if (dgvSoftware.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a software record to edit.");
                return;
            }

            if (!ValidateInputs())
                return;

            int softwareId =
                Convert.ToInt32(dgvSoftware.SelectedRows[0]
                .Cells["SoftwareAssetId"].Value);

            SoftwareAsset software = new SoftwareAsset
            {
                SoftwareAssetId = softwareId,
                OperatingSystem = txtOSName.Text.Trim(),
                Version = txtVersion.Text.Trim(),
                Manufacturer = txtManufacturer.Text.Trim(),
                AssetId = (int)cmbHardwareAsset.SelectedValue
            };

            DatabaseHelper.UpdateSoftwareAsset(software);

            MessageBox.Show("Software asset updated successfully.");

            ReloadSoftwareGrid();
        }

        // ================= DELETE SOFTWARE =================

        private void btnDeleteSoftware_Click(object sender, EventArgs e)
        {
            if (!IsAdmin)
            {
                MessageBox.Show("You do not have permission to delete software.");
                return;
            }

            if (dgvSoftware.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a software record to delete.");
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to delete this software?",
                "Confirm Delete",
                MessageBoxButtons.YesNo);

            if (confirm != DialogResult.Yes)
                return;

            int softwareId =
                Convert.ToInt32(dgvSoftware.SelectedRows[0]
                .Cells["SoftwareAssetId"].Value);

            DatabaseHelper.DeleteSoftwareAsset(softwareId);

            MessageBox.Show("Software asset deleted.");

            ReloadSoftwareGrid();
            ClearForm();
        }

        // ================= HELPERS =================

        private void ReloadSoftwareGrid()
        {
            if (cmbHardwareAsset.SelectedValue == null)
                return;

            int assetId = (int)cmbHardwareAsset.SelectedValue;
            dgvSoftware.DataSource =
                DatabaseHelper.GetSoftwareByAssetId(assetId);
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtOSName.Text) ||
                string.IsNullOrWhiteSpace(txtVersion.Text) ||
                string.IsNullOrWhiteSpace(txtManufacturer.Text))
            {
                MessageBox.Show("All fields are required.");
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtOSName.Clear();
            txtVersion.Clear();
            txtManufacturer.Clear();
        }

        private void ApplyRolePermissions()
        {
            if (!IsAdmin)
            {
                btnAddSoftware.Enabled = false;
                btnEditSoftware.Enabled = false;
                btnDeleteSoftware.Enabled = false;

                txtOSName.ReadOnly = true;
                txtVersion.ReadOnly = true;
                txtManufacturer.ReadOnly = true;
                cmbHardwareAsset.Enabled = false;
            }
            else
            {
                // Explicitly ENABLE for Admin
                btnAddSoftware.Enabled = true;
                btnEditSoftware.Enabled = true;
                btnDeleteSoftware.Enabled = true;

                txtOSName.ReadOnly = false;
                txtVersion.ReadOnly = false;
                txtManufacturer.ReadOnly = false;
                cmbHardwareAsset.Enabled = true;
            }
        }
    }
}
