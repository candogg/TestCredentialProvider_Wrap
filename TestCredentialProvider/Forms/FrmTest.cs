using System;
using System.Windows.Forms;

namespace TestCredentialProvider.Forms
{
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        private void BtnPass_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;

            Close();
        }
    }
}
