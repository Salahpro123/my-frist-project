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
    public partial class updateSpareparts : Form
    {
        static String databasePath = Path.Combine(Directory.GetCurrentDirectory(), "formDB.accdb");
        static string Sql2007 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + databasePath + ";Jet OLEDB:Database Password='';Persist Security Info=True;";
        OleDbConnection con2007 = new OleDbConnection(Sql2007);
        public updateSpareparts()
        {
            InitializeComponent();
        }

        String imageloc = "";

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_addPart_number.Text.Trim() == "" || txt_addPart_name.Text.Trim() == "" || txt_addPart_payment.Text.Trim() == "" || imageloc == "")
            {
                MessageBox.Show("احد الخيارات فارغة");
            }
            try
            {
                con2007.Open();
                string query = "UPDATE spearparts SET PartName = @PartName ,PartPayment = @PartPayment ,PartImage = @PartImage ,PartDate = @PartDate) WHERE PartID = " + txt_addPart_number.Text + " ";
                OleDbCommand cmd = new OleDbCommand(query, con2007);
                cmd.Parameters.AddWithValue("@PartName", txt_addPart_name.Text);
                cmd.Parameters.AddWithValue("@PartPayment", txt_addPart_payment.Text);
                cmd.Parameters.AddWithValue("@PartImage", File.ReadAllBytes(imageloc));
                cmd.Parameters.AddWithValue("@PartDate", dateTimePickerPart.Text);
                cmd.ExecuteNonQuery();


                MessageBox.Show("تم التعديل");
                foreach (Control d in panel2.Controls)
                {
                    if (d is TextBox)
                    {
                        d.Text = "";
                        phototoPart.Text = "اختيار صورة";
                        imageloc = "";
                    }
                }
            }
            catch (OleDbException)
            {
                MessageBox.Show("تم الادخال بشكل خاطى");
            }
            con2007.Close();
        }

        private void phototoPart_Click(object sender, EventArgs e)
        {
            phototoPart.Text = "اختيار صورة";
            OpenFileDialog dia = new OpenFileDialog();
            dia.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png";
            if (dia.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imageloc = dia.FileName;
                if (imageloc != "")
                {
                    phototoPart.Text = "تم الاختيار";
                }
                else
                {
                    phototoPart.Text = "اختيار صورة";
                }
            }
        }
    }
}
