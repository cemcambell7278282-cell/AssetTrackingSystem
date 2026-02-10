namespace AssetTrackingSystem
{
    partial class AddSoftwareForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvSoftware;

        private TextBox txtOSName;
        private TextBox txtVersion;
        private TextBox txtManufacturer;
        private Button btnAddSoftware;

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
            txtOSName = new TextBox();
            txtVersion = new TextBox();
            txtManufacturer = new TextBox();
            btnAddSoftware = new Button();
            cmbHardwareAsset = new ComboBox();
            dgvSoftware = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvSoftware).BeginInit();
            SuspendLayout();
            // 
            // txtOSName
            // 
            txtOSName.Location = new Point(30, 30);
            txtOSName.Name = "txtOSName";
            txtOSName.PlaceholderText = "Operating System Name";
            txtOSName.Size = new Size(250, 31);
            txtOSName.TabIndex = 0;
            // 
            // txtVersion
            // 
            txtVersion.Location = new Point(30, 70);
            txtVersion.Name = "txtVersion";
            txtVersion.PlaceholderText = "Version";
            txtVersion.Size = new Size(250, 31);
            txtVersion.TabIndex = 1;
            // 
            // txtManufacturer
            // 
            txtManufacturer.Location = new Point(30, 110);
            txtManufacturer.Name = "txtManufacturer";
            txtManufacturer.PlaceholderText = "Manufacturer";
            txtManufacturer.Size = new Size(250, 31);
            txtManufacturer.TabIndex = 2;
            // 
            // btnAddSoftware
            // 
            btnAddSoftware.Location = new Point(30, 206);
            btnAddSoftware.Name = "btnAddSoftware";
            btnAddSoftware.Size = new Size(150, 30);
            btnAddSoftware.TabIndex = 3;
            btnAddSoftware.Text = "Add Software";
            btnAddSoftware.Click += btnAddSoftware_Click;
            // 
            // cmbHardwareAsset
            // 
            cmbHardwareAsset.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHardwareAsset.FormattingEnabled = true;
            cmbHardwareAsset.Location = new Point(30, 158);
            cmbHardwareAsset.Name = "cmbHardwareAsset";
            cmbHardwareAsset.Size = new Size(303, 33);
            cmbHardwareAsset.TabIndex = 5;
            // 
            // dgvSoftware
            // 
            dgvSoftware.AllowUserToAddRows = false;
            dgvSoftware.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSoftware.ColumnHeadersHeight = 34;
            dgvSoftware.Location = new Point(30, 283);
            dgvSoftware.Name = "dgvSoftware";
            dgvSoftware.ReadOnly = true;
            dgvSoftware.RowHeadersWidth = 62;
            dgvSoftware.Size = new Size(670, 120);
            dgvSoftware.TabIndex = 6;
            // 
            // AddSoftwareForm
            // 
            ClientSize = new Size(736, 450);
            Controls.Add(cmbHardwareAsset);
            Controls.Add(txtOSName);
            Controls.Add(txtVersion);
            Controls.Add(txtManufacturer);
            Controls.Add(btnAddSoftware);
            Controls.Add(dgvSoftware);
            Name = "AddSoftwareForm";
            Text = "Add Software Asset";
            ((System.ComponentModel.ISupportInitialize)dgvSoftware).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox cmbHardwareAsset;
    }
}
