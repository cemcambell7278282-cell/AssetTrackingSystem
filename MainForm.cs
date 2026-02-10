using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetTrackingSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAddAsset_Click(object sender, EventArgs e)
        {
            new AddAssetForm().ShowDialog();
        }

        private void btnAddSoftware_Click(object sender, EventArgs e)
        {
            new AddSoftwareForm().ShowDialog();
        }
    }
}
