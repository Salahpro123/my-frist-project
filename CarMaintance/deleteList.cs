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
    public partial class deleteList : Form
    {
        static String databasePath = Path.Combine(Directory.GetCurrentDirectory(), "formDB.accdb");
        static string Sql2007 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + databasePath + ";Jet OLEDB:Database Password='';Persist Security Info=True;";
        OleDbConnection con2007 = new OleDbConnection(Sql2007);
        public deleteList()
        {
            InitializeComponent();
        }

        private void deleteList_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con2007.Open();
            string query = "SELECT ListID FROM lists";
            OleDbDataAdapter dr = new OleDbDataAdapter(query, con2007);
            DataTable tp = new DataTable();
            dr.Fill(tp);
            txt_number_list.ValueMember = "ListID";
            txt_number_list.DataSource = tp;
            con2007.Close();
        }

        private void txt_number_list_SelectedValueChanged(object sender, EventArgs e)
        {
            if (con2007.State == ConnectionState.Open)
            {
                con2007.Close();
            }
            else
            {
                con2007.Open();
                int selectedID = (int)txt_number_list.SelectedValue;
                string query = "SELECT * FROM lists WHERE ListID =@ListID ";
                OleDbCommand cmd = new OleDbCommand(query, con2007);
                cmd.Parameters.AddWithValue("@ListID", selectedID);
                OleDbDataReader myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    txt_number_listemployee.Text = myreader["IDEmployee"].ToString();
                    txt_number_listcar.Text = myreader["IDCars"].ToString();
                    txt_number_listspear.Text = myreader["PartID"].ToString();
                    txt_number_listservice.Text = myreader["ServiceID"].ToString();
                    txt_num_supplier_list.Text = myreader["SupplierID"].ToString();
                    richTextBox1.Text = myreader["Reports"].ToString();
                }
                con2007.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con2007.Open();
                string query = "DELETE FROM lists WHERE ListID = " + txt_number_list.Text + " ";
                OleDbCommand cmd = new OleDbCommand(query, con2007);
                cmd.ExecuteNonQuery();
                con2007.Close();
                MessageBox.Show("تم الحذف");
                foreach (Control d in panel2.Controls)
                {
                    if (d is TextBox)
                    {
                        d.Text = "";
                        txt_number_list.Text = "";
                    }
                }
            }
            catch (OleDbException)
            {
                MessageBox.Show("حدث خطا");
                con2007.Close();
            }
        }
    }
}
