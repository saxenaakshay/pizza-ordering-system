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
    public partial class editpizza : Form
    {
        OracleConnection conn;
        public editpizza()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            connect1();
            OracleCommand cm = new OracleCommand();
            comboBox3.Items.Clear();
            cm.CommandText = "select * from pizzas;";
            cm.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cm.CommandText, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "pizzas");
            DataTable dt2 = ds.Tables["pizzas"];
            DataRow dr2;
            int tr = dt2.Rows.Count;
            for (int i = 0; i < tr; i++)
            {
                dr2 = dt2.Rows[i];
                String str = dr2["pizza_type"].ToString();
                if (str == comboBox1.Text)
                {
                    comboBox3.Items.Add(dr2["pizza_name"].ToString());
                }
            }
        }
        public void connect1()
        {

            string oradb = "Data Source=AKSHAY; User ID=system; Password=welcome;  ";
            conn = new OracleConnection(oradb);
            conn.Open();
        }
        int pno;

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                connect1();
               /*OracleCommand cm4 = new OracleCommand();
                cm4.CommandText = "select count(*) I from pizzas;";
                cm4.CommandType = CommandType.Text;
                OracleDataAdapter da4 = new OracleDataAdapter(cm4.CommandText, conn);
                DataSet ds4 = new DataSet();
                da4.Fill(ds4, "order_cos");
                DataTable dt4 = ds4.Tables["order_cos"];
                int i = 0;
                DataRow dr4 = dt4.Rows[i];
                pno = int.Parse(dr4["I"].ToString());
                pno++;
                */
                Random rand = new Random();
                int pn = rand.Next(1000, 9999);
                label17.Text = pn.ToString();

                OracleCommand cm = new OracleCommand("add_pizza", conn);
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add("pno", OracleDbType.Int32).Value = label17.Text;
                cm.Parameters.Add("ptype", OracleDbType.Varchar2, 20).Value = comboBox2.Text;
                cm.Parameters.Add("pname", OracleDbType.Varchar2, 20).Value = textBox1.Text;
                cm.Parameters.Add("prireg", OracleDbType.Int32).Value = textBox2.Text;
                cm.Parameters.Add("primed", OracleDbType.Int32).Value = textBox3.Text;
                cm.Parameters.Add("prilar", OracleDbType.Int32).Value = textBox4.Text;

                int r = cm.ExecuteNonQuery();
                if (r < 0)
                    MessageBox.Show("INSERTED");
                else
                    MessageBox.Show("NOT INSERTED");

                comboBox3.Text = "";
                comboBox4.Text = "";
                
                

            }
            else
                MessageBox.Show("ALL FIELDS MANDATORY");



        }

        private void editpizza_Load(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox3.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
            {
                connect1();
                OracleCommand cm = new OracleCommand();

                cm.CommandText = "select * from pizzas;";
                cm.CommandType = CommandType.Text;
                OracleDataAdapter da = new OracleDataAdapter(cm.CommandText, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "pizzas");
                DataTable dt2 = ds.Tables["pizzas"];
                DataRow dr2;
                int tr = dt2.Rows.Count;
                for (int i = 0; i < tr; i++)
                {
                    dr2 = dt2.Rows[i];
                    String str = dr2["pizza_name"].ToString();
                    if (str == comboBox3.Text)
                        label18.Text = dr2["pizza_no"].ToString();
                }

                OracleCommand cm2 = new OracleCommand("mod_pizza", conn);
                cm2.CommandType = CommandType.StoredProcedure;
                cm2.Parameters.Add("pno", OracleDbType.Int32).Value = label18.Text;
                cm2.Parameters.Add("prireg", OracleDbType.Int32).Value = textBox6.Text;
                cm2.Parameters.Add("primed", OracleDbType.Int32).Value = textBox7.Text;
                cm2.Parameters.Add("prilar", OracleDbType.Int32).Value = textBox8.Text;

                int r = cm2.ExecuteNonQuery();
                if (r < 0)
                    MessageBox.Show("UPDATED");
                else
                    MessageBox.Show("NOT UPDATED");


                comboBox3.Text = "";
                comboBox4.Text = "";
               
            }
            else
                MessageBox.Show("ALL FIELDS MANDATORY");






        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            connect1();
            OracleCommand cm = new OracleCommand();
            comboBox3.Items.Clear();
            cm.CommandText = "select * from pizzas;";
            cm.CommandType = CommandType.Text;
            OracleDataAdapter da = new OracleDataAdapter(cm.CommandText, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "pizzas");
            DataTable dt2 = ds.Tables["pizzas"];
            DataRow dr2;
            int tr = dt2.Rows.Count;
            for (int i = 0; i < tr; i++)
            {
                dr2 = dt2.Rows[i];
                String str = dr2["pizza_type"].ToString();
                if (str == comboBox6.Text)
                {
                    comboBox4.Items.Add(dr2["pizza_name"].ToString());
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox6.Text != "" && comboBox4.Text != "")
            {
                OracleCommand cm2 = new OracleCommand("del_pizza", conn);
                cm2.CommandType = CommandType.StoredProcedure;
                cm2.Parameters.Add("pname", OracleDbType.Varchar2, 20).Value = comboBox4.Text;
                int r = cm2.ExecuteNonQuery();
                if (r < 0)
                    MessageBox.Show("DELETED");
                else
                    MessageBox.Show("NOT DELETED");


                comboBox3.Text = "";
                comboBox4.Text = "";
                
            }
            else
                MessageBox.Show("ALL FIELDS MANDATORY");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
