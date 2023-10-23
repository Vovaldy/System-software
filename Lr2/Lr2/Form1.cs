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

namespace Lr2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //textBox3.Text = (Convert.ToInt32(textBox1.Text)
            //+ Convert.ToInt32(textBox2.Text)).ToString();
            var process = new Process();

            process.StartInfo.FileName = @"C:\Users\raek0\OneDrive\Документы\GitHub\System-software\Lr2\App2\bin\Release\net6.0\App2.exe";
            process.StartInfo.Arguments = $"{textBox1.Text}{textBox2.Text}";
            process.Start();


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
