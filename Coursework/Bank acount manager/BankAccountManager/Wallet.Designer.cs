namespace BankAccountManager
{
    partial class Wallet
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
            this.Refresh = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.AddAccountButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.IbanLabel = new System.Windows.Forms.Label();
            this.DepositButton = new System.Windows.Forms.Button();
            this.WithdrawButton = new System.Windows.Forms.Button();
            this.AllMoneyButton = new System.Windows.Forms.Button();
            this.BalanceTextBox = new System.Windows.Forms.TextBox();
            this.Balance = new System.Windows.Forms.Label();
            this.AmounthTextBox = new System.Windows.Forms.TextBox();
            this.ActionLebel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(51, 332);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(145, 61);
            this.Refresh.TabIndex = 1;
            this.Refresh.Text = "Refresh";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);

            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(51, 399);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(321, 39);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // AddAccountButton
            // 
            this.AddAccountButton.Location = new System.Drawing.Point(202, 332);
            this.AddAccountButton.Name = "AddAccountButton";
            this.AddAccountButton.Size = new System.Drawing.Size(170, 61);
            this.AddAccountButton.TabIndex = 3;
            this.AddAccountButton.Text = "Add account";
            this.AddAccountButton.UseVisualStyleBackColor = true;
            this.AddAccountButton.Click += new System.EventHandler(this.AddAccountButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(60, 74);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(312, 23);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(60, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 28);
            this.label1.TabIndex = 5;
            this.label1.Text = "Account:";
            // 
            // IbanLabel
            // 
            this.IbanLabel.AutoSize = true;
            this.IbanLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IbanLabel.Location = new System.Drawing.Point(154, 25);
            this.IbanLabel.Name = "IbanLabel";
            this.IbanLabel.Size = new System.Drawing.Size(56, 28);
            this.IbanLabel.TabIndex = 7;
            this.IbanLabel.Text = "IBAN";
            // 
            // DepositButton
            // 
            this.DepositButton.Enabled = false;
            this.DepositButton.Location = new System.Drawing.Point(60, 120);
            this.DepositButton.Name = "DepositButton";
            this.DepositButton.Size = new System.Drawing.Size(82, 36);
            this.DepositButton.TabIndex = 9;
            this.DepositButton.Text = "Deposit";
            this.DepositButton.UseVisualStyleBackColor = true;
            this.DepositButton.Click += new System.EventHandler(this.DepositButton_Click);
            // 
            // WithdrawButton
            // 
            this.WithdrawButton.Enabled = false;
            this.WithdrawButton.Location = new System.Drawing.Point(172, 120);
            this.WithdrawButton.Name = "WithdrawButton";
            this.WithdrawButton.Size = new System.Drawing.Size(88, 36);
            this.WithdrawButton.TabIndex = 10;
            this.WithdrawButton.Text = "Withdraw";
            this.WithdrawButton.UseVisualStyleBackColor = true;
            this.WithdrawButton.Click += new System.EventHandler(this.WithdrawButton_Click);
            // 
            // AllMoneyButton
            // 
            this.AllMoneyButton.Location = new System.Drawing.Point(283, 120);
            this.AllMoneyButton.Name = "AllMoneyButton";
            this.AllMoneyButton.Size = new System.Drawing.Size(89, 36);
            this.AllMoneyButton.TabIndex = 11;
            this.AllMoneyButton.Text = "All money";
            this.AllMoneyButton.UseVisualStyleBackColor = true;
            this.AllMoneyButton.Click += new System.EventHandler(this.AllMoneyButton_Click);
            // 
            // BalanceTextBox
            // 
            this.BalanceTextBox.Enabled = false;
            this.BalanceTextBox.Location = new System.Drawing.Point(113, 296);
            this.BalanceTextBox.Name = "BalanceTextBox";
            this.BalanceTextBox.Size = new System.Drawing.Size(259, 23);
            this.BalanceTextBox.TabIndex = 12;
            // 
            // Balance
            // 
            this.Balance.AutoSize = true;
            this.Balance.Location = new System.Drawing.Point(51, 299);
            this.Balance.Name = "Balance";
            this.Balance.Size = new System.Drawing.Size(51, 15);
            this.Balance.TabIndex = 14;
            this.Balance.Text = "Balance:";
            // 
            // AmounthTextBox
            // 
            this.AmounthTextBox.Location = new System.Drawing.Point(113, 182);
            this.AmounthTextBox.Name = "AmounthTextBox";
            this.AmounthTextBox.Size = new System.Drawing.Size(245, 23);
            this.AmounthTextBox.TabIndex = 15;
            // 
            // ActionLebel
            // 
            this.ActionLebel.AutoSize = true;
            this.ActionLebel.Location = new System.Drawing.Point(51, 185);
            this.ActionLebel.Name = "ActionLebel";
            this.ActionLebel.Size = new System.Drawing.Size(61, 15);
            this.ActionLebel.TabIndex = 16;
            this.ActionLebel.Text = "Amounth:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(236, 222);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Resent transactions";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Interest:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(113, 255);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 20;
            this.textBox1.Text = "00:00:00";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Wallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(422, 450);
            this.Controls.Add(this.ActionLebel);
            this.Controls.Add(this.AmounthTextBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.IbanLabel);
            this.Controls.Add(this.BalanceTextBox);
            this.Controls.Add(this.Balance);
            this.Controls.Add(this.WithdrawButton);
            this.Controls.Add(this.AllMoneyButton);
            this.Controls.Add(this.DepositButton);
            this.Controls.Add(this.AddAccountButton);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Wallet";
            this.Text = "Wallet";
            this.Load += new System.EventHandler(this.Wallet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button AddAccountButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label IbanLabel;
        private System.Windows.Forms.Button DepositButton;
        private System.Windows.Forms.Button WithdrawButton;
        private System.Windows.Forms.Button AllMoneyButton;
        private System.Windows.Forms.TextBox BalanceTextBox;
        private System.Windows.Forms.Label Balance;
        private System.Windows.Forms.TextBox AmounthTextBox;
        private System.Windows.Forms.Label ActionLebel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
    }
}