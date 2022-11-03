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
    public partial class INSERT : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(@"server=LAPTOP-MJ2FACM0\SQLEXPRESS;database=CRUD;Integrated security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            Label10.Visible = true;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            {
                string q = "";
                for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                {
                    if (CheckBoxList1.Items[i].Selected)
                    {
                        q = q + CheckBoxList1.Items[i].Text + ",";
                    }
                }
                string p = "~/PHS/" + FileUpload1.FileName;
                FileUpload1.SaveAs(MapPath(p));

                string str = "insert into Tab Values('" + TextBox1.Text + "'," + TextBox2.Text + ",'" + TextBox3.Text + "','" + RadioButtonList1.SelectedItem.Text + "','" + DropDownList1.SelectedItem.Text + "','" + q + "','" + p + "','" + TextBox4.Text + "','" + TextBox5.Text + "')";
                SqlCommand cmd = new SqlCommand(str, con);
                con.Open();
                int x = cmd.ExecuteNonQuery();
                con.Close();
                if (x != 1)
                {
                    Label10.Text = "Inserted";
                }
            }
        }
    }
}