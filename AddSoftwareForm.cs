using System;
using System.Windows.Forms;
using AssetTrackingSystem.Models;
using AssetTrackingSystem.Data;

namespace AssetTrackingSystem
{
    public partial class AddSoftwareForm : Form
    {
        public AddSoftwareForm()
        {
            InitializeComponent();
            cmbHardwareAsset.SelectedIndexChanged += cmbHardwareAsset_SelectedIndexChanged;
            dgvSoftware.CellClick += dgvSoftware_CellClick;
            this.Load += AddSoftwareForm_Load;
        }

        private void AddSoftwareForm_Load(object sender, EventArgs e)
        {
            var assets = DatabaseHelper.GetAllAssets();

            if (assets.Count == 0)
            {
                MessageBox.Show("Please add a hardware asset first.");
                this.Close();
                return;
            }

            cmbHardwareAsset.DataSource = assets;
            cmbHardwareAsset.DisplayMember = "DeviceName";
            cmbHardwareAsset.ValueMember = "AssetId";
        }

        // ================= ADD SOFTWARE =================

        private void btnAddSoftware_Click(object sender, EventArgs e)
        {
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
            if (cmbHardwareAsset.SelectedItem is not Asset selectedAsset)
                return;

            dgvSoftware.DataSource =
                DatabaseHelper.GetSoftwareByAssetId(selectedAsset.AssetId);
        }

        // ================= LOAD SELECTED SOFTWARE INTO TEXTBOXES =================

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
            if (dgvSoftware.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a software record to edit.");
                return;
            }

            if (!ValidateInputs())
                return;

            int softwareId =
                Convert.ToInt32(dgvSoftware.SelectedRows[0].Cells["SoftwareAssetId"].Value);

            SoftwareAsset software = new SoftwareAsset
            {
                SoftwareAssetId = softwareId,
                OperatingSystem = txtOSName.Text.Trim(),
                Version = txtVersion.Text.Trim(),
                Manufacturer = txtManufacturer.Text.Trim(),
                AssetId = (int)cmbHardwareAsset.SelectedValue,
                LinkedDate = DateTime.Now // maintain audit trail
            };

            DatabaseHelper.UpdateSoftwareAsset(software);

            MessageBox.Show("Software asset updated successfully.");

            ReloadSoftwareGrid();
        }

        // ================= DELETE SOFTWARE =================

        private void btnDeleteSoftware_Click(object sender, EventArgs e)
        {
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
                Convert.ToInt32(dgvSoftware.SelectedRows[0].Cells["SoftwareAssetId"].Value);

            DatabaseHelper.DeleteSoftwareAsset(softwareId);

            MessageBox.Show("Software asset deleted.");

            ReloadSoftwareGrid();
            ClearForm();
        }

        // ================= HELPERS =================

        private void ReloadSoftwareGrid()
        {
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

            if (cmbHardwareAsset.SelectedValue == null)
            {
                MessageBox.Show("Please select a hardware asset.");
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtOSName.Clear();
            txtVersion.Clear();
            txtManufacturer.Clear();
            cmbHardwareAsset.SelectedIndex = 0;
        }
    }
}
