using System;
using System.Windows.Forms;
using WindowsFormsApp4.Shapes;

namespace WindowsFormsApp4
{
    public partial class ShapeAttributes : Form
    {
        private Shape ShapeToDisplay;
        public ShapeAttributes(Shape shape)
        {
            InitializeComponent();
            this.ShapeToDisplay = shape;
        }

        private void ShapeAttributes_Load(object sender, EventArgs e)
        {
            PerimeterTextBox.Text = this.ShapeToDisplay.Perimeter().ToString();
            SurfaceTextBox.Text = this.ShapeToDisplay.CalculateSurface().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
