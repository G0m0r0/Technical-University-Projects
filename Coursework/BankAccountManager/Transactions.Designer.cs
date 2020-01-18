namespace BankAccountManager
{
    partial class Transactions
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
            this.button2 = new System.Windows.Forms.Button();
            this.ListTransactions = new System.Windows.Forms.ListView();
            this.Num = new System.Windows.Forms.ColumnHeader();
            this.IBAN = new System.Windows.Forms.ColumnHeader();
            this.Date = new System.Windows.Forms.ColumnHeader();
            this.Type = new System.Windows.Forms.ColumnHeader();
            this.Amount = new System.Windows.Forms.ColumnHeader();
            this.BackButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(301, 399);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 39);
            this.button2.TabIndex = 4;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // ListTransactions
            // 
            this.ListTransactions.BackColor = System.Drawing.Color.Ivory;
            this.ListTransactions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Num,
            this.IBAN,
            this.Date,
            this.Type,
            this.Amount});
            this.ListTransactions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ListTransactions.FullRowSelect = true;
            this.ListTransactions.GridLines = true;
            this.ListTransactions.HideSelection = false;
            this.ListTransactions.Location = new System.Drawing.Point(24, 60);
            this.ListTransactions.Name = "ListTransactions";
            this.ListTransactions.Size = new System.Drawing.Size(383, 311);
            this.ListTransactions.TabIndex = 5;
            this.ListTransactions.UseCompatibleStateImageBehavior = false;
            this.ListTransactions.View = System.Windows.Forms.View.Details;
            this.ListTransactions.SelectedIndexChanged += new System.EventHandler(this.ListTransactions_SelectedIndexChanged);
            // 
            // Num
            // 
            this.Num.Name = "Num";
            this.Num.Text = "Num";
            this.Num.Width = 40;
            // 
            // IBAN
            // 
            this.IBAN.Name = "IBAN";
            this.IBAN.Text = "IBAN";
            this.IBAN.Width = 100;
            // 
            // Date
            // 
            this.Date.Name = "Date";
            this.Date.Text = "Date";
            this.Date.Width = 100;
            // 
            // Type
            // 
            this.Type.Name = "Type";
            this.Type.Text = "Type";
            this.Type.Width = 80;
            // 
            // Amount
            // 
            this.Amount.Name = "Amount";
            this.Amount.Text = "Amount";
            this.Amount.Width = 70;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(24, 399);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(96, 39);
            this.BackButton.TabIndex = 6;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Date",
            "Type- Withdraw",
            "Type- Deposit",
            "Amounth- Withdraw",
            "Amounth- Deposit"});
            this.comboBox1.Location = new System.Drawing.Point(113, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(24, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "Filter by:";
            // 
            // Transactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(426, 450);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ListTransactions);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.button2);
            this.HelpButton = true;
            this.Name = "Transactions";
            this.Text = "Transactions";
            this.Load += new System.EventHandler(this.Transactions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView ListTransactions;
        private System.Windows.Forms.ColumnHeader Num;
        private System.Windows.Forms.ColumnHeader IBAN;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader Amount;
    }
}