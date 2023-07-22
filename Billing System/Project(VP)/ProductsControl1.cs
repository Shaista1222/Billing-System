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
    public partial class ProductsControl1 : UserControl
    {
        String str = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=VP_Project;Data Source=DESKTOP-OD3GFLQ";
        SqlConnection con = null;
        SqlCommand cmd = null;
        public ProductsControl1()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
           

            if (guna2TextBox3.Text == ""|| guna2TextBox4.Text == "" || guna2TextBox1.Text == "")
            {
                MessageBox.Show("Please provide Product information");
                return;
            }
           
            try
            {
                con = new SqlConnection(str);
                con.Open();
                String q = "insert into Product (Product_Name,Product_Quantity,Product_Price ) values('"+guna2TextBox3.Text+"', '"+ guna2TextBox4.Text + "', '"+ guna2TextBox1.Text + "')";
                cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            guna2TextBox1.Clear();
            guna2TextBox2.Clear();
            guna2TextBox3.Clear();
            guna2TextBox4.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
            try
            {
                con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand("update Product set Product_Name= '" + guna2TextBox3.Text + "', Product_Quantity= '" + guna2TextBox4.Text+ "'," +
                    " Product_Price='" + guna2TextBox1.Text + "' where PID= " + guna2TextBox2.Text + " ", con);
                cmd.ExecuteNonQuery();
                con.Close();
               
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
            guna2TextBox1.Clear();
            guna2TextBox2.Clear();
            guna2TextBox3.Clear();
            guna2TextBox4.Clear();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
          
            try
            {
                con = new SqlConnection(str);
                con.Open();
                cmd = new SqlCommand("delete from Product where PID= " + guna2TextBox2.Text + " ", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
            guna2TextBox1.Clear();
            guna2TextBox2.Clear();
            guna2TextBox3.Clear();
            guna2TextBox4.Clear();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
          
            try
            {
                dataGridView1.Rows.Clear();
                con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand(" select * from Product ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                }

                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            guna2TextBox1.Clear();
            guna2TextBox2.Clear();
            guna2TextBox3.Clear();
            guna2TextBox4.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Product where Product_Name like '%" + tbSearch.Text + "%' ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                }
                dr.Close();
                con.Close();
            }catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
          /*  guna2TextBox1.Clear();
            guna2TextBox2.Clear();
            guna2TextBox3.Clear();
            guna2TextBox4.Clear();*/
        }
    }
}
