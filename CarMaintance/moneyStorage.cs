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
    public partial class moneyStorage : Form
    {
        static String databasePath = Path.Combine(Directory.GetCurrentDirectory(), "formDB.accdb");
        static string Sql2007 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + databasePath + ";Jet OLEDB:Database Password='';Persist Security Info=True;";
        OleDbConnection con2007 = new OleDbConnection(Sql2007);
        public moneyStorage()
        {
            InitializeComponent();
        }
        int addmoney = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            con2007.Open();
            string query = "UPDATE moneys SET Amont = Amont + @Amont";
            OleDbCommand cmd = new OleDbCommand(query, con2007);
            addmoney = Convert.ToInt32(txt_addmoney.Text);
            cmd.Parameters.AddWithValue("@Amont", addmoney);
            MessageBox.Show("تم الاضافة للرصيد");
            cmd.ExecuteNonQuery();
            string query1 = "SELECT Amont FROM moneys";
            OleDbCommand cmd1 = new OleDbCommand(query1, con2007);
            OleDbDataReader myreader = cmd1.ExecuteReader();
            while (myreader.Read())
            {
                txt_moneystore.Text = myreader["Amont"].ToString();
            }
            myreader.Close();
            con2007.Close();
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    if (c == txt_addmoney)
                    {
                        c.Text = "";
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con2007.Open();
            string query = "SELECT Amont FROM moneys";
            OleDbCommand cmd = new OleDbCommand(query, con2007);
            OleDbDataReader myreader = cmd.ExecuteReader();
            while (myreader.Read())
            {
                txt_moneystore.Text = myreader["Amont"].ToString();
            }
            myreader.Close();
            con2007.Close();
        }
    }
}
