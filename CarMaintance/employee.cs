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
    public partial class employee : Form
    {
        static String databasePath = Path.Combine(Directory.GetCurrentDirectory(), "formDB.accdb");
        static string Sql2007 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + databasePath + ";Jet OLEDB:Database Password='';Persist Security Info=True;";
        OleDbConnection con2007 = new OleDbConnection(Sql2007);
        public employee()
        {
            InitializeComponent();
        }
        public DataTable consl2007()
        {
            con2007.Open();
            DataTable dt = new DataTable();
            string query = "SELECT * FROM employee";
            OleDbCommand cmd = new OleDbCommand(query, con2007);
            OleDbDataAdapter dp = new OleDbDataAdapter(cmd);
            dp.Fill(dt);
            con2007.Close();
            return dt;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            addEmployee addemployeeform = new addEmployee();
            addemployeeform.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateEmployee updateemployeeform = new updateEmployee();
            updateemployeeform.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (signup.countA == 0)
            {
                MessageBox.Show("غير متاح للمستخدمين");
            }
            else
            {
                deleteEmployee deleteemployeeform = new deleteEmployee();
                deleteemployeeform.ShowDialog();
            }
        }

        private void employee_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = consl2007();
            dataGridView1.Columns[0].HeaderText = "رقم الموظف";
            dataGridView1.Columns[1].HeaderText = "اسم الموظف";
            dataGridView1.Columns[2].HeaderText = "اسم الاختصاص";
            dataGridView1.Columns[3].HeaderText = "رقم الهاتف";
            dataGridView1.Columns[4].HeaderText = "تاريخ التسجيل";
            dataGridView1.Columns[5].HeaderText = "صورة";

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                con2007.Open();
                string query = "SELECT photoEmployee FROM employee WHERE IDEmployee =@IDEmployee ";
                OleDbCommand cmd = new OleDbCommand(query, con2007);
                cmd.Parameters.AddWithValue("@IDEmployee", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                OleDbDataReader myreader = cmd.ExecuteReader();
                if (myreader.Read())
                {
                    byte[] imageD = (byte[])myreader["photoEmployee"];
                    Image image;
                    MemoryStream ms = new MemoryStream(imageD);
                    image = Image.FromStream(ms);
                    pictureBox1.Image = image;
                }
                con2007.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("لقد حدث خطا");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("EmployeeName like '%" + text_search.Text + "%'");
        }
    }
}
