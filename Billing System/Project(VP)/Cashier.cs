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
    public partial class Cashier : Form
    {
        public Cashier()
        {
            InitializeComponent();
        }

        private void Cashier_Load(object sender, EventArgs e)
        {
            receiptControl11.Hide();
            productsControl11.Hide();
            billingControl11.Hide();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            receiptControl11.Hide();
            productsControl11.Show();
            billingControl11.Hide();
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            receiptControl11.Hide();
            productsControl11.Hide();
            billingControl11.Show();
        }

        private void btnReceipts_Click(object sender, EventArgs e)
        {
            receiptControl11.Show();
            productsControl11.Hide();
            billingControl11.Hide();
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
    }
}
