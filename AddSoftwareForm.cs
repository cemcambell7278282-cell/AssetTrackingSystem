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

        private void btnAddSoftware_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtOSName.Text) ||
                    string.IsNullOrWhiteSpace(txtVersion.Text) ||
                    string.IsNullOrWhiteSpace(txtManufacturer.Text))
                {
                    MessageBox.Show("All fields are required.");
                    return;
                }

                if (cmbHardwareAsset.SelectedValue == null)
                {
                    MessageBox.Show("Please select a hardware asset.");
                    return;
                }

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            txtOSName.Clear();
            txtVersion.Clear();
            txtManufacturer.Clear();
            cmbHardwareAsset.SelectedIndex = 0;
        }

        private void cmbHardwareAsset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHardwareAsset.SelectedItem == null)
                return;

            Asset selectedAsset = cmbHardwareAsset.SelectedItem as Asset;
            if (selectedAsset == null)
                return;

            int assetId = selectedAsset.AssetId;

            var softwareList = DatabaseHelper.GetSoftwareByAssetId(assetId);
            dgvSoftware.DataSource = softwareList;
        }

    }
}
