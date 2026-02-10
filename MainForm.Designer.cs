namespace AssetTrackingSystem
{
    partial class MainForm
    {
        private Button btnAddAsset;
        private Button btnAddSoftware;

        private void InitializeComponent()
        {
            btnAddAsset = new Button();
            btnAddSoftware = new Button();
            SuspendLayout();

            // btnAddAsset
            btnAddAsset.Location = new Point(40, 30);
            btnAddAsset.Size = new Size(200, 40);
            btnAddAsset.Text = "Add Hardware Asset";
            btnAddAsset.Click += btnAddAsset_Click;

            // btnAddSoftware
            btnAddSoftware.Location = new Point(40, 90);
            btnAddSoftware.Size = new Size(200, 40);
            btnAddSoftware.Text = "Add Software Asset";
            btnAddSoftware.Click += btnAddSoftware_Click;

            // MainForm
            ClientSize = new Size(280, 170);
            Controls.Add(btnAddAsset);
            Controls.Add(btnAddSoftware);
            Text = "Asset Tracking System";

            ResumeLayout(false);
        }
    }
}
