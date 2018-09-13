using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            textBox3.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 F = new Form1();
            F.Show();
            this.Hide();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Show();

        }
    }
}
