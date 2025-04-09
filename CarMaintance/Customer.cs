using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
namespace CarMaintance
{
    public partial class Customer : Form
    {
        static String databasePath = Path.Combine(Directory.GetCurrentDirectory(), "formDB.accdb");
        static string Sql2007 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + databasePath + ";Jet OLEDB:Database Password='';Persist Security Info=True;";
        OleDbConnection con2007 = new OleDbConnection(Sql2007);
        public Customer()
        {
            InitializeComponent();
        }
        public DataTable consl2007()
        {
            con2007.Open();
            DataTable dt = new DataTable();
            string query = "SELECT * FROM customer";
            OleDbCommand cmd = new OleDbCommand(query, con2007);
            OleDbDataAdapter dp = new OleDbDataAdapter(cmd);
            dp.Fill(dt);
            con2007.Close();
            return dt;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            addCustomer addcostomerform = new addCustomer();
            addcostomerform.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateCustomer updatecustomerform = new updateCustomer();
            updatecustomerform.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (signup.countA == 0)
            {
                MessageBox.Show("غير متاح للمستخدمين");
            }
            else
            {
                deleteCustomer deletecustomerform = new deleteCustomer();
                deletecustomerform.ShowDialog();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("CustomerName like '%" + text_search.Text + "%'");
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                con2007.Open();
                string query = "SELECT CustomerReport FROM customer WHERE IDCustomer =@IDCustomer ";
                OleDbCommand cmd = new OleDbCommand(query, con2007);
                cmd.Parameters.AddWithValue("@IDCustomer", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                OleDbDataReader myreader = cmd.ExecuteReader();
                if (myreader.Read())
                {
                    richTextBox1.Text = myreader["CustomerReport"].ToString();
                }
                con2007.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("لقد حدث خطا");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = consl2007();
            dataGridView1.Columns[0].HeaderText = "رقم العميل";
            dataGridView1.Columns[1].HeaderText = "اسم العميل";
            dataGridView1.Columns[2].HeaderText = "رقم الهاتف";
            dataGridView1.Columns[3].HeaderText = "العنوان";
            dataGridView1.Columns[4].HeaderText = "البريد الالكتروني";
            dataGridView1.Columns[5].HeaderText = "تاريخ المجيى";
            dataGridView1.Columns[6].HeaderText = "ملاحظات";

        }

        private void Customer_Load(object sender, EventArgs e)
        {

        }
    }
}
