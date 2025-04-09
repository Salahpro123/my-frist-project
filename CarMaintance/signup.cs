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
    public partial class signup : Form
    {
        public static int countA = 0;
        public static int countU = 0;
        public static string nameUsers = "";
        static String databasePath = Path.Combine(Directory.GetCurrentDirectory(), "formDB.accdb");
        static string Sql2007 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + databasePath + ";Jet OLEDB:Database Password='';Persist Security Info=True;";
        OleDbConnection con2007 = new OleDbConnection(Sql2007);
        public signup()
        {
            InitializeComponent();
        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void login_account_Click(object sender, EventArgs e)
        {
            if (txt_email.Text.Trim() == "" || txt_pass.Text.Trim() == "")
            {
                MessageBox.Show("لقد نسيت ان تدخل كلمه السر او اسم المستخدم");
            }
            else
            {
                string query = "SELECT COUNT(*) FROM user_admin WHERE Username = '" + txt_email.Text + "' AND [Password] = '" + txt_pass.Text + "'";
                string query1 = "SELECT COUNT(*) FROM user_normal WHERE Username = '" + txt_email.Text + "' AND [Password] = '" + txt_pass.Text + "'";
                con2007.Open();
                OleDbCommand cmd = new OleDbCommand(query, con2007);
                OleDbCommand cmd1 = new OleDbCommand(query1, con2007);
                countA = (int)cmd.ExecuteScalar();
                countU = (int)cmd1.ExecuteScalar();
                if (countA > 0)
                {
                    nameUsers = txt_email.Text;
                    foreach (Control c in panel2.Controls)
                    {
                        if (c is TextBox)
                        {
                            c.Text = "";
                        }
                    }
                    MessageBox.Show("جاري تسجيل الدخول");
                    Form1 frm1 = new Form1();
                    frm1.ShowDialog();
                }
                else
                {
                    if (countU > 0)
                    {
                        nameUsers = txt_email.Text;
                        foreach (Control c in panel2.Controls)
                        {
                            if (c is TextBox)
                            {
                                c.Text = "";
                            }
                        }
                        MessageBox.Show("جاري تسجيل الدخول ");
                        Form1 frm1 = new Form1();
                        frm1.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("المستخدم غير موجود");
                    }
                }
                con2007.Close();
            }
        }
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txt_pass.UseSystemPasswordChar = false;
            }
            else
            {
                txt_pass.UseSystemPasswordChar = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 fm2 = new Form2();
            fm2.ShowDialog();
        }

        private void signup_Load(object sender, EventArgs e)
        {
          
        }
    }
}
