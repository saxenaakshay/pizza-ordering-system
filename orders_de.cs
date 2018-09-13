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
    public partial class orders_de : Form
    {
        public orders_de()
        {
            InitializeComponent();
            ret1();
            ret();
        }
        OracleConnection conn;
        OracleCommand cm = new OracleCommand();

        private void orders_de_Load(object sender, EventArgs e)
        {

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
            cm.CommandText = "select * from order_cos;";
            cm.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cm.CommandText, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "order_cus");
            DataTable dt = ds.Tables["order_cus"];
            dataGridView1.DataSource = dt;
        }
        public void ret1()
        {
            connect1();
            cm.CommandText = "select * from order_det;";
            cm.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cm.CommandText, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "order_det");
            DataTable dt = ds.Tables["order_det"];
            dataGridView2.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
