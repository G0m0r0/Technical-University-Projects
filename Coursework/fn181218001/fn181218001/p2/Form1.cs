namespace p2
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    public partial class Form1 : Form
    {
        string path =
               @"D:\Programming\University\Coursework\fn181218001\fn181218001\p1\bin\Debug\netcoreapp3.1\p1.exe";
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RunP1("-g un.txt");
        }

        private void RunP1(string command)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.CreateNoWindow = false;
            proc.StartInfo.UseShellExecute = false;
            proc.Start();

            proc.StandardInput.WriteLine($"{path} {command}");

            proc.StandardInput.Flush();
            proc.StandardInput.Close();
            proc.WaitForExit();
            var message = proc.StandardOutput.ReadToEnd().Split('\n').ToArray();

            ShowMessage(message);
        }

        private void ShowMessage(string[] message)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 4; i < message.Length - 1; i++)
            {
                sb.AppendLine(message[i]);
            }

            MessageBox.Show(sb.ToString().Trim());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RunP1("-v un.txt");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RunP1("-s un.txt st.txt");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RunP1("-h");
        }
    }
}
