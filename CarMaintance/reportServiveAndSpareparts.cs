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
    public partial class reportServiveAndSpareparts : Form
    {
        static String databasePath = Path.Combine(Directory.GetCurrentDirectory(), "formDB.accdb");
        static string Sql2007 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + databasePath + ";Jet OLEDB:Database Password='';Persist Security Info=True;";
        OleDbConnection con2007 = new OleDbConnection(Sql2007);
        public reportServiveAndSpareparts()
        {
            InitializeComponent();
        }
        public DataTable consl20010()
        {
            con2007.Open();
            DataTable dt = new DataTable();
            string query = "SELECT * FROM service_parts";
            OleDbCommand cmd = new OleDbCommand(query, con2007);
            OleDbDataAdapter dp = new OleDbDataAdapter(cmd);
            dp.Fill(dt);
            con2007.Close();
            return dt;
        }
        public DataTable consl2009()
        {
            con2007.Open();
            DataTable dt = new DataTable();
            string query = "SELECT * FROM service_pay";
            OleDbCommand cmd = new OleDbCommand(query, con2007);
            OleDbDataAdapter dp = new OleDbDataAdapter(cmd);
            dp.Fill(dt);
            con2007.Close();
            return dt;
        }
        public DataTable consl2008()
        {
            con2007.Open();
            DataTable dt = new DataTable();
            string query = "SELECT * FROM spearparts_pay";
            OleDbCommand cmd = new OleDbCommand(query, con2007);
            OleDbDataAdapter dp = new OleDbDataAdapter(cmd);
            dp.Fill(dt);
            con2007.Close();
            return dt;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            panel_2.BringToFront();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            panel_3.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel_3.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel_1.BringToFront();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel_1.BringToFront();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel_2.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = consl20010();
            dataGridView1.Columns[0].HeaderText = "اسم القطعة";
            dataGridView1.Columns[1].HeaderText = "مرات بيعها مع الخدمة";
            dataGridView1.Columns[2].HeaderText = "اسم الخدمة";
            dataGridView1.Columns[3].HeaderText = "مرات استخدامها مع القطعة";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = consl2009();
            dataGridView2.Columns[0].HeaderText = "اسم الخدمة";
            dataGridView2.Columns[1].HeaderText = "مرات استخدامها";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = consl2008();
            dataGridView3.Columns[0].HeaderText = "اسم القطعة";
            dataGridView3.Columns[1].HeaderText = "مرات بيعها";
        }
    }
}
