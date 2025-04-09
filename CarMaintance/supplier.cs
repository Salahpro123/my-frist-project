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
    public partial class supplier : Form
    {
        static String databasePath = Path.Combine(Directory.GetCurrentDirectory(), "formDB.accdb");
        static string Sql2007 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + databasePath + ";Jet OLEDB:Database Password='';Persist Security Info=True;";
        OleDbConnection con2007 = new OleDbConnection(Sql2007);
        public supplier()
        {
            InitializeComponent();
        }
        public DataTable consl2007()
        {
            con2007.Open();
            DataTable dt = new DataTable();
            string query = "SELECT * FROM suppliers";
            OleDbCommand cmd = new OleDbCommand(query, con2007);
            OleDbDataAdapter dp = new OleDbDataAdapter(cmd);
            dp.Fill(dt);
            con2007.Close();
            return dt;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            addSupplier addsupplier_form = new addSupplier();
            addsupplier_form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateSupplier updatesupplier_form = new updateSupplier();
            updatesupplier_form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (signup.countA == 0)
            {
                MessageBox.Show("غير متاح للمستخدمين");
            }
            else
            {
                deleteSupplier deletesupplier_form = new deleteSupplier();
                deletesupplier_form.ShowDialog();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("SupplierName like '%" + text_search.Text + "%'");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = consl2007();
            dataGridView1.Columns[0].HeaderText = "رقم المورد";
            dataGridView1.Columns[1].HeaderText = "اسم المورد";
            dataGridView1.Columns[2].HeaderText = "رقم الهاتف";
            dataGridView1.Columns[3].HeaderText = "العنوان";
            dataGridView1.Columns[4].HeaderText = "تاريخ الاضافة";
        }

        private void supplier_Load(object sender, EventArgs e)
        {

        }
    }
}
