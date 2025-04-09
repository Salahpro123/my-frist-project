using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarMaintance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pan_parSimple.Location = button1.Location;
            panel_home.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pan_parSimple.Location = button2.Location;
            panel_storage.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pan_parSimple.Location = button3.Location;
            panel_reports.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel_next.BringToFront();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            panel_pre.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            employee employee_form = new employee();
            employee_form.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Customer customer_form = new Customer();
            customer_form.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cars cars_form = new cars();
            cars_form.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            spareparts sparepart_form = new spareparts();
            sparepart_form.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            services service_form = new services();
            service_form.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            supplier supplier_form = new supplier();
            supplier_form.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            lists list_form = new lists();
            list_form.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (signup.countA == 0)
            {
                MessageBox.Show("غير متاح للمستخدمين");
            }
            else
            {
                moneyStorage moneystorage_form = new moneyStorage();
                moneystorage_form.ShowDialog();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (signup.countA == 0)
            {
                MessageBox.Show("غير متاح للمستخدمين");
            }
            else
            {
                purchase purchase_form = new purchase();
                purchase_form.Show();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            billCosts billcost_form = new billCosts();
            billcost_form.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            reportServiveAndSpareparts reportserviveandspareparts_form = new reportServiveAndSpareparts();
            reportserviveandspareparts_form.ShowDialog();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
