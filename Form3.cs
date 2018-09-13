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
    public partial class Form3 : Form
    {
        OracleConnection conn;
        OracleCommand cm = new OracleCommand();
        OracleCommand cm2 = new OracleCommand();
        int i = 0;
        DataRow dr, dr2;
        int fno;
        public Form3(int z)
        {
            fno = z;
            connect1();
            InitializeComponent();
        }
        

        public void connect1()
        {
            string oradb = "Data Source=AKSHAY; User ID=system; Password=welcome;  ";
            conn = new OracleConnection(oradb);
            conn.Open();
        }
        public void ret(int a)
        {
            connect1();
            label11.Text = "";
            label12.Text = "";
            label13.Text = "";
            label14.Text = "";


            cm.CommandText = "select * from pizzas;";
            cm.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cm.CommandText, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "pizzas");
            DataTable dt = ds.Tables["pizzas"];


            cm2.CommandText = "select * from prices;";
            cm2.CommandType = CommandType.Text;
            OracleDataAdapter da2 = new OracleDataAdapter(cm2.CommandText, conn);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2, "prices");
            DataTable dt2 = ds2.Tables["prices"];

            if (a == 1)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    dr = dt.Rows[i];
                    if (dr["pizza_type"].ToString() == "simply veg")
                    {
                        label11.Text += dr["pizza_name"].ToString() + "\n";
                        string pnum = dr["pizza_no"].ToString();
                        for (int j = 0; j < dt2.Rows.Count; j++)
                        {
                            dr2 = dt2.Rows[j];
                            if (dr2["pizza_no"].ToString() == dr["pizza_no"].ToString())
                            {
                                label12.Text += dr2["price_reg"].ToString() + "\n";
                                label13.Text += dr2["price_med"].ToString() + "\n";
                                label14.Text += dr2["price_lar"].ToString() + "\n";


                            }
                        }


                    }


                }
            }

            else if (a == 2)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    dr = dt.Rows[i];
                    if (dr["pizza_type"].ToString() == "veg treat")
                    {
                        label11.Text += dr["pizza_name"].ToString() + "\n";
                        string pnum = dr["pizza_no"].ToString();
                        for (int j = 0; j < dt2.Rows.Count; j++)
                        {
                            dr2 = dt2.Rows[j];
                            if (dr2["pizza_no"].ToString() == dr["pizza_no"].ToString())
                            {
                                label12.Text += dr2["price_reg"].ToString() + "\n";
                                label13.Text += dr2["price_med"].ToString() + "\n";
                                label14.Text += dr2["price_lar"].ToString() + "\n";


                            }
                        }


                    }


                }
            }

            else if (a == 3)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    dr = dt.Rows[i];
                    if (dr["pizza_type"].ToString() == "non veg treat")
                    {
                        label11.Text += dr["pizza_name"].ToString() + "\n";
                        string pnum = dr["pizza_no"].ToString();
                        for (int j = 0; j < dt2.Rows.Count; j++)
                        {
                            dr2 = dt2.Rows[j];
                            if (dr2["pizza_no"].ToString() == dr["pizza_no"].ToString())
                            {
                                label12.Text += dr2["price_reg"].ToString() + "\n";
                                label13.Text += dr2["price_med"].ToString() + "\n";
                                label14.Text += dr2["price_lar"].ToString() + "\n";


                            }
                        }


                    }


                }
            }
            else if (a == 4)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    dr = dt.Rows[i];
                    if (dr["pizza_type"].ToString() == "feast pizzas")
                    {
                        label11.Text += dr["pizza_name"].ToString() + "\n";
                        string pnum = dr["pizza_no"].ToString();
                        for (int j = 0; j < dt2.Rows.Count; j++)
                        {
                            dr2 = dt2.Rows[j];
                            if (dr2["pizza_no"].ToString() == dr["pizza_no"].ToString())
                            {
                                label12.Text += dr2["price_reg"].ToString() + "\n";
                                label13.Text += dr2["price_med"].ToString() + "\n";
                                label14.Text += dr2["price_lar"].ToString() + "\n";


                            }
                        }


                    }


                }
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*if (fno == 1)
            {
                Form1 F = new Form1();
                F.Show();
            }
            else if (fno == 2)
            {
                Form1_customer d = new Form1_customer();
                d.Show();
            }
             
            else if (fno == 3)
            {
                Form1_DESK c = new Form1_DESK();
                c.Show();
            }
            
            */
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            ret(1);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void label8_Click(object sender, EventArgs e)
        {
            ret(2);
        }

        private void label9_Click(object sender, EventArgs e)
        {
            ret(3);

        }

        private void label10_Click(object sender, EventArgs e)
        {
            ret(4);
        }
    }
}
