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
            btnViewAssets = new Button();
            SuspendLayout();
            // 
            // btnAddAsset
            // 
            btnAddAsset.Location = new Point(40, 30);
            btnAddAsset.Name = "btnAddAsset";
            btnAddAsset.Size = new Size(200, 40);
            btnAddAsset.TabIndex = 0;
            btnAddAsset.Text = "Add Hardware Asset";
            btnAddAsset.Click += btnAddAsset_Click;
            // 
            // btnAddSoftware
            // 
            btnAddSoftware.Location = new Point(40, 90);
            btnAddSoftware.Name = "btnAddSoftware";
            btnAddSoftware.Size = new Size(200, 40);
            btnAddSoftware.TabIndex = 1;
            btnAddSoftware.Text = "Add Software Asset";
            btnAddSoftware.Click += btnAddSoftware_Click;
            // 
            // btnViewAssets
            // 
            btnViewAssets.Location = new Point(40, 154);
            btnViewAssets.Name = "btnViewAssets";
            btnViewAssets.Size = new Size(200, 34);
            btnViewAssets.TabIndex = 2;
            btnViewAssets.Text = "View Asset";
            btnViewAssets.UseVisualStyleBackColor = true;
            btnViewAssets.Click += btnViewAssets_Click;   // ✅ FIX
            // 
            // MainForm
            // 
            ClientSize = new Size(280, 215);
            Controls.Add(btnViewAssets);
            Controls.Add(btnAddAsset);
            Controls.Add(btnAddSoftware);
            Name = "MainForm";
            Text = "Asset Tracking System";
            ResumeLayout(false);
        }

        private Button btnViewAssets;
    }
}
