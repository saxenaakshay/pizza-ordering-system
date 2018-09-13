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
    public partial class Form1_DESK : Form
    {
        
        public Form1_DESK()
        {
            
            InitializeComponent();
            
        }

        private void Form1_DESK_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            desk_cdetails cr = new desk_cdetails();
            cr.Show();
            this.Hide();
                
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form3 m = new Form3(3);
            m.Show();
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            stores st = new stores();
            st.Show();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cuppons cup = new cuppons();
            cup.Show();
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            orders_de or = new orders_de();
            or.Show();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            editpizza ep = new editpizza();
            ep.Show();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            editcupp ec = new editcupp();
            ec.Show();

        }
    }
}
