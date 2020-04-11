namespace OOPproject
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnToolProp = new System.Windows.Forms.ToolStripButton();
            this.btnToolArea = new System.Windows.Forms.ToolStripButton();
            this.btnToolDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.btnMoveTool = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnToolProp,
            this.btnToolArea,
            this.btnMoveTool,
            this.btnToolDel,
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(2065, 42);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnToolProp
            // 
            this.btnToolProp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnToolProp.Image = ((System.Drawing.Image)(resources.GetObject("btnToolProp.Image")));
            this.btnToolProp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnToolProp.Name = "btnToolProp";
            this.btnToolProp.Size = new System.Drawing.Size(146, 36);
            this.btnToolProp.Text = "Shape Prop.";
            this.btnToolProp.ToolTipText = resources.GetString("btnToolProp.ToolTipText");
            this.btnToolProp.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnToolArea
            // 
            this.btnToolArea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnToolArea.Image = ((System.Drawing.Image)(resources.GetObject("btnToolArea.Image")));
            this.btnToolArea.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnToolArea.Name = "btnToolArea";
            this.btnToolArea.Size = new System.Drawing.Size(118, 36);
            this.btnToolArea.Text = "Calc Area";
            this.btnToolArea.ToolTipText = "Right Click the shape to calculate it\'s area.";
            this.btnToolArea.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // btnToolDel
            // 
            this.btnToolDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnToolDel.Image = ((System.Drawing.Image)(resources.GetObject("btnToolDel.Image")));
            this.btnToolDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnToolDel.Name = "btnToolDel";
            this.btnToolDel.Size = new System.Drawing.Size(178, 36);
            this.btnToolDel.Text = "Remove Shape";
            this.btnToolDel.ToolTipText = "Right Click the shape you want to remove";
            this.btnToolDel.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            this.btnToolDel.MouseHover += new System.EventHandler(this.btnToolDel_MouseHover);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(69, 36);
            this.toolStripButton1.Text = "Save";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_2);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(70, 36);
            this.toolStripButton2.Text = "Load";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click_1);
            // 
            // btnMoveTool
            // 
            this.btnMoveTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnMoveTool.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveTool.Image")));
            this.btnMoveTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMoveTool.Name = "btnMoveTool";
            this.btnMoveTool.Size = new System.Drawing.Size(153, 36);
            this.btnMoveTool.Text = "Move Shape";
            this.btnMoveTool.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2065, 1145);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnToolProp;
        private System.Windows.Forms.ToolStripButton btnToolArea;
        private System.Windows.Forms.ToolStripButton btnToolDel;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton btnMoveTool;
    }
}

