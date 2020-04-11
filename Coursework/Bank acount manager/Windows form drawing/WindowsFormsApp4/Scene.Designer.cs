namespace WindowsFormsApp4
{
    partial class Scene
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
            this.BTSetting = new System.Windows.Forms.Button();
            this.BTClear = new System.Windows.Forms.Button();
            this.BTInfoScene = new System.Windows.Forms.Button();
            this.CBFilter = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTSetting
            // 
            this.BTSetting.Location = new System.Drawing.Point(48, 95);
            this.BTSetting.Margin = new System.Windows.Forms.Padding(4);
            this.BTSetting.Name = "BTSetting";
            this.BTSetting.Size = new System.Drawing.Size(115, 52);
            this.BTSetting.TabIndex = 0;
            this.BTSetting.Text = "Shape settings";
            this.BTSetting.UseVisualStyleBackColor = true;
            this.BTSetting.Click += new System.EventHandler(this.button1_Click);
            // 
            // BTClear
            // 
            this.BTClear.Location = new System.Drawing.Point(48, 463);
            this.BTClear.Name = "BTClear";
            this.BTClear.Size = new System.Drawing.Size(115, 52);
            this.BTClear.TabIndex = 1;
            this.BTClear.Text = "Clear";
            this.BTClear.UseVisualStyleBackColor = true;
            this.BTClear.Click += new System.EventHandler(this.button2_Click);
            // 
            // BTInfoScene
            // 
            this.BTInfoScene.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)), true);
            this.BTInfoScene.Location = new System.Drawing.Point(5, 12);
            this.BTInfoScene.Name = "BTInfoScene";
            this.BTInfoScene.Size = new System.Drawing.Size(26, 36);
            this.BTInfoScene.TabIndex = 2;
            this.BTInfoScene.Text = "?";
            this.BTInfoScene.UseVisualStyleBackColor = true;
            this.BTInfoScene.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // CBFilter
            // 
            this.CBFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CBFilter.FormattingEnabled = true;
            this.CBFilter.Items.AddRange(new object[] {
            "Surface(10)",
            "Perimeter(10)",
            "Circle",
            "Triangle",
            "Square",
            "Rectangle",
            "All shapes"});
            this.CBFilter.Location = new System.Drawing.Point(48, 45);
            this.CBFilter.Name = "CBFilter";
            this.CBFilter.Size = new System.Drawing.Size(115, 21);
            this.CBFilter.TabIndex = 3;
            this.CBFilter.SelectedIndexChanged += new System.EventHandler(this.CBFilter_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(48, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 47);
            this.button1.TabIndex = 4;
            this.button1.Text = "Pen settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Filter";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(48, 255);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 46);
            this.button2.TabIndex = 6;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(48, 307);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 49);
            this.button3.TabIndex = 7;
            this.button3.Text = "Load";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Scene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CBFilter);
            this.Controls.Add(this.BTInfoScene);
            this.Controls.Add(this.BTClear);
            this.Controls.Add(this.BTSetting);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Scene";
            this.Text = "Form1";
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Scene_MouseDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Scene_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button BTSetting;
        protected System.Windows.Forms.Button BTClear;
        protected System.Windows.Forms.Button BTInfoScene;
        protected System.Windows.Forms.ComboBox CBFilter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

