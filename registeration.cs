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
    public partial class registeration : Form
    { OracleConnection conn;
        OracleCommand cm, cm2;
        
        public void connect1()
        {

            string oradb = "Data Source=AKSHAY; User ID=system; Password=welcome;  ";
            conn = new OracleConnection(oradb);
            conn.Open();
        }
        DataTable dt2;
        DataRow dr2;
        public void loc()
        {
            connect1();
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                dr2 = dt2.Rows[i];
                if (dr2["pin"].ToString() == comboBox1.Text)
                {
                    label10.Text = dr2["locality_name"].ToString();
                }
            }
        }

  
            

        public void ret()
        {
            connect1();
            cm2 = new OracleCommand();
            cm2.CommandText = "select * from area;";
            cm2.CommandType = CommandType.Text;
            OracleDataAdapter da2 = new OracleDataAdapter(cm2.CommandText, conn);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2, "area");
            dt2 = ds2.Tables["area"];
            
            comboBox1.DataSource = dt2;
            comboBox1.DisplayMember = "pin";
            
            
        }

        public void reg()
        {
            connect1();
            cm = new OracleCommand();
           
            cm.Connection = conn;
            cm.CommandText = "insert into customers values (:pa1, :pa2, :pa3, :pa4, :pa5, :pa6, :pa7, :pa8)";

            OracleParameter p1 = new OracleParameter();

            p1.DbType = DbType.String;
            p1.ParameterName = "pa1";
            p1.Value = label12.Text;

            OracleParameter p2 = new OracleParameter();
            p2.DbType = DbType.String;
            p2.ParameterName = "pa2";
            p2.Value = textBox1.Text;

            OracleParameter p3 = new OracleParameter();
            p3.DbType = DbType.String;
            p3.ParameterName = "pa3";
            p3.Value = textBox3.Text;

            OracleParameter p4 = new OracleParameter();
            p4.DbType = DbType.String;
            p4.ParameterName = "pa4";
            p4.Value = textBox4.Text;


            OracleParameter p5 = new OracleParameter();
            p5.DbType = DbType.String;
            p5.ParameterName = "pa5";
            p5.Value = textBox2.Text;

            OracleParameter p6 = new OracleParameter();
            p6.DbType = DbType.String;
            p6.ParameterName = "pa6";
            p6.Value = richTextBox1.Text;

            OracleParameter p7 = new OracleParameter();
            p7.DbType = DbType.String;
            p7.ParameterName = "pa7";
            p7.Value = label10.Text;

            OracleParameter p8 = new OracleParameter();
            p8.DbType = DbType.String;
            p8.ParameterName = "pa8";
            p8.Value = comboBox1.Text;

            cm.Parameters.Add(p1);
            cm.Parameters.Add(p2);
            cm.Parameters.Add(p3);
            cm.Parameters.Add(p4);
            cm.Parameters.Add(p5);
            cm.Parameters.Add(p6);
            cm.Parameters.Add(p7);
            cm.Parameters.Add(p8);


            cm.ExecuteNonQuery();
            MessageBox.Show("REGISTERED");
            conn.Close();
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        public registeration()
        {
            InitializeComponent();
            connect1();
            ret();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "CREATE")
            {
                reg();

            }
            if ( textBox1.Text == "" || textBox2.Text == "" ||textBox3.Text == "" ||textBox4.Text == "" || richTextBox1.Text == "")
            {MessageBox.Show ("FORM INCOMPLETE");
            }
            else 
            {
                Random random = new Random();
                int randomNumber = random.Next(1000, 10000);
                label12.Text = randomNumber.ToString();
                button1.Text = "CREATE";
            }
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 g = new Form1();
            g.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void registeration_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loc();
          
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
