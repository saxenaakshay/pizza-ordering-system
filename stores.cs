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
    public partial class stores : Form
    {
        OracleConnection conn;
        OracleCommand cm = new OracleCommand();
        OracleCommand cm2 = new OracleCommand();
        int i = 0;
        DataRow dr, dr2;
        public stores()
        {
            connect1();
            InitializeComponent();
        }

        public void connect1()
        {
            string oradb = "Data Source=AKSHAY; User ID=system; Password=welcome;  ";
            conn = new OracleConnection(oradb);
            conn.Open();
        }
        public void ret()
        {
            connect1();
            cm.CommandText = "select * from stores;";
            cm.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cm.CommandText, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "stores");
            DataTable dt = ds.Tables["stores"];


            cm2.CommandText = "select * from area;";
            cm2.CommandType = CommandType.Text;
            OracleDataAdapter da2 = new OracleDataAdapter(cm2.CommandText, conn);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2, "area");
            DataTable dt2 = ds2.Tables["area"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                label5.Text += dr["store_name"].ToString() + "\n";
                label11.Text += dr["store_no"].ToString() + "\n";
                label7.Text += dr["pin"].ToString() + "\n";
                
                for (int j = 0; j < dt2.Rows.Count; j++)
                {
                    dr2 = dt2.Rows[j];
                    if (dr2["pin"].ToString() == dr["pin"].ToString() )
                    {
                        label6.Text += dr2["locality_name"].ToString() + "\n";
                        
                    }

                }
                    
            }
        }



        private void stores_Load(object sender, EventArgs e)
        {
            ret();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
