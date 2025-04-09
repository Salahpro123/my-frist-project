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
    public partial class paytheresultofCustomerMoney : Form
    {
        static String databasePath = Path.Combine(Directory.GetCurrentDirectory(), "formDB.accdb");
        static string Sql2007 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + databasePath + ";Jet OLEDB:Database Password='';Persist Security Info=True;";
        OleDbConnection con2007 = new OleDbConnection(Sql2007);
        public paytheresultofCustomerMoney()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con2007.Open();
            string query = "SELECT IDCars FROM cars";
            OleDbDataAdapter dr = new OleDbDataAdapter(query, con2007);
            DataTable tp = new DataTable();
            dr.Fill(tp);
            comboBox1.ValueMember = "IDCars";
            comboBox1.DataSource = tp;
            con2007.Close();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (con2007.State == ConnectionState.Open)
            {
                con2007.Close();
            }
            else
            {
                con2007.Open();
                int selectedID = (int)comboBox1.SelectedValue;
                string query = "SELECT * FROM listpayment WHERE IDCars =@IDCars ";
                OleDbCommand cmd = new OleDbCommand(query, con2007);
                cmd.Parameters.AddWithValue("@IDCars", selectedID);
                OleDbDataReader myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    label_name_ownr.Text = myreader["CustomerName"].ToString();
                    txt_money_rest.Text = myreader["Expr1"].ToString();
                }
                con2007.Close();
            }
        }
        int addmoney = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            con2007.Open();
            string query = "UPDATE customerPayment SET CustomerMoney = CustomerMoney + @CustomerMoney WHERE IDCars = @IDCars";
            OleDbCommand cmd = new OleDbCommand(query, con2007);
            addmoney = Convert.ToInt32(text_paytherest.Text);
            cmd.Parameters.AddWithValue("@CustomerMoney", addmoney);
            cmd.Parameters.AddWithValue("@IDCars", comboBox1.Text);
            MessageBox.Show("تم التسديد");
            cmd.ExecuteNonQuery();
            string query1 = "SELECT customerPayment.CustomerMoney ,Expr1 FROM customerPayment , listpayment WHERE IDCars = @IDCars";
            OleDbCommand cmd1 = new OleDbCommand(query1, con2007);
            cmd1.Parameters.AddWithValue("@IDCars", comboBox1.Text);
            OleDbDataReader myreader = cmd1.ExecuteReader();
            while (myreader.Read())
            {
                txt_money_rest.Text = myreader["Expr1"].ToString();
            }
            myreader.Close();
            con2007.Close();
            foreach (Control c in panel2.Controls)
            {
                if (c is TextBox)
                {
                    if (c == text_paytherest)
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
    }
}
