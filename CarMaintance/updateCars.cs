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
    public partial class updateCars : Form
    {
        static String databasePath = Path.Combine(Directory.GetCurrentDirectory(), "formDB.accdb");
        static string Sql2007 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + databasePath + ";Jet OLEDB:Database Password='';Persist Security Info=True;";
        OleDbConnection con2007 = new OleDbConnection(Sql2007);
        public updateCars()
        {
            InitializeComponent();
        }

        String imageloc = "";

        private void updateCars_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_addCar_number.Text.Trim() == "" || txt_addCar_name.Text.Trim() == "" || txt_addModel_name.Text.Trim() == "" || txt_addDrivernumber_name.Text.Trim() == "" || txt_CaraddCustomer_number.Text.Trim() == "" || imageloc == "" || richTextBox1.Text.Trim() == "")
            {
                MessageBox.Show("احد الخيارات فارغة");
            }
            else
            {
                try
                {
                    con2007.Open();
                    string query = "UPDATE cars SET CarName = @CarName ,CarModel = @CarModel ,IDCustomer = @IDCustomer ,driverNumber = @driverNumber ,CarReport = @CarReport ,CarPhoto = @CarPhoto ,CarDateIN = @CarDateIN WHERE IDCars = " + txt_addCar_number.Text + " ";
                    OleDbCommand cmd = new OleDbCommand(query, con2007);
                    cmd.Parameters.AddWithValue("@CarName", txt_addCar_name.Text);
                    cmd.Parameters.AddWithValue("@CarModel", txt_addModel_name.Text);
                    cmd.Parameters.AddWithValue("@IDCustomer", txt_CaraddCustomer_number.Text);
                    cmd.Parameters.AddWithValue("@driverNumber", txt_addDrivernumber_name.Text);
                    cmd.Parameters.AddWithValue("@CarReport", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@CarPhoto", File.ReadAllBytes(imageloc));
                    cmd.Parameters.AddWithValue("@CarDateIN", datetoaddCar.Text);
                    cmd.ExecuteNonQuery();


                    MessageBox.Show("تم التعديل");
                    foreach (Control d in panel2.Controls)
                    {
                        if (d is TextBox)
                        {
                            d.Text = "";
                            phototoCar.Text = "اختيار صورة";
                            richTextBox1.Text = "";
                            imageloc = "";
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

        private void phototoCar_Click(object sender, EventArgs e)
        {
            phototoCar.Text = "اختيار صورة";
            OpenFileDialog dia = new OpenFileDialog();
            dia.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png";
            if (dia.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imageloc = dia.FileName;
                if (imageloc != "")
                {
                    phototoCar.Text = "تم الاختيار";
                }
                else
                {
                    phototoCar.Text = "اختيار صورة";
                }
            }
        }
    }
}
