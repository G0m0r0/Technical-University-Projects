using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;


namespace OOPproject
{

    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormProperties prop = new FormProperties();
            if (prop.ShowDialog() == DialogResult.OK)
            {
                sWidth = prop.Width;
                sHeight = prop.Height;
                drawRect = prop.drawRect;
                drawEllipse = prop.drawEllipse;
                drawTriangle = prop.drawTriangle;
                Fillcolor = prop.Fillcolor;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }


        
        Scene scene = new Scene();
       
        protected override void OnPaint(PaintEventArgs e)
        {
            scene.Paint(e.Graphics);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {


            if (e.Button.Equals(MouseButtons.Left) && drawRect)
            {
                calcTool = false;
                btnToolArea.BackColor = Color.Transparent;
                var rectangle = new Rectangle(sWidth, sHeight);
                rectangle.ShapePos = e.Location;
                rectangle.FillColor = Color.Transparent;
                
                scene.AddShape(rectangle);
                
                
            }
            else if (e.Button.Equals(MouseButtons.Left) && drawEllipse)
            {
                calcTool = false;
                btnToolArea.BackColor = Color.Transparent;
                var ellipse = new Ellipse(sWidth, sHeight);
                ellipse.ShapePos = e.Location;

                scene.AddShape(ellipse);
                
            }
            else if (e.Button.Equals(MouseButtons.Left) && drawTriangle)
            {
                calcTool = false;
                btnToolArea.BackColor = Color.Transparent;
                var triangle = new Triangle(sWidth, sHeight);
                triangle.ShapePos = e.Location;

                scene.AddShape(triangle);

            }



            if (e.Button.Equals(MouseButtons.Right)&& !calcTool&&!delTool&&!moveShape)
                {
                scene.AddSelectedShape(e.Location);
                scene.ChangeColorandSize(sWidth, sHeight, Fillcolor);
                Invalidate();
                }
            else if (e.Button.Equals(MouseButtons.Right) && calcTool && !delTool&&!moveShape)
            {
                scene.ShowArea();
            }

            else if (e.Button.Equals(MouseButtons.Right) && delTool &&!calcTool&&!moveShape)
            {
                scene.AddSelectedShape(e.Location);
                scene.RemoveShape();
                Invalidate();
            }
            Invalidate();
        }
        
        int sWidth { get; set; }
        int sHeight { get; set; }
        bool drawRect { get; set; }
        bool drawEllipse { get; set; }
        bool drawTriangle { get; set; }
        bool calcTool { get; set; }
        bool delTool { get; set; }
        bool moveShape { get; set; }
        Color Fillcolor { get; set; }

        
        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            calcTool = false;
            delTool = false;
            moveShape = false;
            btnToolArea.BackColor = Color.Transparent;
            btnToolDel.BackColor = Color.Transparent;
            btnMoveTool.BackColor = Color.Transparent;
            FormProperties prop = new FormProperties();
           

            prop.strWidth = sWidth.ToString();
            prop.strHeight = sHeight.ToString();
            prop.drawRect = drawRect;
            prop.drawEllipse = drawEllipse;
            prop.drawTriangle = drawTriangle;
            prop.Fillcolor = Fillcolor;
            
                if (prop.ShowDialog() == DialogResult.OK)
                {

                    sWidth = prop.Width;
                    sHeight = prop.Height;
                    drawRect = prop.drawRect;
                    drawEllipse = prop.drawEllipse;
                    drawTriangle = prop.drawTriangle;
                    Fillcolor = prop.Fillcolor;
                }
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (!calcTool) { calcTool = true; btnToolArea.BackColor = Color.LightSkyBlue;delTool = false;moveShape = false; }
            else if (calcTool) { calcTool = false; btnToolArea.BackColor = Color.Transparent; }
            
            
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (!delTool) { delTool = true; btnToolDel.BackColor = Color.LightSkyBlue; calcTool = false;moveShape = false; }
            else if (delTool) { delTool = false; btnToolDel.BackColor = Color.Transparent; }
        }

        private void btnToolDel_MouseHover(object sender, EventArgs e)
        {


        }

        private void toolStripButton1_Click_2(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() ==DialogResult.OK )
            {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream,scene);
            stream.Close();
            }

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button.Equals(MouseButtons.Right)&&moveShape)
            {
                scene.AddSelectedShape(e.Location);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right)&&moveShape)
            {
                scene.MoveShape(e.Location);
                Invalidate();
            }
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                scene = (Scene)formatter.Deserialize(stream);


                stream.Close();
                Invalidate();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (!moveShape) { moveShape = true; btnMoveTool.BackColor = Color.LightSkyBlue; calcTool = false;delTool = false; }
            else if (moveShape) { moveShape = false; btnMoveTool.BackColor = Color.Transparent; }


        }
    }
}
