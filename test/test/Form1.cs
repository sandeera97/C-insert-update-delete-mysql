using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace test
{
    public partial class Form1 : Form
    {
        //MySqlConnection conn = DbConnection.getCon();
        MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "insert into posdb.tbl(name,school,age,city) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "');";
                MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader2;
                conn.Open();
                MyReader2 = MyCommand2.ExecuteReader(); 
                MessageBox.Show("Save Data");
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            disdata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {  
                string Query = "update posdb.tbl set school='" + textBox2.Text + "',age='" + textBox3.Text + "',city='" + textBox4.Text + "' where name='" + textBox1.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader2;
                conn.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Data Updated");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            disdata();
        }

        private void button4_Click(object sender, EventArgs e)
        {
                try
                {
                    string Query = "delete from posdb.tbl where name='" + textBox1.Text + "';";
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                    MySqlDataReader MyReader2;
                    conn.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    MessageBox.Show("Data Deleted");
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                disdata();
        }

        private void disdata()
        {
            try
            {
                
                //Display query  
                string Query = "select * from posdb.tbl;";
                MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }  


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            disdata();
        }

    }
}
