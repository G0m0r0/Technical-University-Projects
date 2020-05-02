using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p2
{
    public partial class Form1 : Form
    {
       // private Process proc;
        public Form1()
        {
            InitializeComponent();
           // proc = new Process();
        }
        string path =
                @"D:\Programming\University\Coursework\fn181218001\fn181218001\p1\bin\Debug\netcoreapp3.1\p1.exe";
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] output = RunP1($"{path} -g un.txt");
            string message = output[4].ToString()+'\n' + output[5].ToString();
            MessageBox.Show(message);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string[] output = RunP1($"{path} -h");
            string message = output[4].ToString() + output[5].ToString() + output[6].ToString()+ output[7].ToString()+ output[8].ToString();
            MessageBox.Show(message);
        }

        private string[] RunP1(string command)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.CreateNoWindow = false;
            proc.StartInfo.UseShellExecute = false;
            proc.Start();

            proc.StandardInput.WriteLine(command);
            var output = proc.StandardOutput.ReadToEnd().Split('\n');


            proc.StandardInput.Flush();
            //proc.StandardInput.Close();
            //proc.WaitForExit();
            proc.Close();

            return output;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] output = RunP1($"{path} -v un.txt");
            string message = output[4].ToString();
            MessageBox.Show(message);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] output = RunP1($"{path} -s un.txt st.txt");
            string message = output[4].ToString();
            MessageBox.Show(message);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
