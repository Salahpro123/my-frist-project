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
    public partial class updateCustomer : Form
    {
        static String databasePath = Path.Combine(Directory.GetCurrentDirectory(), "formDB.accdb");
        static string Sql2007 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + databasePath + ";Jet OLEDB:Database Password='';Persist Security Info=True;";
        OleDbConnection con2007 = new OleDbConnection(Sql2007);
        public updateCustomer()
        {
            InitializeComponent();
        }

        private void updateCustomer_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_addCustomer_number.Text.Trim() == "" || txt_addCustomer_name.Text.Trim() == "" || txt_addCustomer_phone.Text.Trim() == "" || txt_addCustomer_address.Text.Trim() == "" || richTextBox1.Text.Trim() == "")
            {
                MessageBox.Show("احد الخيارات فارغة");
            }
            else
            {
                try
                {
                    con2007.Open();
                    string query = "UPDATE customer SET  CustomerName = @CustomerName ,CustomerPhone = @CustomerPhone ,CustomerAddress = @CustomerAddress ,CustomerEmail = @CustomerEmail ,CustomerDate = @CustomerDate ,CustomerReport = @CustomerReport  WHERE IDCustomer = " + txt_addCustomer_number.Text + " ";
                    OleDbCommand cmd = new OleDbCommand(query, con2007);
                    cmd.Parameters.AddWithValue("@CustomerName", txt_addCustomer_name.Text);
                    cmd.Parameters.AddWithValue("@CustomerPhone", txt_addCustomer_phone.Text);
                    cmd.Parameters.AddWithValue("@CustomerAddress", txt_addCustomer_address.Text);
                    cmd.Parameters.AddWithValue("@CustomerEmail", txt_addCustomer_email.Text);
                    cmd.Parameters.AddWithValue("@CustomerDate", datetoaddCustomer.Text);
                    cmd.Parameters.AddWithValue("@CustomerReport", richTextBox1.Text);
                    cmd.ExecuteNonQuery();


                    MessageBox.Show("تم التعديل");
                    foreach (Control d in panel2.Controls)
                    {
                        if (d is TextBox)
                        {
                            d.Text = "";
                            richTextBox1.Text = "";
                        }
                    }
                }
                catch (OleDbException)
                {
                    MessageBox.Show("تم الادخال بشكل خاطى");
                }
            }
            con2007.Close();
        }
    }
}
