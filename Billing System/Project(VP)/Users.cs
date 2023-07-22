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
    public partial class Users : UserControl
    {
        String str = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=VP_Project;Data Source=DESKTOP-OD3GFLQ";
        SqlConnection con = null;
        SqlCommand cmd = null;
        public Users()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtUserPass.Text == "" || txtRole.Text == "")
            {
                MessageBox.Show("Please provide Product information");
                return;
            }

            try
            {
                con = new SqlConnection(str);
                con.Open();
                String q = "insert into Users (UserId,UserName,UserPassword,UserRole ) values('"+txtSearch.Text+"','" + txtUserName.Text + "', '" + txtUserPass.Text + "', '" + txtRole.Text + "')";
                cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            txtUserName.Clear();
            txtUserPass.Clear();
            txtRole.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand("update Product set Product_Name= '" + txtUserName.Text + "', Product_Quantity= '" + txtUserPass.Text + "'," +
                    " Product_Price='" + txtRole.Text + "' where UserId= " + txtSearch.Text + " ", con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtUserName.Clear();
            txtUserPass.Clear();
            txtRole.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(str);
                con.Open();
                cmd = new SqlCommand("delete from Users where UserId= " + txtSearch.Text + " ", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtUserName.Clear();
            txtUserPass.Clear();
            txtRole.Clear();

        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand("select UserId, UserName, UserPassword,UserRole from Users ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0].ToString(),dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                }

                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtUserName.Clear();
            txtUserPass.Clear();
            txtRole.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Users where UserName like '%" + txtSearch.Text + "%' ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0].ToString(),dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
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
