namespace WindowsFormsApp4
{
    partial class Create_Figure
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
            this.CBCreateFigure = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.sideOneLabel = new System.Windows.Forms.Label();
            this.sideTwoLabel = new System.Windows.Forms.Label();
            this.sideThreeLabel = new System.Windows.Forms.Label();
            this.sideFourLabel = new System.Windows.Forms.Label();
            this.ShapeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CBCreateFigure
            // 
            this.CBCreateFigure.AutoCompleteCustomSource.AddRange(new string[] {
            "Circle",
            "Rectangle",
            "Square"});
            this.CBCreateFigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CBCreateFigure.ForeColor = System.Drawing.Color.Purple;
            this.CBCreateFigure.FormattingEnabled = true;
            this.CBCreateFigure.Location = new System.Drawing.Point(26, 91);
            this.CBCreateFigure.Name = "CBCreateFigure";
            this.CBCreateFigure.Size = new System.Drawing.Size(179, 34);
            this.CBCreateFigure.TabIndex = 0;
            this.CBCreateFigure.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(537, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 69);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(332, 138);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(133, 26);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(332, 191);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(133, 26);
            this.textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(332, 252);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(133, 26);
            this.textBox3.TabIndex = 9;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox4.Location = new System.Drawing.Point(332, 310);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(133, 26);
            this.textBox4.TabIndex = 11;
            // 
            // sideOneLabel
            // 
            this.sideOneLabel.AutoSize = true;
            this.sideOneLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.sideOneLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sideOneLabel.ForeColor = System.Drawing.Color.Black;
            this.sideOneLabel.Location = new System.Drawing.Point(232, 138);
            this.sideOneLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sideOneLabel.Name = "sideOneLabel";
            this.sideOneLabel.Size = new System.Drawing.Size(71, 18);
            this.sideOneLabel.TabIndex = 16;
            this.sideOneLabel.Text = "Side one";
            // 
            // sideTwoLabel
            // 
            this.sideTwoLabel.AutoSize = true;
            this.sideTwoLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.sideTwoLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sideTwoLabel.ForeColor = System.Drawing.Color.Black;
            this.sideTwoLabel.Location = new System.Drawing.Point(229, 197);
            this.sideTwoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sideTwoLabel.Name = "sideTwoLabel";
            this.sideTwoLabel.Size = new System.Drawing.Size(69, 18);
            this.sideTwoLabel.TabIndex = 17;
            this.sideTwoLabel.Text = "Side two";
            // 
            // sideThreeLabel
            // 
            this.sideThreeLabel.AutoSize = true;
            this.sideThreeLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.sideThreeLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sideThreeLabel.ForeColor = System.Drawing.Color.Black;
            this.sideThreeLabel.Location = new System.Drawing.Point(229, 258);
            this.sideThreeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sideThreeLabel.Name = "sideThreeLabel";
            this.sideThreeLabel.Size = new System.Drawing.Size(80, 18);
            this.sideThreeLabel.TabIndex = 18;
            this.sideThreeLabel.Text = "Side three";
            // 
            // sideFourLabel
            // 
            this.sideFourLabel.AutoSize = true;
            this.sideFourLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.sideFourLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sideFourLabel.ForeColor = System.Drawing.Color.Black;
            this.sideFourLabel.Location = new System.Drawing.Point(229, 316);
            this.sideFourLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sideFourLabel.Name = "sideFourLabel";
            this.sideFourLabel.Size = new System.Drawing.Size(71, 18);
            this.sideFourLabel.TabIndex = 19;
            this.sideFourLabel.Text = "Side four";
            // 
            // ShapeLabel
            // 
            this.ShapeLabel.AutoSize = true;
            this.ShapeLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ShapeLabel.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShapeLabel.ForeColor = System.Drawing.Color.Black;
            this.ShapeLabel.Location = new System.Drawing.Point(228, 29);
            this.ShapeLabel.Name = "ShapeLabel";
            this.ShapeLabel.Size = new System.Drawing.Size(113, 39);
            this.ShapeLabel.TabIndex = 20;
            this.ShapeLabel.Text = "Shape";
            // 
            // Create_Figure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 406);
            this.Controls.Add(this.ShapeLabel);
            this.Controls.Add(this.sideFourLabel);
            this.Controls.Add(this.sideThreeLabel);
            this.Controls.Add(this.sideTwoLabel);
            this.Controls.Add(this.sideOneLabel);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CBCreateFigure);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Create_Figure";
            this.Text = "Create_Figure";
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.Load += new System.EventHandler(this.Create_Figure_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.ComboBox CBCreateFigure;
        internal System.Windows.Forms.TextBox textBox1;
        internal System.Windows.Forms.TextBox textBox2;
        internal System.Windows.Forms.TextBox textBox3;
        internal System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label ShapeLabel;
        private System.Windows.Forms.Label sideOneLabel;
        private System.Windows.Forms.Label sideTwoLabel;
        private System.Windows.Forms.Label sideThreeLabel;
        private System.Windows.Forms.Label sideFourLabel;
    }
}