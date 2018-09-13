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
    public partial class cuppons : Form
    {
        OracleConnection conn;
        OracleCommand cm = new OracleCommand();
        public cuppons()
        {
            InitializeComponent();
            ret();
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
             label3.Text = "";
             label4.Text = "";
             cm.CommandText = "select * from cuppons;";
             cm.CommandType = CommandType.Text;
             OracleDataAdapter da = new OracleDataAdapter(cm.CommandText, conn);
             DataSet ds = new DataSet();
             da.Fill(ds, "cuppons");
             DataTable dt = ds.Tables["cuppons"];
             DataRow dr;
             for (int i = 0; i < dt.Rows.Count; i++)
             {
                 dr = dt.Rows[i];
                 label3.Text += dr["disc"].ToString() + "\n";
                 label4.Text += dr["cup_code"].ToString() + "\n";
             }
         }
        private void cuppons_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
