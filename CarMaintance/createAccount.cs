using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
namespace CarMaintance
{
    public partial class Form2 : Form
    {
        static String databasePath = Path.Combine(Directory.GetCurrentDirectory(), "formDB.accdb");
        static string Sql2007 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + databasePath + ";Jet OLEDB:Database Password='';Persist Security Info=True;";
        OleDbConnection con2007 = new OleDbConnection(Sql2007);
        public Form2()
        {
            InitializeComponent();
        }
        public void add_admin_access2007()
        {
                con2007.Open();
                string query = "INSERT INTO user_admin (Username ,[Password]) VALUES (@Username , @Password)";
                OleDbCommand cmd = new OleDbCommand(query, con2007);
                cmd.Parameters.AddWithValue("@Username", txt_add_name.Text);
                cmd.Parameters.AddWithValue("@Password", txt_add_pass.Text);
                cmd.ExecuteNonQuery();
                con2007.Close();
        }
        public void add_user_access2007()
        {
                con2007.Open();
                string query = "INSERT INTO user_normal (Username ,[Password]) VALUES (@Username , @Password)";
                OleDbCommand cmd = new OleDbCommand(query, con2007);
                cmd.Parameters.AddWithValue("@Username", txt_add_name.Text);
                cmd.Parameters.AddWithValue("@Password", txt_add_pass.Text);
                cmd.ExecuteNonQuery();
                con2007.Close();   
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_add_name.Text.Trim() == "" || txt_add_pass.Text.Trim() == "")
            {
                MessageBox.Show("لقد نسيت ان تدخل كلمه السر او اسم المستخدم");
            }
            else 
            {
            adminpass.BringToFront();
            button11.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_add_name.Text.Trim() == "" || txt_add_pass.Text.Trim() == "")
            {
                MessageBox.Show("لقد نسيت ان تدخل كلمه السر او اسم المستخدم");
            }
            else
            {
                add_user_access2007();
                MessageBox.Show("تم اضافة الحساب كموظف");
                foreach (Control c in panel2.Controls)
                {
                    if (c is TextBox)
                    {
                        c.Text = "";
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox_pass.Text == "admin")
            {
                textBox_pass.Text = "";
                add_admin_access2007();
                panel2.BringToFront();
                button11.Visible = false;
                MessageBox.Show("تم اضافة الحساب كمدير");
                foreach (Control c in panel2.Controls)
                {
                    if (c is TextBox)
                    {
                        c.Text = "";
                    }
                }
            }
            else 
            {
                textBox_pass.Text = "";
                MessageBox.Show(" كلمة السر خطا! فشل اضافة الحساب كمدير");
                foreach (Control c in panel2.Controls)
                {
                    if (c is TextBox)
                    {
                        c.Text = "";
                    }
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
            button11.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            button11.Visible = false;
        }
    }
}
