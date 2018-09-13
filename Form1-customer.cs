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
    public partial class Form1_customer : Form
    {
        OracleConnection conn;
        DataRow cus;
        int orderno=0;
        int price=0;
        public Form1_customer(DataRow x)
        {
            cus = x;
            InitializeComponent();
            label7.Text = cus["cus_name"].ToString();
            label2.Text = cus["phno_single"].ToString();
            label3.Text = cus["address"].ToString() +"\n" + cus["locality"].ToString() + "\n" + cus["pin"].ToString();
            connect1();
            OracleCommand cm4 = new OracleCommand();
            cm4.CommandText = "select count(*) I from order_cos;";
            cm4.CommandType = CommandType.Text;
            OracleDataAdapter da4 = new OracleDataAdapter(cm4.CommandText, conn);
            DataSet ds4 = new DataSet();
            da4.Fill(ds4, "order_cos");
            DataTable dt4 = ds4.Tables["order_cos"];
            int i = 0;
            DataRow dr4 = dt4.Rows[i];
            orderno = int.Parse(dr4["I"].ToString());
            orderno++;
            

  //          Random rand = new Random();
   //         orderno = rand.Next(1000, 9999);
            
        }
        public void connect1()
        {

            string oradb = "Data Source=AKSHAY; User ID=system; Password=welcome;  ";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 menu = new Form3(2);
            menu.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_customer_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
          
            
            connect1();
            OracleCommand cm = new OracleCommand();
            cm.CommandText = "select * from pizzas;";
            cm.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cm.CommandText, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "pizzas");
            DataTable dt=ds.Tables["pizzas"];
            int tr = dt.Rows.Count;
            DataRow dr;
            for(int i=0;i<tr;i++)
            { dr=dt.Rows[i];
                String str=dr["pizza_type"].ToString();
                if(str=="simply veg")
                {comboBox1.Items.Add(dr["pizza_name"].ToString());
                }
            }
             
            //cm.ExecuteNonQuery();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            connect1();
            OracleCommand cm = new OracleCommand();
            cm.CommandText = "select * from pizzas;";
            cm.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cm.CommandText, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "pizzas");
            DataTable dt = ds.Tables["pizzas"];
            int tr = dt.Rows.Count;
            DataRow dr;
            for (int i = 0; i < tr; i++)
            {
                dr = dt.Rows[i];
                String str = dr["pizza_type"].ToString();
                if (str == "veg treat")
                {
                    comboBox1.Items.Add(dr["pizza_name"].ToString());
                }
            }
             
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            connect1();
            OracleCommand cm = new OracleCommand();
            cm.CommandText = "select * from pizzas;";
            cm.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cm.CommandText, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "pizzas");
            DataTable dt = ds.Tables["pizzas"];
            int tr = dt.Rows.Count;
            DataRow dr;
            for (int i = 0; i < tr; i++)
            {
                dr = dt.Rows[i];
                String str = dr["pizza_type"].ToString();
                if (str == "non veg treat")
                {
                    comboBox1.Items.Add(dr["pizza_name"].ToString());
                }
            }
             
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            connect1();
            OracleCommand cm = new OracleCommand();
            cm.CommandText = "select * from pizzas;";
            cm.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cm.CommandText, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "pizzas");
            DataTable dt = ds.Tables["pizzas"];
            int tr = dt.Rows.Count;
            DataRow dr;
            for (int i = 0; i < tr; i++)
            {
                dr = dt.Rows[i];
                String str = dr["pizza_type"].ToString();
                if (str == "feast pizzas")
                {
                    comboBox1.Items.Add(dr["pizza_name"].ToString());
                }
            }
             
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "")
            {
                MessageBox.Show("ORDER INCOMPLETE");
            }
            else
            {
                
                label12.Text = "ORDER NO: " + orderno.ToString();
                
                connect1();
                OracleCommand cm;
                cm = new OracleCommand();

                cm.Connection = conn;
                cm.CommandText = "insert into order_det values (:pa1, :pa2, :pa3, :pa4, :pa5)";

                OracleParameter p1 = new OracleParameter();
                orderno = Convert.ToInt32(orderno);
                p1.DbType = DbType.Int32;
                p1.ParameterName = "pa1";
                p1.Value = orderno;

                string pno = "1";
                comboBox1.Items.Clear();
                connect1();
                OracleCommand cm2 = new OracleCommand();
                cm2.CommandText = "select * from pizzas;";
                cm2.CommandType = CommandType.Text;
                OracleDataAdapter da = new OracleDataAdapter(cm2.CommandText, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "pizzas");
                DataTable dt = ds.Tables["pizzas"];
                int tr = dt.Rows.Count;
                DataRow dr;
                for (int i = 0; i < tr; i++)
               {
                dr = dt.Rows[i];
                if (comboBox1.Text == dr["pizza_name"].ToString())
                pno = dr["pizza_no"].ToString();
                
                }

                int p = Convert.ToInt32(pno);

                OracleParameter p2 = new OracleParameter();
                p2.DbType = DbType.Int32;
                p2.ParameterName = "pa2";
                p2.Value = p;

                string cus_c = cus["cus_code"].ToString();
                int cusg = Convert.ToInt32(cus_c);
                OracleParameter p3 = new OracleParameter();
                p3.DbType = DbType.Int32;
                p3.ParameterName = "pa3";
                p3.Value = cusg;

                OracleParameter p4 = new OracleParameter();
                p4.DbType = DbType.String;
                p4.ParameterName = "pa4";
                p4.Value = comboBox2.Text;

                int q = Convert.ToInt32(comboBox3.Text);
                OracleParameter p5 = new OracleParameter();
                p5.DbType = DbType.Int32;
                p5.ParameterName = "pa5";
                p5.Value = q;

                cm.Parameters.Add(p1);
                cm.Parameters.Add(p2);
                cm.Parameters.Add(p3);
                cm.Parameters.Add(p4);
                cm.Parameters.Add(p5);

                cm.ExecuteNonQuery();
               


                string pri="0";
                OracleCommand cm3 = new OracleCommand();
                cm3.CommandText = "select * from prices;";// where pizza_no ='"+p+"';";
                cm3.CommandType = CommandType.Text;
                OracleDataAdapter da1 = new OracleDataAdapter(cm3.CommandText, conn);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "prices");
                DataTable dt1;
                dt1 = ds1.Tables["prices"];
                for (int x = 0; x < dt1.Rows.Count; x++)
                {
                    DataRow dr1;
                    dr1 = dt1.Rows[x];
                    if (dr1["pizza_no"].ToString() == pno)
                    {
                        if (comboBox2.Text == "Regular")
                            pri = dr1["price_reg"].ToString();
                        if (comboBox2.Text == "Medium")
                            pri = dr1["price_med"].ToString();
                        if (comboBox2.Text == "Large")
                            pri = dr1["price_lar"].ToString();

                    }

                }
                int disc=0;
                string di;
                connect1();
                cm3.CommandText = "select * from cuppons;";
                cm3.CommandType = CommandType.Text;
                OracleDataAdapter da2= new OracleDataAdapter(cm3.CommandText, conn);

                da2.Fill(ds1, "cuppons");
                dt1 = ds1.Tables["cuppons"];
                for (int ge = 0; ge < dt1.Rows.Count; ge++)
                {
                    DataRow dr1;
                    dr1 = dt1.Rows[ge];
                    if (dr1["cup_code"].ToString() == textBox1.Text)
                    {
                        di = dr1["disc"].ToString();
                        disc = Convert.ToInt32(di);
                    }
                }
                int g = Convert.ToInt32(pri);
                double de = g * 0.01 * disc ;
                int d = Convert.ToInt32(de);

                g *= q;
                g -= d;

                price += g;
                label13.Text = "TOTAL AMOUNT: " + price.ToString();
                label17.Text += "  " + comboBox1.Text + "(" + comboBox3.Text + ") \n" ;
                label18.Text += comboBox2.Text + "\n";
                label20.Text += g.ToString() + "\n";
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                textBox1.Text = "";

                if (d == 0)
                MessageBox.Show("ORDER PLACED");
                else
                MessageBox.Show("ORDER PLACED! CUPPON APPLIED!");


               
            
            
            
            }



        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (label17.Text == "")
                MessageBox.Show("SELECT ORDER FIRST");

            else
            {
               
                DateTime CurrentDate;
                CurrentDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy"));
                connect1();
                OracleCommand cm;
                cm = new OracleCommand();

                cm.Connection = conn;
                cm.CommandText = "insert into order_cos values (:pa1, :pa2, :pa3)";

                OracleParameter p1 = new OracleParameter();
                orderno = Convert.ToInt32(orderno);
                p1.DbType = DbType.Int32;
                p1.ParameterName = "pa1";
                p1.Value = orderno;

                OracleParameter p2 = new OracleParameter();
                p2.DbType = DbType.Date;
                p2.ParameterName = "pa2";
                p2.Value = CurrentDate;

                OracleParameter p3 = new OracleParameter();
                p3.DbType = DbType.Int32;
                p3.ParameterName = "pa3";
                p3.Value = price;

                cm.Parameters.Add(p1);
                cm.Parameters.Add(p2);
                cm.Parameters.Add(p3);

                cm.ExecuteNonQuery();
                MessageBox.Show("THANKS, ORDER PLACED!");
                Form1 F = new Form1();
                F.Show();
                this.Hide();
                //   bill b = new bill();
                //    b.Show();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cusdet c = new cusdet(cus);
            c.Show();
        }




        }
    }

