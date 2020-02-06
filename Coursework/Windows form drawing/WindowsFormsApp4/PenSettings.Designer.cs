namespace WindowsFormsApp4
{
    partial class PenSettings
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
            this.BTPenOK = new System.Windows.Forms.Button();
            this.LBPenWidth = new System.Windows.Forms.Label();
            this.CBPenWidth = new System.Windows.Forms.ComboBox();
            this.CBPenColor = new System.Windows.Forms.ComboBox();
            this.LBPenColor = new System.Windows.Forms.Label();
            this.LBPenType = new System.Windows.Forms.Label();
            this.PenTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // BTPenOK
            // 
            this.BTPenOK.Location = new System.Drawing.Point(28, 302);
            this.BTPenOK.Margin = new System.Windows.Forms.Padding(2);
            this.BTPenOK.Name = "BTPenOK";
            this.BTPenOK.Size = new System.Drawing.Size(344, 40);
            this.BTPenOK.TabIndex = 0;
            this.BTPenOK.Text = "OK";
            this.BTPenOK.UseVisualStyleBackColor = true;
            this.BTPenOK.Click += new System.EventHandler(this.BTPenOK_Click);
            // 
            // LBPenWidth
            // 
            this.LBPenWidth.AutoSize = true;
            this.LBPenWidth.Location = new System.Drawing.Point(184, 36);
            this.LBPenWidth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LBPenWidth.Name = "LBPenWidth";
            this.LBPenWidth.Size = new System.Drawing.Size(35, 13);
            this.LBPenWidth.TabIndex = 2;
            this.LBPenWidth.Text = "Width";
            this.LBPenWidth.Click += new System.EventHandler(this.LBPenWidth_Click);
            // 
            // CBPenWidth
            // 
            this.CBPenWidth.FormattingEnabled = true;
            this.CBPenWidth.Location = new System.Drawing.Point(154, 63);
            this.CBPenWidth.Margin = new System.Windows.Forms.Padding(2);
            this.CBPenWidth.Name = "CBPenWidth";
            this.CBPenWidth.Size = new System.Drawing.Size(92, 21);
            this.CBPenWidth.TabIndex = 7;
            this.CBPenWidth.SelectedIndexChanged += new System.EventHandler(this.CBPenWidth_SelectedIndexChanged);
            // 
            // CBPenColor
            // 
            this.CBPenColor.FormattingEnabled = true;
            this.CBPenColor.Location = new System.Drawing.Point(280, 63);
            this.CBPenColor.Margin = new System.Windows.Forms.Padding(2);
            this.CBPenColor.Name = "CBPenColor";
            this.CBPenColor.Size = new System.Drawing.Size(92, 21);
            this.CBPenColor.TabIndex = 9;
            this.CBPenColor.SelectedIndexChanged += new System.EventHandler(this.CBPenColor_SelectedIndexChanged);
            // 
            // LBPenColor
            // 
            this.LBPenColor.AutoSize = true;
            this.LBPenColor.Location = new System.Drawing.Point(306, 36);
            this.LBPenColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LBPenColor.Name = "LBPenColor";
            this.LBPenColor.Size = new System.Drawing.Size(31, 13);
            this.LBPenColor.TabIndex = 10;
            this.LBPenColor.Text = "Color";
            // 
            // LBPenType
            // 
            this.LBPenType.AutoSize = true;
            this.LBPenType.Location = new System.Drawing.Point(56, 36);
            this.LBPenType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LBPenType.Name = "LBPenType";
            this.LBPenType.Size = new System.Drawing.Size(31, 13);
            this.LBPenType.TabIndex = 8;
            this.LBPenType.Text = "Type";
            // 
            // PenTypeComboBox
            // 
            this.PenTypeComboBox.FormattingEnabled = true;
            this.PenTypeComboBox.Location = new System.Drawing.Point(28, 63);
            this.PenTypeComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.PenTypeComboBox.Name = "PenTypeComboBox";
            this.PenTypeComboBox.Size = new System.Drawing.Size(92, 21);
            this.PenTypeComboBox.TabIndex = 6;
            this.PenTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.CBPenType_SelectedIndexChanged);
            // 
            // PenSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(386, 366);
            this.Controls.Add(this.LBPenColor);
            this.Controls.Add(this.CBPenColor);
            this.Controls.Add(this.LBPenType);
            this.Controls.Add(this.CBPenWidth);
            this.Controls.Add(this.PenTypeComboBox);
            this.Controls.Add(this.LBPenWidth);
            this.Controls.Add(this.BTPenOK);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PenSettings";
            this.Text = "PenSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTPenOK;
        private System.Windows.Forms.Label LBPenWidth;
        private System.Windows.Forms.Label LBPenColor;
        internal System.Windows.Forms.ComboBox CBPenWidth;
        internal System.Windows.Forms.ComboBox CBPenColor;
        private System.Windows.Forms.Label LBPenType;
        internal System.Windows.Forms.ComboBox PenTypeComboBox;
    }
}