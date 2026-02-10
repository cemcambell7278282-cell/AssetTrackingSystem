namespace AssetTrackingSystem
{
    partial class ViewAssetsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvHardware = new DataGridView();
            dgvSoftware = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvHardware).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSoftware).BeginInit();
            SuspendLayout();
            // 
            // dgvHardware
            // 
            dgvHardware.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHardware.Location = new Point(216, 26);
            dgvHardware.Name = "dgvHardware";
            dgvHardware.RowHeadersWidth = 62;
            dgvHardware.RowTemplate.Height = 33;
            dgvHardware.Size = new Size(360, 225);
            dgvHardware.TabIndex = 0;
            // 
            // dgvSoftware
            // 
            dgvSoftware.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSoftware.Location = new Point(216, 340);
            dgvSoftware.Name = "dgvSoftware";
            dgvSoftware.RowHeadersWidth = 62;
            dgvSoftware.RowTemplate.Height = 33;
            dgvSoftware.Size = new Size(360, 225);
            dgvSoftware.TabIndex = 1;
            // 
            // ViewAssetsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 623);
            Controls.Add(dgvSoftware);
            Controls.Add(dgvHardware);
            Name = "ViewAssetsForm";
            Text = "ViewAssetsForm";
            ((System.ComponentModel.ISupportInitialize)dgvHardware).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSoftware).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvHardware;
        private DataGridView dgvSoftware;
    }
}