using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace CRUD_APP
{
    public partial class LOGIN : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-MJ2FACM0\SQLEXPRESS;database=CRUD;Integrated security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label3.Visible = true;
            string s = "select count(id) from Tab where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(s, con);
            con.Open();
            string k = cmd.ExecuteScalar().ToString();
            con.Close();

            if (k == "1")
            {
                string sr = "select id from Tab where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
                SqlCommand cmd1 = new SqlCommand(sr, con);
                con.Open();
                string kr = cmd1.ExecuteScalar().ToString();
                con.Close();
                Session["id"] = kr;


                Response.Redirect("ProfileView.aspx");
                //Label3.Text = "success";
            }
            else
            {

                Label3.Text = "invald username or password";
            }

        }
    }
}