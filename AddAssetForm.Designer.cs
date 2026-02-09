namespace AssetTrackingSystem
{
    partial class AddAssetForm
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox txtDeviceName;
        private TextBox txtManufacturer;
        private TextBox txtModel;
        private TextBox txtDeviceType;
        private TextBox txtIPAddress;
        private TextBox txtNotes;
        private Button btnAddAsset;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtDeviceName = new TextBox();
            txtManufacturer = new TextBox();
            txtModel = new TextBox();
            txtDeviceType = new TextBox();
            txtIPAddress = new TextBox();
            txtNotes = new TextBox();
            btnAddAsset = new Button();
            SuspendLayout();

            // txtDeviceName
            txtDeviceName.Location = new Point(30, 30);
            txtDeviceName.Name = "txtDeviceName";
            txtDeviceName.PlaceholderText = "Device Name";
            txtDeviceName.Size = new Size(200, 23);

            // txtManufacturer
            txtManufacturer.Location = new Point(30, 70);
            txtManufacturer.Name = "txtManufacturer";
            txtManufacturer.PlaceholderText = "Manufacturer";
            txtManufacturer.Size = new Size(200, 23);

            // txtModel
            txtModel.Location = new Point(260, 30);
            txtModel.Name = "txtModel";
            txtModel.PlaceholderText = "Model";
            txtModel.Size = new Size(200, 23);

            // txtDeviceType
            txtDeviceType.Location = new Point(260, 70);
            txtDeviceType.Name = "txtDeviceType";
            txtDeviceType.PlaceholderText = "Device Type";
            txtDeviceType.Size = new Size(200, 23);

            // txtIPAddress
            txtIPAddress.Location = new Point(260, 110);
            txtIPAddress.Name = "txtIPAddress";
            txtIPAddress.PlaceholderText = "IP Address";
            txtIPAddress.Size = new Size(200, 23);

            // txtNotes
            txtNotes.Location = new Point(30, 110);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.PlaceholderText = "Notes";
            txtNotes.Size = new Size(430, 60);

            // btnAddAsset
            btnAddAsset.Location = new Point(30, 190);
            btnAddAsset.Name = "btnAddAsset";
            btnAddAsset.Size = new Size(120, 30);
            btnAddAsset.Text = "Add Asset";
            btnAddAsset.UseVisualStyleBackColor = true;
            btnAddAsset.Click += btnAddAsset_Click;

            // AddAssetForm
            ClientSize = new Size(520, 250);
            Controls.Add(txtDeviceName);
            Controls.Add(txtManufacturer);
            Controls.Add(txtModel);
            Controls.Add(txtDeviceType);
            Controls.Add(txtIPAddress);
            Controls.Add(txtNotes);
            Controls.Add(btnAddAsset);
            Name = "AddAssetForm";
            Text = "Add Asset";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
