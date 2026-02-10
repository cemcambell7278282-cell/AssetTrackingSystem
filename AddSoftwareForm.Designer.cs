namespace AssetTrackingSystem
{
    partial class AddSoftwareForm
    {
        private System.ComponentModel.IContainer components = null;

        private TextBox txtOSName;
        private TextBox txtVersion;
        private TextBox txtManufacturer;
        private ComboBox cmbHardwareAsset;

        private Button btnAddSoftware;
        private Button btnEditSoftware;
        private Button btnDeleteSoftware;

        private DataGridView dgvSoftware;

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
            cmbHardwareAsset = new ComboBox();

            btnAddSoftware = new Button();
            btnEditSoftware = new Button();
            btnDeleteSoftware = new Button();

            dgvSoftware = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)dgvSoftware).BeginInit();
            SuspendLayout();

            // txtOSName
            txtOSName.Location = new Point(30, 30);
            txtOSName.PlaceholderText = "Operating System Name";
            txtOSName.Size = new Size(250, 31);

            // txtVersion
            txtVersion.Location = new Point(30, 70);
            txtVersion.PlaceholderText = "Version";
            txtVersion.Size = new Size(250, 31);

            // txtManufacturer
            txtManufacturer.Location = new Point(30, 110);
            txtManufacturer.PlaceholderText = "Manufacturer";
            txtManufacturer.Size = new Size(250, 31);

            // cmbHardwareAsset
            cmbHardwareAsset.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHardwareAsset.Location = new Point(30, 158);
            cmbHardwareAsset.Size = new Size(303, 33);

            // btnAddSoftware
            btnAddSoftware.Location = new Point(30, 206);
            btnAddSoftware.Size = new Size(150, 30);
            btnAddSoftware.Text = "Add Software";
            btnAddSoftware.Click += btnAddSoftware_Click;

            // btnEditSoftware
            btnEditSoftware.Location = new Point(30, 250);
            btnEditSoftware.Size = new Size(120, 30);
            btnEditSoftware.Text = "Edit Software";
            btnEditSoftware.Click += btnEditSoftware_Click;

            // btnDeleteSoftware
            btnDeleteSoftware.Location = new Point(170, 250);
            btnDeleteSoftware.Size = new Size(120, 30);
            btnDeleteSoftware.Text = "Delete Software";
            btnDeleteSoftware.Click += btnDeleteSoftware_Click;

            // dgvSoftware
            dgvSoftware.AllowUserToAddRows = false;
            dgvSoftware.ReadOnly = true;
            dgvSoftware.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSoftware.ColumnHeadersHeight = 34;
            dgvSoftware.Location = new Point(30, 300);
            dgvSoftware.Size = new Size(670, 120);
            dgvSoftware.CellClick += dgvSoftware_CellClick;

            // AddSoftwareForm
            ClientSize = new Size(736, 450);
            Controls.Add(txtOSName);
            Controls.Add(txtVersion);
            Controls.Add(txtManufacturer);
            Controls.Add(cmbHardwareAsset);
            Controls.Add(btnAddSoftware);
            Controls.Add(btnEditSoftware);
            Controls.Add(btnDeleteSoftware);
            Controls.Add(dgvSoftware);

            Text = "Add Software Asset";
            Name = "AddSoftwareForm";

            ((System.ComponentModel.ISupportInitialize)dgvSoftware).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
