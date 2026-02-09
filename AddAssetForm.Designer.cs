namespace AssetTrackingSystem
{
    partial class AddAssetForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox txtAssetId;
        private System.Windows.Forms.TextBox txtDeviceName;
        private System.Windows.Forms.TextBox txtManufacturer;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtDeviceType;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnAddAsset;

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
            this.txtAssetId = new System.Windows.Forms.TextBox();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.txtManufacturer = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtDeviceType = new System.Windows.Forms.TextBox();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnAddAsset = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // txtAssetId
            this.txtAssetId.Location = new System.Drawing.Point(30, 30);
            this.txtAssetId.Name = "txtAssetId";
            this.txtAssetId.PlaceholderText = "Asset ID";
            this.txtAssetId.Size = new System.Drawing.Size(200, 23);

            // txtDeviceName
            this.txtDeviceName.Location = new System.Drawing.Point(30, 70);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.PlaceholderText = "Device Name";
            this.txtDeviceName.Size = new System.Drawing.Size(200, 23);

            // txtManufacturer
            this.txtManufacturer.Location = new System.Drawing.Point(30, 110);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.PlaceholderText = "Manufacturer";
            this.txtManufacturer.Size = new System.Drawing.Size(200, 23);

            // txtModel
            this.txtModel.Location = new System.Drawing.Point(260, 30);
            this.txtModel.Name = "txtModel";
            this.txtModel.PlaceholderText = "Model";
            this.txtModel.Size = new System.Drawing.Size(200, 23);

            // txtDeviceType
            this.txtDeviceType.Location = new System.Drawing.Point(260, 70);
            this.txtDeviceType.Name = "txtDeviceType";
            this.txtDeviceType.PlaceholderText = "Device Type";
            this.txtDeviceType.Size = new System.Drawing.Size(200, 23);

            // txtIPAddress
            this.txtIPAddress.Location = new System.Drawing.Point(260, 110);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.PlaceholderText = "IP Address";
            this.txtIPAddress.Size = new System.Drawing.Size(200, 23);

            // txtNotes
            this.txtNotes.Location = new System.Drawing.Point(30, 150);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.PlaceholderText = "Notes";
            this.txtNotes.Size = new System.Drawing.Size(430, 60);

            // btnAddAsset
            this.btnAddAsset.Location = new System.Drawing.Point(30, 230);
            this.btnAddAsset.Name = "btnAddAsset";
            this.btnAddAsset.Size = new System.Drawing.Size(120, 30);
            this.btnAddAsset.Text = "Add Asset";
            this.btnAddAsset.UseVisualStyleBackColor = true;
            this.btnAddAsset.Click += new System.EventHandler(this.btnAddAsset_Click);

            // AddAssetForm
            this.ClientSize = new System.Drawing.Size(520, 300);
            this.Controls.Add(this.txtAssetId);
            this.Controls.Add(this.txtDeviceName);
            this.Controls.Add(this.txtManufacturer);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.txtDeviceType);
            this.Controls.Add(this.txtIPAddress);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.btnAddAsset);
            this.Name = "AddAssetForm";
            this.Text = "Add Asset";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
