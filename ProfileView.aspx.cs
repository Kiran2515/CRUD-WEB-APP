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
    public partial class ProfileView : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-MJ2FACM0\SQLEXPRESS;database=CRUD;Integrated security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            Label8.Visible = true;
            if (!IsPostBack)
            {
                string s = "select Name,Age,Address,Gender,State,Qualification,Photo from Tab where id=" + Session["id"] + "";
                SqlCommand cmd = new SqlCommand(s, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    TextBox1.Text = dr["Name"].ToString();
                    TextBox2.Text = dr["Age"].ToString();
                    TextBox3.Text = dr["Address"].ToString();
                    TextBox4.Text = dr["Gender"].ToString();
                    TextBox5.Text = dr["State"].ToString();
                    TextBox6.Text = dr["Qualification"].ToString();
                    Image1.ImageUrl = dr["Photo"].ToString();


                }
                con.Close();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(s, con);
                da.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();




            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = " update Tab set age=" + TextBox2.Text + " , address='" + TextBox3.Text + "' where id=" + Session["id"] + "";
            SqlCommand cmd = new SqlCommand(s, con);
            con.Open();
            int x = cmd.ExecuteNonQuery();
            con.Close();
            if (x == 1)
            {
                Label1.Text = "updated";
            }
        }


    }
}
