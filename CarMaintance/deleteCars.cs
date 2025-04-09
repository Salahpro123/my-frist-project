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
    public partial class deleteCars : Form
    {
        static String databasePath = Path.Combine(Directory.GetCurrentDirectory(), "formDB.accdb");
        static string Sql2007 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + databasePath + ";Jet OLEDB:Database Password='';Persist Security Info=True;";
        OleDbConnection con2007 = new OleDbConnection(Sql2007);
        public deleteCars()
        {
            InitializeComponent();
        }

        private void deleteCars_Load(object sender, EventArgs e)
        {

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
                string query = "SELECT * FROM cars WHERE IDCars =@IDCars ";
                OleDbCommand cmd = new OleDbCommand(query, con2007);
                cmd.Parameters.AddWithValue("@IDCars", selectedID);
                OleDbDataReader myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    txt_addCar_name.Text = myreader["CarName"].ToString();
                    txt_addModel_name.Text = myreader["CarModel"].ToString();
                    txt_addDrivernumber_name.Text = myreader["driverNumber"].ToString();
                    txt_CaraddCustomer_number.Text = myreader["IDCustomer"].ToString();
                    richTextBox1.Text = myreader["CarReport"].ToString();
                }
                con2007.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con2007.Open();
                string query = "DELETE FROM cars WHERE IDCars = " + comboBox1.Text + " ";
                OleDbCommand cmd = new OleDbCommand(query, con2007);
                cmd.ExecuteNonQuery();
                con2007.Close();
                MessageBox.Show("تم الحذف");
                foreach (Control d in panel2.Controls)
                {
                    if (d is TextBox)
                    {
                        d.Text = "";
                        comboBox1.Text = "";
                        richTextBox1.Text = "";
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
