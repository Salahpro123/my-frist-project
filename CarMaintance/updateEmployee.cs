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
    public partial class updateEmployee : Form
    {
        static String databasePath = Path.Combine(Directory.GetCurrentDirectory(), "formDB.accdb");
        static string Sql2007 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + databasePath + ";Jet OLEDB:Database Password='';Persist Security Info=True;";
        OleDbConnection con2007 = new OleDbConnection(Sql2007);
        public updateEmployee()
        {
            InitializeComponent();
        }

        String imageloc = "";

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_addEmployee_number.Text.Trim() == "" || txt_addEmployee_name.Text.Trim() == "" || txt_addEmployee_phone.Text.Trim() == "" || txt_addEmployee_jop.Text.Trim() == "" || imageloc == "")
            {
                MessageBox.Show("احد الخيارات فارغة");
            }
            else
            {
                try
                {
                    con2007.Open();
                    string query = "UPDATE employee SET EmployeeName = @EmployeeName ,JopName = @JopName ,phoneEmployee = @phoneEmployee ,datetojoinEmployee = @datetojoinEmployee ,photoEmployee = @photoEmployee WHERE IDEmployee = " + txt_addEmployee_number.Text + " ";
                    OleDbCommand cmd = new OleDbCommand(query, con2007);
                    cmd.Parameters.AddWithValue("@EmployeeName", txt_addEmployee_name.Text);
                    cmd.Parameters.AddWithValue("@JopName", txt_addEmployee_jop.Text);
                    cmd.Parameters.AddWithValue("@phoneEmployee", txt_addEmployee_phone.Text);
                    cmd.Parameters.AddWithValue("@datetojoinEmployee", datetoaddEmployee.Text);
                    cmd.Parameters.AddWithValue("@photoEmployee", File.ReadAllBytes(imageloc));
                    cmd.ExecuteNonQuery();


                    MessageBox.Show("تم التعديل");
                    foreach (Control d in panel2.Controls)
                    {
                        if (d is TextBox)
                        {
                            d.Text = "";
                            phototoEmployee.Text = "اختيار صورة";
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

        private void phototoEmployee_Click(object sender, EventArgs e)
        {
            phototoEmployee.Text = "اختيار صورة";
            OpenFileDialog dia = new OpenFileDialog();
            dia.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png";
            if (dia.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imageloc = dia.FileName;
                if (imageloc != "")
                {
                    phototoEmployee.Text = "تم الاختيار";
                }
                else
                {
                    phototoEmployee.Text = "اختيار صورة";
                }
            }
        }

        private void updateEmployee_Load(object sender, EventArgs e)
        {

        }

    }
}
