using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOPproject
{
    public partial class FormProperties : Form
    {
        
        
        public FormProperties()

        {
            InitializeComponent();
            

        }

        private void FormProperties_Load(object sender, EventArgs e)
        {
            txtBoxWidth.Text = strWidth;
            txtBoxHeight.Text = strHeight;
            radioBtnRectangle.Checked = drawRect;
            radioBtnEllipse.Checked = drawEllipse;
            radioBtnTriangle.Checked = drawTriangle;
            
            
        }

        public bool drawRect { get; set; }
        public bool drawEllipse { get; set; }
        public bool drawTriangle { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Color Fillcolor { get; set; }
        public string strWidth { get; set; }
        public string strHeight { get; set; }
        




        private void radioBtnRectangle_CheckedChanged(object sender, EventArgs e)
        {
        }
        
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                Width = int.Parse(txtBoxWidth.Text);
                Height = int.Parse(txtBoxHeight.Text);
                drawRect = radioBtnRectangle.Checked;
                drawEllipse = radioBtnEllipse.Checked;
                drawTriangle = radioBtnTriangle.Checked;
            }
            catch(Exception exception)
            {
                Width = 0;
                Height = 0;
            }
        }

        private void radioBtnEllipse_CheckedChanged(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog col = new ColorDialog();
            if (col.ShowDialog() == DialogResult.OK)
            {

                Fillcolor = col.Color;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Fillcolor = Color.Transparent;
        }

        private void txtBoxWidth_Validating(object sender, CancelEventArgs e)
        {
            if(txtBoxWidth.Text == string.Empty)
                MessageBox.Show("Invalid input!");
            else if(!int.TryParse(txtBoxWidth.Text,out int a)) MessageBox.Show("Invalid input!");
        }

        private void txtBoxHeight_Validating(object sender, CancelEventArgs e)
        {
            if (txtBoxHeight.Text == string.Empty)
                MessageBox.Show("Invalid input!");
            else if (!int.TryParse(txtBoxHeight.Text, out int a)) MessageBox.Show("Invalid input!");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
                 if (drawRect)      { radioBtnEllipse.Checked = false; radioBtnTriangle.Checked = false; radioBtnRectangle.Checked = true; }
            else if (drawEllipse) { radioBtnRectangle.Checked = false; radioBtnTriangle.Checked = false; radioBtnEllipse.Checked = true; }
            else if (drawTriangle) { radioBtnRectangle.Checked = false; radioBtnEllipse.Checked = false; radioBtnTriangle.Checked = true; }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
