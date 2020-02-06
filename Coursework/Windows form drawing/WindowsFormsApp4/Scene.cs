using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using WindowsFormsApp4.Coordinates;
using WindowsFormsApp4.ShapeActions;
using WindowsFormsApp4.Shapes;

namespace WindowsFormsApp4
{
    public partial class Scene : Form
    {
        //private List<Shape> shapesList;
        private Create_Figure createFigure;
        private PenSettings penSettings;
        private ShapeAttributes shapeattributes;

        private ShapeRepository ShapesRepo;

        public Scene()
        {
            InitializeComponent();
            //this.shapesList = new List<Shape>();
            this.ShapesRepo = new ShapeRepository();
            this.createFigure = new Create_Figure(ShapesRepo.shapes);
            this.penSettings = new PenSettings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (penSettings.CBPenColor.SelectedItem == null 
                || penSettings.PenTypeComboBox.SelectedItem == null 
                || penSettings.CBPenWidth.SelectedItem == null)
            {
                MessageBox.Show("First choose pen settings!");
                return;
            }
            createFigure.Show();
        }

        private void Scene_MouseDown(object sender, MouseEventArgs e)
        {
            if (penSettings.CBPenColor.SelectedItem == null
                || penSettings.PenTypeComboBox.SelectedItem == null
                || penSettings.CBPenWidth.SelectedItem == null)
            {
                MessageBox.Show("First choose pen settings!");
                return;
            }
            if(createFigure.CBCreateFigure.SelectedItem==null||createFigure.textBox1.Text==" ")
            {
                MessageBox.Show("First choos form to display");
            }
            if (e.Button == MouseButtons.Right)
            {
                foreach (var shapeToSearch in this.ShapesRepo.shapes)
                {
                    if (shapeToSearch.IsInside(e.Location))
                    {
                        this.shapeattributes = new ShapeAttributes(shapeToSearch);
                        shapeattributes.Show();
                        break;
                    }
                }
            }
            else
            {
                if (!ExceptionArea(e))
                {
                    return;
                }

                MyPoint point = new MyPoint(e.X, e.Y);

                Shape shape = CreateShape(point);
                ShapesRepo.AddShape(shape);

                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("temporary.txt",
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.None);
                formatter.Serialize(stream, this.ShapesRepo);
                stream.Close();
            }
            Invalidate();
        }

        private bool ExceptionArea(MouseEventArgs e)
        {
            if (e.X < 200)
            {
                return false;
            }

            return true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;

            Pen pen = new Pen(Color.Black, 1);
            graphics.DrawLine(pen, 200, 1, 200, 601);

            foreach (var shapeToPaint in this.ShapesRepo.shapes)
            {
                if (penSettings.PenTypeComboBox.Text == "Line")
                {
                    if (penSettings.CBPenColor.Text == "Red")
                    {
                        shapeToPaint.Paint(graphics, new Pen(Color.Red, float.Parse(penSettings.CBPenWidth.Text)));
                    }
                    else if (penSettings.CBPenColor.Text == "Blue")
                    {
                        shapeToPaint.Paint(graphics, new Pen(Color.Blue, float.Parse(penSettings.CBPenWidth.Text)));
                    }
                    else if (penSettings.CBPenColor.Text == "Green")
                    {
                        shapeToPaint.Paint(graphics, new Pen(Color.Green, float.Parse(penSettings.CBPenWidth.Text)));
                    }
                    else if (penSettings.CBPenColor.Text == "Black")
                    {
                        shapeToPaint.Paint(graphics, new Pen(Color.Black, float.Parse(penSettings.CBPenWidth.Text)));
                    }
                }
                else if (penSettings.PenTypeComboBox.Text == "Solid")
                {
                    if (penSettings.CBPenColor.Text == "Red")
                    {
                        shapeToPaint.PaintSolid(graphics, new SolidBrush(Color.Red));
                    }
                    else if (penSettings.CBPenColor.Text == "Blue")
                    {
                        shapeToPaint.PaintSolid(graphics, new SolidBrush(Color.Blue));
                    }
                    else if (penSettings.CBPenColor.Text == "Green")
                    {
                        shapeToPaint.PaintSolid(graphics, new SolidBrush(Color.Green));
                    }
                    else if (penSettings.CBPenColor.Text == "Black")
                    {
                        shapeToPaint.PaintSolid(graphics, new SolidBrush(Color.Black));
                    }
                }
            }
        }

        private Shape CreateShape(MyPoint point)
        {
            Shape shape = null;

            if (createFigure.CBCreateFigure.SelectedItem.Equals("Circle"))
            {
                int radius = int.Parse(createFigure.textBox1.Text);

                shape = new Circle(point, radius);
            }
            else if (createFigure.CBCreateFigure.SelectedItem.Equals("Rectangle"))
            {
                int lenght = int.Parse(createFigure.textBox1.Text);
                int width = int.Parse(createFigure.textBox2.Text);

                shape = new Shapes.Rectangle(point, lenght, width);
            }
            else if (createFigure.CBCreateFigure.SelectedItem.Equals("Triangle"))
            {
                int sideone = int.Parse(createFigure.textBox1.Text);
                int sidetwo = int.Parse(createFigure.textBox2.Text);
                int sidethree = int.Parse(createFigure.textBox3.Text);

                shape = new Triangle(point, sideone, sidetwo, sidethree);
            }
            else if (createFigure.CBCreateFigure.SelectedItem.Equals("Square"))
            {
                int side = int.Parse(createFigure.textBox1.Text);

                shape = new Square(point, side);
            }
            else if (createFigure.CBCreateFigure.SelectedItem.Equals("Trapezoid"))
            {
                int sideone = int.Parse(createFigure.textBox1.Text);
                int sidetwo = int.Parse(createFigure.textBox2.Text);
                int sidethree = int.Parse(createFigure.textBox3.Text);
                int sidefour = int.Parse(createFigure.textBox4.Text);
                shape = new Trapezoid(point, sideone, sidetwo, sidethree, sidefour);
            }
            else
            {
                throw new Exception("First select settings!");
            }

            return shape;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.ShapesRepo.shapes.Count; i++)
            {
                ShapesRepo.shapes.RemoveAt(i);
                i--;
            }
            Refresh();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Just a interesting button!");
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            penSettings.Show();
        }

        private void CBFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            var newListToDisplay = new List<Shape>();

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("temporary.txt",
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read);
            this.ShapesRepo = (ShapeRepository)formatter.Deserialize(stream);
            stream.Close();
            Invalidate();

            if (CBFilter.SelectedIndex == 0)
            {
                foreach (var shape in this.ShapesRepo.shapes.OrderBy(x => x.CalculateSurface()).Take(10))
                {
                    newListToDisplay.Add(shape);
                }
            }
            else if (CBFilter.SelectedIndex == 1)
            { 
                foreach (var shape in this.ShapesRepo.shapes.OrderBy(x => x.Perimeter()).Take(10))
                {
                    newListToDisplay.Add(shape);
                }
            }
            else if (CBFilter.SelectedIndex == 2)
            {
                newListToDisplay = this.ShapesRepo.shapes.Where(x => x.GetType().Name == "Circle").ToList();
            }
            else if (CBFilter.SelectedIndex == 3)
            {
                newListToDisplay = this.ShapesRepo.shapes.Where(x => x.GetType().Name == "Triangle").ToList();
            }
            else if (CBFilter.SelectedIndex == 4)
            {
                newListToDisplay = this.ShapesRepo.shapes.Where(x => x.GetType().Name == "Square").ToList();
            }
            else if (CBFilter.SelectedIndex == 5)
            {
                newListToDisplay = this.ShapesRepo.shapes.Where(x => x.GetType().Name == "Rectangle").ToList();
            }
            else if (CBFilter.SelectedIndex == 6)
            {
                Invalidate();
                return;
            }

            for (int i = 0; i < ShapesRepo.shapes.Count; i++)
            {
                ShapesRepo.shapes.RemoveAt(i);
                i--;
            }

            for (int i = 0; i < newListToDisplay.Count; i++)
            {
                ShapesRepo.AddShape(newListToDisplay[i]);
            }
            Invalidate();
            // Refresh();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            if (save.ShowDialog() == DialogResult.OK)
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(save.FileName,
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.None);
                formatter.Serialize(stream, this.ShapesRepo);
                stream.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (penSettings.CBPenColor.SelectedItem == null || penSettings.PenTypeComboBox.SelectedItem == null || penSettings.CBPenWidth.SelectedItem==null)
            {
                MessageBox.Show("First choose pen settings!");
                return;
            }
            OpenFileDialog load = new OpenFileDialog();
            if (load.ShowDialog() == DialogResult.OK)
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(load.FileName,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.Read);
                this.ShapesRepo = (ShapeRepository)formatter.Deserialize(stream);

                stream.Close();
                Invalidate();
            }
        }
    }
}
