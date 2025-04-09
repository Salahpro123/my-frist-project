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
    public partial class updateSupplier : Form
    {
        static String databasePath = Path.Combine(Directory.GetCurrentDirectory(), "formDB.accdb");
        static string Sql2007 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + databasePath + ";Jet OLEDB:Database Password='';Persist Security Info=True;";
        OleDbConnection con2007 = new OleDbConnection(Sql2007);
        public updateSupplier()
        {
            InitializeComponent();
        }

        private void updateSupplier_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_suppliers_number.Text.Trim() == "" || txt_suppliers_name.Text.Trim() == "" || txt_suppliers_phone.Text.Trim() == "")
            {
                MessageBox.Show("احد الخيارات فارغة");
            }
            else
            {
                try
                {
                    con2007.Open();
                    string query = "UPDATE suppliers SET SupplierName = @SupplierName , SupplierPhone = @SupplierPhone , SupplierAddress = @SupplierAddress , Supplierdate = @Supplierdate WHERE SupplierID = " + txt_suppliers_number.Text + " ";
                    OleDbCommand cmd = new OleDbCommand(query, con2007);
                    cmd.Parameters.AddWithValue("@SupplierName", txt_suppliers_name.Text);
                    cmd.Parameters.AddWithValue("@SupplierPhone", txt_suppliers_phone.Text);
                    cmd.Parameters.AddWithValue("@SupplierAddress", txt_suppliers_Address.Text);
                    cmd.Parameters.AddWithValue("@Supplierdate", dateTimePicker1.Text);
                    cmd.ExecuteNonQuery();
                    con2007.Close();
                    MessageBox.Show("تم التعديل");
                    foreach (Control d in panel2.Controls)
                    {
                        if (d is TextBox)
                        {
                            d.Text = "";
                        }
                    }
                }
                catch (OleDbException)
                {
                    MessageBox.Show("تم الادخال بشكل خاطى");
                }
            }
        }
    }
}
