using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp4.Shapes;

namespace WindowsFormsApp4
{
    public partial class Create_Figure : Form
    {
        public List<Shape> ShapeList;
        public Create_Figure(List<Shape> shapeList)
        {
            InitializeComponent();
            ShapeList = shapeList;

            CBCreateFigure.Items.Add("Triangle");
            CBCreateFigure.Items.Add("Trapezoid");
            CBCreateFigure.Items.Add("Square");
            CBCreateFigure.Items.Add("Rectangle");
            CBCreateFigure.Items.Add("Circle");

            ShapeLabel.Hide();
            sideOneLabel.Hide();
            sideTwoLabel.Hide();
            sideThreeLabel.Hide();
            sideFourLabel.Hide();

            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();

            //ShapeLabel.BackColor = Color.Black;
            //sideOneLabel.BackColor = Color.Black;
            //sideTwoLabel.BackColor = Color.Black;
            //sideThreeLabel.BackColor = Color.Black;
            //sideFourLabel.BackColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(CBCreateFigure.SelectedItem.Equals("Circle"))
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    throw new Exception("Enter valid Legth");
                }
            }
            else if(CBCreateFigure.SelectedItem.Equals("Rectangle"))
            {
                if(string.IsNullOrEmpty(textBox1.Text))
                {
                    throw new Exception("Enter valid Legth");
                }
            }
            else if(CBCreateFigure.SelectedItem.Equals("Triangle"))
            {
                IfExistTriangle(textBox1.Text, textBox2.Text, textBox3.Text);

            }
            else if(CBCreateFigure.SelectedItem.Equals("Square"))
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    throw new Exception("Enter valid Legth");
                }
            }
            else if (CBCreateFigure.SelectedItem.Equals("Parallelogram"))
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    throw new Exception("Enter valid Legth");
                }
            }
            else if (CBCreateFigure.SelectedItem.Equals("Trapezoid"))
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    throw new Exception("Enter valid Legth");
                }
                //if exist
            }

            this.Hide();
        }

        private void IfExistTriangle(string text1, string text2, string text3)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBCreateFigure.SelectedItem.Equals("Circle"))
            {
                ShapeLabel.Text = "Circle";

                ShapeLabel.Show();
                textBox1.Show();

                sideOneLabel.Text = "Radius";
                sideOneLabel.Show();

                sideTwoLabel.Hide();
                sideThreeLabel.Hide();
                sideFourLabel.Hide();
                textBox2.Hide();
                textBox3.Hide();
                textBox4.Hide();

            }
            else if (CBCreateFigure.SelectedItem.Equals("Rectangle"))
            {
                ShapeLabel.Text = "Rectangle";
                ShapeLabel.Show();
                textBox1.Show();
                textBox2.Show();

                sideOneLabel.Text = "Width";
                sideOneLabel.Show();

                sideTwoLabel.Text = "Heigth";
                sideTwoLabel.Show();

                sideThreeLabel.Hide();
                sideFourLabel.Hide();
                textBox3.Hide();
                textBox4.Hide();
            }
            else if (CBCreateFigure.SelectedItem.Equals("Triangle"))
            {
                textBox1.Show();
                textBox2.Show();
                textBox3.Show();
                sideOneLabel.Text = "SideOne";
                sideOneLabel.Show();
                sideTwoLabel.Text = "SideTwo";
                sideTwoLabel.Show();
                sideThreeLabel.Text = "SideThree";
                sideThreeLabel.Show();

                ShapeLabel.Text = "Triangle";
                ShapeLabel.Show();
                sideFourLabel.Hide();

                textBox4.Hide();
            }
            else if (CBCreateFigure.SelectedItem.Equals("Square"))
            {
                ShapeLabel.Text = "Square";

                ShapeLabel.Show();
                textBox1.Show();

                sideOneLabel.Text = "Side";
                sideOneLabel.Show();

                sideTwoLabel.Hide();
                sideThreeLabel.Hide();
                sideFourLabel.Hide();
                textBox2.Hide();
                textBox3.Hide();
                textBox4.Hide();
            }
            else if (CBCreateFigure.SelectedItem.Equals("Trapezoid"))
            {
                ShapeLabel.Text = "Trapezoid";

                ShapeLabel.Show();

                textBox1.Show();
                textBox2.Show();
                textBox3.Show();
                textBox4.Show();
                sideOneLabel.Show();
                sideTwoLabel.Show();
                sideThreeLabel.Show();
                sideFourLabel.Show();
            }
            else
            {
                MessageBox.Show("Select form to add.");
            }
        }

        private void Create_Figure_Load(object sender, EventArgs e)
        {

        }
    }
}
