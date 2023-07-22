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
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }
        
        String str = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=VP_Project;Data Source=DESKTOP-OD3GFLQ";
        SqlConnection con = null;
        SqlCommand cmd = null;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }
            try
            {
                con = new SqlConnection(str);
                con.Open();
                String q = "Select * from LoginForm where Name='"+textBox1.Text+"' and Password='"+textBox2.Text+"'";
                cmd = new SqlCommand(q, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr[2].ToString().Equals( "Admin"))
                    {
                        if (dr[0].ToString().Equals(textBox1.Text) && dr[1].ToString().Equals(textBox2.Text))
                        {
                            this.Hide();
                            Cafe_Billing_System cafe = new Cafe_Billing_System();
                            cafe.Show();
                        }
                        else { label2.Show(); }
                    }
                    else
                    {
                        if (dr[0].ToString().Equals(textBox1.Text) && dr[1].ToString().Equals(textBox2.Text))
                        {
                            this.Hide();
                            Cashier cashier = new Cashier();
                            cashier.Show();
                        }
                        else { label2.Show(); }
                    } 
                   
                }
                dr.Close();
                con.Close();
            }catch (Exception exp){
                MessageBox.Show(exp.Message);
            }
        }
        private void Login_Load(object sender, EventArgs e)
        {
            label2.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
