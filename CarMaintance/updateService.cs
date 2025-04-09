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
    public partial class updateService : Form
    {
        static String databasePath = Path.Combine(Directory.GetCurrentDirectory(), "formDB.accdb");
        static string Sql2007 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + databasePath + ";Jet OLEDB:Database Password='';Persist Security Info=True;";
        OleDbConnection con2007 = new OleDbConnection(Sql2007);
        public updateService()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_number_serivce.Text.Trim() == "" || txt_name_serivce.Text.Trim() == "" || txt_service_payment.Text.Trim() == "")
            {
                MessageBox.Show("احد الخيارات فارغة");
            }
            else
            {
                con2007.Open();
                string query = "UPDATE services SET ServiceName = @ServiceName , ServicePayment = @ServicePayment , ServiceDate = @ServiceDate WHERE ServiceID = " + txt_number_serivce.Text + " ";
                OleDbCommand cmd = new OleDbCommand(query, con2007);
                cmd.Parameters.AddWithValue("@ServiceName", txt_name_serivce.Text);
                cmd.Parameters.AddWithValue("@ServicePayment", txt_service_payment.Text);
                cmd.Parameters.AddWithValue("@ServiceDate", dateTimePicker1.Text);
                cmd.ExecuteNonQuery();
                con2007.Close();
                MessageBox.Show("تم التعديل");
                foreach (Control c in panel2.Controls)
                {
                    if (c is TextBox)
                    {
                        c.Text = "";
                    }
                }
            }
        }
    }
}
