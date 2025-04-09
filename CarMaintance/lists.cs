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
    public partial class lists : Form
    {
        static String databasePath = Path.Combine(Directory.GetCurrentDirectory(), "formDB.accdb");
        static string Sql2007 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + databasePath + ";Jet OLEDB:Database Password='';Persist Security Info=True;";
        OleDbConnection con2007 = new OleDbConnection(Sql2007);
        public lists()
        {
            InitializeComponent();
        }
        public DataTable consl2007()
        {
            con2007.Open();
            DataTable dt = new DataTable();
            string query = "SELECT * FROM tablesList";
            OleDbCommand cmd = new OleDbCommand(query, con2007);
            OleDbDataAdapter dp = new OleDbDataAdapter(cmd);
            dp.Fill(dt);
            con2007.Close();
            return dt;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            addList addlist_form = new addList();
            addlist_form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateList updatelist_form = new updateList();
            updatelist_form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (signup.countA == 0)
            {
                MessageBox.Show("غير متاح للمستخدمين");
            }
            else
            {
                deleteList deletelist_form = new deleteList();
                deletelist_form.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = consl2007();
            dataGridView1.Columns[0].HeaderText = "رقم السجل";
            dataGridView1.Columns[1].HeaderText = "اسم السيارة";
            dataGridView1.Columns[2].HeaderText = "موديل السيارة";
            dataGridView1.Columns[3].HeaderText = "اسم العميل";
            dataGridView1.Columns[4].HeaderText = "اسم الموظف";
            dataGridView1.Columns[5].HeaderText = "عمل الموظف";
            dataGridView1.Columns[6].HeaderText = "اسم المورد";
            dataGridView1.Columns[7].HeaderText = "اسم القطعة";
            dataGridView1.Columns[8].HeaderText = "اسم الخدمة";
            dataGridView1.Columns[9].HeaderText = "هاتف العميل";
            dataGridView1.Columns[10].HeaderText = "تاريخ الاصلاح";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (con2007.State == ConnectionState.Open)
            {
                con2007.Close();
            }
            else
            {
                try
                {
                    con2007.Open();
                    string query = "SELECT Reports FROM lists WHERE ListID =@ListID ";
                    OleDbCommand cmd = new OleDbCommand(query, con2007);
                    cmd.Parameters.AddWithValue("@ListID", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    OleDbDataReader myreader = cmd.ExecuteReader();
                    while (myreader.Read())
                    {
                        richTextBox1.Text = myreader["Reports"].ToString();
                    }
                    myreader.Close();
                    con2007.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("لقد حدث خطا");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (con2007.State == ConnectionState.Open)
            {
                con2007.Close();
            }
            else
            {
                con2007.Open();
                DateTime dttime1 = DateTime.Parse(dateTimePicker1.Text);
                DateTime dttime2 = DateTime.Parse(dateTimePicker2.Text);
                string query = "SELECT * FROM tablesList WHERE datetimer between #" + dttime1.ToString("MM/dd/yyyy") + "# and #" + dttime2.ToString("MM/dd/yyyy") + "# order by datetimer desc";
                OleDbCommand cmd = new OleDbCommand(query, con2007);
                OleDbDataAdapter dp = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                dp.Fill(dt);
                dataGridView1.DataSource = dt;
                con2007.Close();
            }
            dataGridView1.Columns[0].HeaderText = "رقم السجل";
            dataGridView1.Columns[1].HeaderText = "اسم السيارة";
            dataGridView1.Columns[2].HeaderText = "موديل السيارة";
            dataGridView1.Columns[3].HeaderText = "اسم العميل";
            dataGridView1.Columns[4].HeaderText = "اسم الموظف";
            dataGridView1.Columns[5].HeaderText = "عمل الموظف";
            dataGridView1.Columns[6].HeaderText = "اسم المورد";
            dataGridView1.Columns[7].HeaderText = "اسم القطعة";
            dataGridView1.Columns[8].HeaderText = "اسم الخدمة";
            dataGridView1.Columns[9].HeaderText = "هاتف العميل";
            dataGridView1.Columns[10].HeaderText = "تاريخ الاصلاح";
        }
    }
}
