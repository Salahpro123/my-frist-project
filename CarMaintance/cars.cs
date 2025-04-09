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
    public partial class cars : Form
    {
        static String databasePath = Path.Combine(Directory.GetCurrentDirectory(), "formDB.accdb");
        static string Sql2007 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + databasePath + ";Jet OLEDB:Database Password='';Persist Security Info=True;";
        OleDbConnection con2007 = new OleDbConnection(Sql2007);
        public cars()
        {
            InitializeComponent();
        }
        public DataTable consl2007()
        {
            con2007.Open();
            DataTable dt = new DataTable();
            string query = "SELECT * FROM cars";
            OleDbCommand cmd = new OleDbCommand(query, con2007);
            OleDbDataAdapter dp = new OleDbDataAdapter(cmd);
            dp.Fill(dt);
            con2007.Close();
            return dt;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            addcars addcars_form = new addcars();
            addcars_form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateCars updatecars_form = new updateCars();
            updatecars_form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (signup.countA == 0)
            {
                MessageBox.Show("غير متاح للمستخدمين");
            }
            else
            {
                deleteCars deletecars_form = new deleteCars();
                deletecars_form.ShowDialog();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("CarName like '%" + text_search.Text + "%'");
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                con2007.Open();
                string query = "SELECT CarReport FROM cars WHERE IDCars =@IDCars ";
                string query1 = "SELECT CarPhoto FROM cars WHERE IDCars =@IDCars ";
                OleDbCommand cmd1 = new OleDbCommand(query1, con2007);
                cmd1.Parameters.AddWithValue("@IDCars", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                OleDbDataReader reader1 = cmd1.ExecuteReader();
                if (reader1.Read())
                {
                    byte[] imageD = (byte[])reader1["CarPhoto"];
                    Image image;
                    MemoryStream ms = new MemoryStream(imageD);
                    image = Image.FromStream(ms);
                    pictureBox1.Image = image;
                }
                OleDbCommand cmd = new OleDbCommand(query, con2007);
                cmd.Parameters.AddWithValue("@IDCars", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                OleDbDataReader myreader = cmd.ExecuteReader();
                if (myreader.Read())
                {
                    richTextBox1.Text = myreader["CarReport"].ToString();
                }
                myreader.Close();
                reader1.Close();
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
            dataGridView1.Columns[0].HeaderText = "رقم السيارة";
            dataGridView1.Columns[1].HeaderText = "اسم السيارة";
            dataGridView1.Columns[2].HeaderText = "اسم الموديل";
            dataGridView1.Columns[3].HeaderText = "رقم المالك";
            dataGridView1.Columns[4].HeaderText = "رقم المحرك";
            dataGridView1.Columns[5].HeaderText = "ملاحظات";
            dataGridView1.Columns[6].HeaderText = "صورة";
            dataGridView1.Columns[7].HeaderText = "تاريخ الوصول للمركز";

        }

        private void cars_Load(object sender, EventArgs e)
        {

        }
    }
}
