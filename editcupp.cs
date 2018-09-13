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
    public partial class editcupp : Form
    {
        OracleConnection conn;
        public editcupp()
        {
            InitializeComponent();
            ret();
        }
        public void ret()
        {
            connect1();
            OracleCommand cm = new OracleCommand();
            comboBox1.Items.Clear();
            cm.CommandText = "select * from cuppons;";
            cm.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cm.CommandText, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "cuppons");
            DataTable dt2 = ds.Tables["cuppons"];
            DataRow dr2;
            int tr = dt2.Rows.Count;
            for (int i = 0; i < tr; i++)
            {
                dr2 = dt2.Rows[i];
                comboBox1.Items.Add(dr2["cup_code"].ToString());
                
            }
        }
        public void connect1()
        {

            string oradb = "Data Source=AKSHAY; User ID=system; Password=welcome;  ";
            conn = new OracleConnection(oradb);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {   connect1();
                OracleCommand cm = new OracleCommand("add_cupp", conn);
                cm.CommandType = CommandType.StoredProcedure;
              
                cm.Parameters.Add("code", OracleDbType.Varchar2, 20).Value = textBox1.Text;
                cm.Parameters.Add("disc", OracleDbType.Int32).Value = textBox2.Text;
                
                int r = cm.ExecuteNonQuery();
                if (r < 0)
                    MessageBox.Show("INSERTED");
                else
                    MessageBox.Show("NOT INSERTED");


            }
            else
                MessageBox.Show("ALL FIELDS MANDATORY");


            ret();
        
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" )
            {
                OracleCommand cm2 = new OracleCommand("del_cupp", conn);
                cm2.CommandType = CommandType.StoredProcedure;
                cm2.Parameters.Add("code", OracleDbType.Varchar2, 20).Value = comboBox1.Text;
                int r = cm2.ExecuteNonQuery();
                if (r < 0)
                    MessageBox.Show("DELETED");
                else
                    MessageBox.Show("NOT DELETED");

            
            }
            else
                MessageBox.Show("ALL FIELDS MANDATORY");

        }
    }
}
