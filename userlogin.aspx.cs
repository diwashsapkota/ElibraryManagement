using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibraryManagement
{
    public partial class userlogin : System.Web.UI.Page
    {
        private readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //var salt = "";
                //var hashedPassword = "";
                //salt = Crypto.GenerateSalt();
                //hashedPassword = Crypto.HashPassword(salt + TextBox2.Text);
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE user_id = '" + TextBox1.Text.Trim() + "' AND password= '" + TextBox2.Text.Trim() + "'", con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if(sdr.HasRows)
                {
                    while(sdr.Read())
                    {
                        Response.Write("<script>alert('Login Successful');</script>");
                        Session["username"] = sdr.GetValue(8).ToString();
                        Session["fullname"] = sdr.GetValue(0).ToString();
                        Session["role"] = "user";
                        Session["status"] = sdr.GetValue(10).ToString();
                    }
                    Response.Redirect("homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid Login Credentials');</script>");
                }

                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }
    }
}