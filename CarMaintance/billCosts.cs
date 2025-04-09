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
    public partial class billCosts : Form
    {
        static String databasePath = Path.Combine(Directory.GetCurrentDirectory(), "formDB.accdb");
        static string Sql2007 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + databasePath + ";Jet OLEDB:Database Password='';Persist Security Info=True;";
        OleDbConnection con2007 = new OleDbConnection(Sql2007);
        public billCosts()
        {
            InitializeComponent();
        }
        public DataTable consl20078()
        {
            con2007.Open();
            DataTable dt = new DataTable();
            string query = "SELECT * FROM listpayment";
            OleDbCommand cmd = new OleDbCommand(query, con2007);
            OleDbDataAdapter dp = new OleDbDataAdapter(cmd);
            dp.Fill(dt);
            con2007.Close();
            return dt;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = consl20078();
            dataGridView1.Columns[0].HeaderText = "رقم الفاتورة";
            dataGridView1.Columns[1].HeaderText = "اسم السيارة";
            dataGridView1.Columns[2].HeaderText = "اسم العميل";
            dataGridView1.Columns[3].HeaderText = "اسم الخدمة";
            dataGridView1.Columns[4].HeaderText = "تكلفة الخدمة";
            dataGridView1.Columns[5].HeaderText = "اسم القطعة";
            dataGridView1.Columns[6].HeaderText = "تكلفة القطعة";
            dataGridView1.Columns[7].HeaderText = "التكلفة كاملة";
            dataGridView1.Columns[8].HeaderText = "المبلغ المدفوع";
            dataGridView1.Columns[9].HeaderText = "الباقي";
            dataGridView1.Columns[10].HeaderText = "التاريخ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            paytheresultofCustomerMoney paytheresultofCustomerMoney_form = new paytheresultofCustomerMoney();
            paytheresultofCustomerMoney_form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con2007.Open();
            DateTime dttime1 = DateTime.Parse(dateTimePicker1.Text);
            DateTime dttime2 = DateTime.Parse(dateTimePicker2.Text);
            string query = "SELECT * FROM listpayment WHERE datetimer between #" + dttime1.ToString("MM/dd/yyyy") + "# and #" + dttime2.ToString("MM/dd/yyyy") + "# order by datetimer desc";
            OleDbCommand cmd = new OleDbCommand(query, con2007);
            OleDbDataAdapter dp = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            dp.Fill(dt);
            dataGridView1.DataSource = dt;
            con2007.Close();
            dataGridView1.Columns[0].HeaderText = "رقم الفاتورة";
            dataGridView1.Columns[1].HeaderText = "اسم السيارة";
            dataGridView1.Columns[2].HeaderText = "اسم العميل";
            dataGridView1.Columns[3].HeaderText = "اسم الخدمة";
            dataGridView1.Columns[4].HeaderText = "تكلفة الخدمة";
            dataGridView1.Columns[5].HeaderText = "اسم القطعة";
            dataGridView1.Columns[6].HeaderText = "تكلفة القطعة";
            dataGridView1.Columns[7].HeaderText = "التكلفة كاملة";
            dataGridView1.Columns[8].HeaderText = "المبلغ المدفوع";
            dataGridView1.Columns[9].HeaderText = "الباقي";
            dataGridView1.Columns[10].HeaderText = "التاريخ";

        }
    }
}
