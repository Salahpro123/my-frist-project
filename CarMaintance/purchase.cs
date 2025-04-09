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
    public partial class purchase : Form
    {
        static String databasePath = Path.Combine(Directory.GetCurrentDirectory(), "formDB.accdb");
        static string Sql2007 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source =" + databasePath + ";Jet OLEDB:Database Password='';Persist Security Info=True;";
        OleDbConnection con2007 = new OleDbConnection(Sql2007);
        public purchase()
        {
            InitializeComponent();
        }
        public void UpdateQuantity(int partid, int Quantity)
        {
            string query = "UPDATE spearparts SET quantity = quantity + @quantity WHERE PartID = @partid";
            con2007.Open();
            OleDbCommand cmd = new OleDbCommand(query, con2007);
            cmd.Parameters.AddWithValue("@quantity", Quantity);
            cmd.Parameters.AddWithValue("@partid", partid);
            cmd.ExecuteNonQuery();
            con2007.Close();
        }
        private void purchase_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con2007.Open();
            string query = "SELECT PartID FROM spearparts";
            OleDbDataAdapter dr = new OleDbDataAdapter(query, con2007);
            DataTable tp = new DataTable();
            dr.Fill(tp);
            comboBox1.ValueMember = "PartID";
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
                string query = "SELECT * FROM spearparts , payprice WHERE spearparts.PartID =@PartID and payprice.PartID =@PartID";
                OleDbCommand cmd = new OleDbCommand(query, con2007);
                cmd.Parameters.AddWithValue("@PartID", selectedID);
                OleDbDataReader myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    text_quin.Text = myreader["spearparts.quantity"].ToString();
                    label_name.Text = myreader["PartName"].ToString();
                    text_price.Text = myreader["spearparts.PartPayment"].ToString();
                    txt_payprice.Text = myreader["Expr1"].ToString();
                    byte[] imageD = (byte[])myreader["PartImage"];
                    Image image;
                    MemoryStream ms = new MemoryStream(imageD);
                    image = Image.FromStream(ms);
                    pictureBox1.Image = image;
                }
                con2007.Close();
            }
        }
        int lossbuy = 0;
        string storemon = "storemon";
        string txt_moneystore = "";
        private void button1_Click(object sender, EventArgs e)
        {
            int plus = 1;
            UpdateQuantity((int)comboBox1.SelectedValue, plus);
            con2007.Open();
            int selectedID = (int)comboBox1.SelectedValue;
            string query1 = "UPDATE moneys SET Amont = @Amont";
            OleDbCommand cmd1 = new OleDbCommand(query1, con2007);
            string query = "SELECT * FROM spearparts , payprice WHERE spearparts.PartID =@PartID and payprice.PartID =@PartID";
            string query4 = "SELECT Amont FROM moneys WHERE Moneystore = @Moneystore";
            OleDbCommand cmd = new OleDbCommand(query, con2007);
            OleDbCommand cmd4 = new OleDbCommand(query4, con2007);
            cmd.Parameters.AddWithValue("@PartID", selectedID);
            cmd4.Parameters.AddWithValue("@Moneystore", storemon);
            OleDbDataReader myreader = cmd.ExecuteReader();
            while (myreader.Read())
            {
                text_quin.Text = myreader["spearparts.quantity"].ToString();
                txt_payprice.Text = myreader["Expr1"].ToString();
            }
            myreader.Close();
            OleDbDataReader myreader4 = cmd4.ExecuteReader();
            while (myreader4.Read())
            {
                txt_moneystore = myreader4["Amont"].ToString();
            }
            myreader.Close();
            int newmony = Convert.ToInt32(txt_moneystore) - Convert.ToInt32(text_price.Text);
            cmd1.Parameters.AddWithValue("@Amont", newmony);
            cmd1.ExecuteNonQuery();
            lossbuy = Convert.ToInt32(text_price.Text);
            string query2 = "UPDATE Lossall SET lossfull = lossfull + @lossfull";
            string query3 = "SELECT lossfull from Lossall";
            OleDbCommand cmd2 = new OleDbCommand(query2, con2007);
            OleDbCommand cmd3 = new OleDbCommand(query3, con2007);
            cmd2.Parameters.AddWithValue("@lossfull", lossbuy);
            OleDbDataReader myreader2 = cmd3.ExecuteReader();
            cmd2.ExecuteNonQuery();
            while (myreader2.Read())
            {
                txt_lossinbuy.Text = myreader2["lossfull"].ToString();
            }
            myreader2.Close();
            con2007.Close();
        }
    }
}
