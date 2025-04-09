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
    public partial class updateList : Form
    {
        static String databasePath = Path.Combine(Directory.GetCurrentDirectory(), "formDB.accdb");
        static string Sql2007 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + databasePath + ";Jet OLEDB:Database Password='';Persist Security Info=True;";
        OleDbConnection con2007 = new OleDbConnection(Sql2007);
        public updateList()
        {
            InitializeComponent();
        }
        public void refresh(string IDR, string TABN, ComboBox com)
        {
            con2007.Open();
            string query = "SELECT " + IDR + " FROM " + TABN + "";
            OleDbDataAdapter dr = new OleDbDataAdapter(query, con2007);
            DataTable tp = new DataTable();
            dr.Fill(tp);
            com.ValueMember = IDR;
            com.DataSource = tp;
            con2007.Close();
        }
        public void increaseMoney(int IDCarsB, int AmontB)
        {
            string query = "UPDATE moneys , customerPayment SET Amont = Amont + CustomerMoney WHERE IDCars = @IDCars";
            con2007.Open();
            OleDbCommand cmd = new OleDbCommand(query, con2007);
            cmd.Parameters.AddWithValue("@IDCars", IDCarsB);
            cmd.ExecuteNonQuery();
            con2007.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            refresh("IDEmployee", "employee", txt_number_listemployee);
            refresh("IDCars", "cars", txt_number_listcar);
            refresh("PartID", "spearparts", txt_number_listspear);
            refresh("ServiceID", "services", txt_number_listservice);
            refresh("SupplierID", "suppliers", txt_num_supplier_list);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con2007.Close();
            if (txt_number_list.Text.Trim() == "" || txt_number_listemployee.Text.Trim() == "" || txt_number_listcar.Text.Trim() == "" || txt_number_listspear.Text.Trim() == "" || txt_number_listservice.Text.Trim() == "" || txt_num_supplier_list.Text.Trim() == "" || txt_customerpayment.Text.Trim() == "")
            {
                MessageBox.Show("لقد نسيت ان تملى احد الخانات");
            }
            else
            {
                con2007.Open();
                string query2 = "Select * FROM spearparts WHERE PartID =@PartID ";
                OleDbCommand cmd2 = new OleDbCommand(query2, con2007);
                string value3 = "";
                cmd2.Parameters.AddWithValue("@PartID", txt_number_listspear.Text);
                OleDbDataReader myreader = cmd2.ExecuteReader();
                while (myreader.Read())
                {
                    value3 = myreader["quantity"].ToString();
                }
                con2007.Close();
                if (value3 == "0")
                {
                    MessageBox.Show("قطعة الغيار المطلوبة غير متوفرة");
                }
                else
                {
                    try
                    {
                        con2007.Open();
                        string query = "UPDATE lists SET IDCars = @IDCars , IDEmployee = @IDEmployee , PartID = @PartID , ServiceID = @ServiceID , Reports = @Reports , SupplierID = @SupplierID WHERE ListID = " + txt_number_list.Text + " ";
                        string query3 = "UPDATE customerPayment SET CustomerMoney = @CustomerMoney WHERE IDCars = @dIDCars";
                        OleDbCommand cmd = new OleDbCommand(query, con2007);
                        OleDbCommand cmd3 = new OleDbCommand(query3, con2007);
                        cmd.Parameters.AddWithValue("@IDCars", txt_number_listcar.Text);
                        cmd.Parameters.AddWithValue("@IDEmployee", txt_number_listemployee.Text);
                        cmd.Parameters.AddWithValue("@PartID", txt_number_listspear.Text);
                        cmd.Parameters.AddWithValue("@ServiceID", txt_number_listservice.Text);
                        cmd.Parameters.AddWithValue("@Reports", richTextBox1.Text);
                        cmd.Parameters.AddWithValue("@SupplierID", txt_num_supplier_list.Text);
                        cmd3.Parameters.AddWithValue("@CustomerMoney", txt_customerpayment.Text);
                        cmd3.Parameters.AddWithValue("@dIDCars", txt_number_listcar.Text);
                        cmd.ExecuteNonQuery();
                        cmd3.ExecuteNonQuery();
                        con2007.Close();
                        MessageBox.Show("تم التعديل");
                    }
                    catch (OleDbException)
                    {
                        MessageBox.Show("لقد حدث خطا");
                    }
                    int IDCa = int.Parse(txt_number_listcar.Text);
                    int Amo = int.Parse(txt_customerpayment.Text);
                    increaseMoney(IDCa, Amo);
                    foreach (Control c in panel2.Controls)
                    {
                        if (c is ComboBox)
                        {
                            c.Text = "";
                            richTextBox1.Text = "";
                            txt_number_list.Text = "";
                            txt_customerpayment.Text = "";

                        }
                    }
                }
            }
        }
    }
}
