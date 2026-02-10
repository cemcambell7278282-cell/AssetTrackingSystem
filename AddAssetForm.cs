using System;
using System.Windows.Forms;
using AssetTrackingSystem.Models;
using AssetTrackingSystem.Data;

namespace AssetTrackingSystem
{
    public partial class AddAssetForm : Form
    {
        public AddAssetForm()
        {
            InitializeComponent();
        }

        private void btnAddAsset_Click(object sender, EventArgs e)
        {
            try
            {
                // ✅ AssetId is NOT set manually anymore
                Asset asset = new Asset
                {
                    DeviceName = txtDeviceName.Text.Trim(),
                    Manufacturer = txtManufacturer.Text.Trim(),
                    Model = txtModel.Text.Trim(),
                    DeviceType = txtDeviceType.Text.Trim(),
                    IPAddress = txtIPAddress.Text.Trim(),
                    Notes = txtNotes.Text.Trim()
                };

                DatabaseHelper.InsertAsset(asset);

                MessageBox.Show("Asset added successfully!");

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            txtDeviceName.Clear();
            txtManufacturer.Clear();
            txtModel.Clear();
            txtDeviceType.Clear();
            txtIPAddress.Clear();
            txtNotes.Clear();
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
