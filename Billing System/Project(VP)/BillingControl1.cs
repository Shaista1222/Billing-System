using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_VP_
{
    public partial class BillingControl1 : UserControl
    {
        int total=0;
        String str = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=VP_Project;Data Source=DESKTOP-OD3GFLQ";
        SqlConnection con = null;
        SqlCommand cmd = null;
        public BillingControl1()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText(guna2ComboBox1.Text +"\t\t");
            //richTextBox1.AppendText(guna2TextBox2.Text + "\t\t");
            richTextBox1.AppendText(guna2TextBox3.Text + "\t\t");
            int price = int.Parse(guna2TextBox2.Text);
            int qty = int.Parse(guna2TextBox3.Text);
            total = price * qty;
            richTextBox1.AppendText(total.ToString()+Environment.NewLine);
            guna2TextBox2.Clear();
            guna2TextBox3.Clear();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            int subTotal = total+=total;
            float afterDiscount ;
            RichTextBox rtb = new RichTextBox();
            rtb.AppendText(richTextBox1.Text);
            richTextBox1.Clear();
            richTextBox1.AppendText("----------------------------------------------------------------" + Environment.NewLine);
            richTextBox1.AppendText("\t" + "       BIIT Cafe Billing " + Environment.NewLine);
            richTextBox1.AppendText("----------------------------------------------------------------" + Environment.NewLine);
            richTextBox1.AppendText(Environment.NewLine);
            richTextBox1.AppendText("ITEM" + "\t\t\t" + "QTY" + "\t\t\t" + "Price" + Environment.NewLine);
            richTextBox1.AppendText("----------------------------------------------------------------" + Environment.NewLine);
            richTextBox1.AppendText(Environment.NewLine);

            // richTextBox1.AppendText(guna2ComboBox1.Text + "\t\t\t" + guna2TextBox3.Text + Environment.NewLine);
            richTextBox1.AppendText(rtb.Text);
            if (subTotal >= 1000 && subTotal <3000)
            {
                afterDiscount = subTotal - (subTotal * 5 / 100);
            }else
            {
                afterDiscount = subTotal - (subTotal * 10 / 100);
            }
            richTextBox1.AppendText("----------------------------------------------------------------" + Environment.NewLine);
            richTextBox1.AppendText("Total \t\t\t\t" + subTotal + Environment.NewLine);
            richTextBox1.AppendText("----------------------------------------------------------------" + Environment.NewLine);
            richTextBox1.AppendText("After Discount \t\t\t\t" + afterDiscount + Environment.NewLine);
            richTextBox1.AppendText("----------------------------------------------------------------" + Environment.NewLine);

            // richTextBox1.AppendText(DateTimePicker.Text + "\t\t\t" + lblDate.Text);
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = "Notepad Text";
            saveFile.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(saveFile.FileName))
                    sw.WriteLine(richTextBox1.Text);
            }
        }

        private void BillingControl1_Load(object sender, EventArgs e)
        {
            try
            {
                // richTextBox1.Clear();
                con = new SqlConnection(str);
                con.Open();
                cmd = new SqlCommand("select Product_Name from Product ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    guna2ComboBox1.Items.Add(dr["Product_Name"].ToString());
                }
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
