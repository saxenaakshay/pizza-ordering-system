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
    public partial class desk_cdetails : Form
    {
        OracleConnection conn;
        OracleCommand cm = new OracleCommand();
        public desk_cdetails()
        {
            InitializeComponent();
            ret();
        }
        
        public void connect1()
        {
            string oradb = "Data Source=AKSHAY; User ID=system; Password=;  ";
            conn = new OracleConnection(oradb);
            conn.Open();
        }
        public void ret()
        {
            connect1();
            cm.CommandText = "select * from customers;";
            cm.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cm.CommandText, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "customers");
            DataTable dt = ds.Tables["customers"];
            dataGridView1.DataSource = dt;
        }

        private void desk_cdetails_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1_DESK f = new Form1_DESK();
            f.Show();
            this.Hide();
        }
    }
}
