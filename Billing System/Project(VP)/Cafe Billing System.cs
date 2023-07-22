using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_VP_
{
    public partial class Cafe_Billing_System : Form
    {
        public Cafe_Billing_System()
        {
            InitializeComponent();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            billingControl12.Hide();
            receiptControl11.Hide();
            productsControl12.Hide();
            users1.Show();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            billingControl12.Hide();
            receiptControl11.Hide();
            users1.Hide();
            productsControl12.Show();
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            productsControl12.Hide();
            receiptControl11.Hide();
            users1.Hide();
            billingControl12.Show();
        }

        private void btnReceipts_Click(object sender, EventArgs e)
        {
            productsControl12.Hide();
            billingControl12.Hide();
            users1.Hide();
            receiptControl11.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login log = new Login();
            log.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Cafe_Billing_System_Load(object sender, EventArgs e)
        {
            productsControl12.Hide();
            billingControl12.Hide();
            receiptControl11.Hide();
            users1.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
