using System;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class PenSettings : Form
    {
        public PenSettings()
        {
            InitializeComponent();
            PenTypeComboBox.Items.Add("Solid");
            PenTypeComboBox.Items.Add("Line");

            CBPenWidth.Items.Add("2");
            CBPenWidth.Items.Add("4");
            CBPenWidth.Items.Add("6");
            CBPenWidth.Items.Add("8");
            CBPenWidth.Items.Add("10");
            CBPenWidth.Items.Add("12");
            CBPenWidth.Items.Add("16");
            CBPenWidth.Items.Add("20");
            CBPenWidth.Items.Add("24");
            CBPenWidth.Items.Add("36");
            CBPenWidth.Items.Add("72");

            CBPenColor.Items.Add("Red");
            CBPenColor.Items.Add("Blue");
            CBPenColor.Items.Add("Green");
            CBPenColor.Items.Add("Black");

        }

        private void LBPenColor_Click(object sender, EventArgs e)
        {

        }

        private void LBPenType_Click(object sender, EventArgs e)
        {

        }

        private void BTPenOK_Click(object sender, EventArgs e)
        {
            //TODO: create exceptions
            this.Hide();

        }

        private void LBPenWidth_Click(object sender, EventArgs e)
        {

        }

        private void CBPenWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void CBPenType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CBPenColor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
