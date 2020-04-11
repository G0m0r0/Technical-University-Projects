namespace OOPproject
{
    partial class FormProperties
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
            this.btnApply = new System.Windows.Forms.Button();
            this.txtBoxWidth = new System.Windows.Forms.TextBox();
            this.txtBoxHeight = new System.Windows.Forms.TextBox();
            this.radioBtnRectangle = new System.Windows.Forms.RadioButton();
            this.radioBtnEllipse = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioBtnTriangle = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnApply.Location = new System.Drawing.Point(137, 300);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtBoxWidth
            // 
            this.txtBoxWidth.Location = new System.Drawing.Point(222, 28);
            this.txtBoxWidth.Name = "txtBoxWidth";
            this.txtBoxWidth.Size = new System.Drawing.Size(100, 20);
            this.txtBoxWidth.TabIndex = 1;
            this.txtBoxWidth.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxWidth_Validating);
            // 
            // txtBoxHeight
            // 
            this.txtBoxHeight.Location = new System.Drawing.Point(222, 82);
            this.txtBoxHeight.Name = "txtBoxHeight";
            this.txtBoxHeight.Size = new System.Drawing.Size(100, 20);
            this.txtBoxHeight.TabIndex = 2;
            this.txtBoxHeight.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxHeight_Validating);
            // 
            // radioBtnRectangle
            // 
            this.radioBtnRectangle.AutoSize = true;
            this.radioBtnRectangle.Location = new System.Drawing.Point(6, 31);
            this.radioBtnRectangle.Name = "radioBtnRectangle";
            this.radioBtnRectangle.Size = new System.Drawing.Size(87, 26);
            this.radioBtnRectangle.TabIndex = 3;
            this.radioBtnRectangle.Text = "Rectangle";
            this.radioBtnRectangle.UseVisualStyleBackColor = true;
            this.radioBtnRectangle.CheckedChanged += new System.EventHandler(this.radioBtnRectangle_CheckedChanged);
            // 
            // radioBtnEllipse
            // 
            this.radioBtnEllipse.AutoSize = true;
            this.radioBtnEllipse.Location = new System.Drawing.Point(6, 54);
            this.radioBtnEllipse.Name = "radioBtnEllipse";
            this.radioBtnEllipse.Size = new System.Drawing.Size(68, 26);
            this.radioBtnEllipse.TabIndex = 4;
            this.radioBtnEllipse.Text = "Ellipse";
            this.radioBtnEllipse.UseVisualStyleBackColor = true;
            this.radioBtnEllipse.CheckedChanged += new System.EventHandler(this.radioBtnEllipse_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 46);
            this.button1.TabIndex = 5;
            this.button1.Text = "pick a fill color";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 65);
            this.label1.TabIndex = 6;
            this.label1.Text = "Right Mouse click on specified shape to apply fill color\r\nor any change in size.\r" +
    "\n\r\n\r\n\r\n";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(119, 178);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "unpick color";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Width";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Height";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioBtnTriangle);
            this.groupBox1.Controls.Add(this.radioBtnEllipse);
            this.groupBox1.Controls.Add(this.radioBtnRectangle);
            this.groupBox1.Location = new System.Drawing.Point(17, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(96, 100);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shape";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // radioBtnTriangle
            // 
            this.radioBtnTriangle.AutoSize = true;
            this.radioBtnTriangle.Location = new System.Drawing.Point(6, 77);
            this.radioBtnTriangle.Name = "radioBtnTriangle";
            this.radioBtnTriangle.Size = new System.Drawing.Size(76, 26);
            this.radioBtnTriangle.TabIndex = 5;
            this.radioBtnTriangle.TabStop = true;
            this.radioBtnTriangle.Text = "Triangle";
            this.radioBtnTriangle.UseVisualStyleBackColor = true;
            this.radioBtnTriangle.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // FormProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 351);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtBoxHeight);
            this.Controls.Add(this.txtBoxWidth);
            this.Controls.Add(this.btnApply);
            this.Name = "FormProperties";
            this.Text = "FormProperties";
            this.Load += new System.EventHandler(this.FormProperties_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtBoxWidth;
        private System.Windows.Forms.TextBox txtBoxHeight;
        private System.Windows.Forms.RadioButton radioBtnRectangle;
        private System.Windows.Forms.RadioButton radioBtnEllipse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioBtnTriangle;
    }
}