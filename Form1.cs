using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label5.Text = DateTime.Now.ToShortTimeString();
            connect1();
        }

        OracleConnection conn;

        public void connect1()
        {
            string oradb = "Data Source=AKSHAY; User ID=system; Password=welcome;  ";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        public void login(int z)
        {
            connect1();
            OracleCommand cm = new OracleCommand();
            string us, pw;
            us = textBox1.Text;
            pw = textBox2.Text;
            cm.Connection = conn;
            cm.CommandText = "select * from customers";
            cm.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cm.CommandText, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "customers");
            DataTable dt = ds.Tables["customers"];
            // int tr = dt.Rows.Count;
            DataRow dr;
            int i = 0, flag = 0;
            while (i < dt.Rows.Count)
            {
                dr = dt.Rows[i];
                if (us == dr["usn"].ToString())
                {
                    flag = 1;
                    if (pw == dr["pwd"].ToString())
                    {
                        MessageBox.Show("WELCOME " + dr["cus_name"].ToString());
                        Form1_customer fc = new Form1_customer(dr);
                        fc.Show();
                        this.Hide();

                    }
                    else
                        MessageBox.Show("WRONG PASSWORD");
                }
                i++;
            }
            if (flag == 0)
                MessageBox.Show("USERNAME NOT FOUND");

        }
        public void login2 ()
        {
            connect1();
            OracleCommand cm = new OracleCommand();
            string us, pw;
            us = textBox1.Text;
            pw = textBox2.Text;
            cm.Connection = conn;
            cm.CommandText = "select * from desk";
            cm.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cm.CommandText, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "desk");
            DataTable dt = ds.Tables["desk"];
            // int tr = dt.Rows.Count;
            DataRow dr;
            int i = 0, flag = 0;
            while (i < dt.Rows.Count)
            {
                dr = dt.Rows[i];
                if (us == dr["usn"].ToString())
                {
                    flag = 1;
                    if (pw == dr["pwd"].ToString())
                    {
                        MessageBox.Show("WELCOME " + dr["name"].ToString());
                        string nam = dr["name"].ToString();
                            Form1_DESK f2 = new Form1_DESK();
                            f2.Show();
                            this.Hide();
                            break;
                        
                    }
                    else
                        MessageBox.Show("WRONG PASSWORD");
                }
                i++;
            }
            if (flag == 0)
                MessageBox.Show("USERNAME NOT FOUND");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 fnew = new Form2();
            fnew.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            registeration r = new registeration();
            r.Show();
            this.Hide();

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form3 m = new Form3(1);
            m.Show();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            registeration r = new registeration();
            r.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            stores s = new stores();
            s.Show();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            login(1);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.textBox2.PasswordChar = '*';
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            login2();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        
            
        
    }
}
