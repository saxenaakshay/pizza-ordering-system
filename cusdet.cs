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
    public partial class cusdet : Form
    {
        OracleConnection conn;
        DataRow d;
        public cusdet(DataRow c)
        {
            d = c;
            InitializeComponent();
            ret();
        }
        OracleCommand cm = new OracleCommand();
        public void connect1()
        {

            string oradb = "Data Source=AKSHAY; User ID=system; Password=welcome;  ";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        private void cusdet_Load(object sender, EventArgs e)
        {
        }
        public void ret()
        {

            connect1();
           
            cm.CommandText = "select * from order_det;";
            cm.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cm.CommandText, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "order_det");
            DataTable dt = ds.Tables["order_det"];
            DataRow dr;

            connect1();
            OracleCommand cm2 = new OracleCommand();

            cm2.CommandText = "select * from pizzas;";
            cm2.CommandType = CommandType.Text;
            OracleDataAdapter da2 = new OracleDataAdapter(cm2.CommandText, conn);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2, "pizzas");
            DataTable dt2 = ds2.Tables["pizzas"];
            DataRow dr2;


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                if (dr["cus_code"].ToString() == d["cus_code"].ToString())
                {

                    label1.Text += dr["order_no"].ToString() + "\n";
                    label3.Text += dr["psize"].ToString() + "\n";
                    label4.Text += dr["quantity"].ToString() + "\n";
                    string g = dr["pizza_no"].ToString();
                    int tr = dt2.Rows.Count;
                    for (int j = 0; j < tr; j++)
                    {
                        dr2 = dt2.Rows[j];
                        if (g == dr2["pizza_no"].ToString())
                        {
                            label2.Text += dr2["pizza_name"].ToString() + "\n";
                        }
                    }
                        

                }
            }
           
            
            
          //  cm.ExecuteNonQuery();
           // cm2.ExecuteNonQuery();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
