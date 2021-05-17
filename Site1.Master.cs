using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibraryManagement
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].Equals(""))
                {
                    LinkButton1.Visible = true; //user login link button
                    LinkButton2.Visible = true; //user sign up link button

                    LinkButton3.Visible = false; //user logout link button
                    LinkButton7.Visible = false; //Hello user link button

                    LinkButton6.Visible = true; //Admin Login link button
                    LinkButton11.Visible = false; //Author Management link button
                    LinkButton12.Visible = false; //Publisher Management link button
                    LinkButton8.Visible = false; //Book Inventory link button
                    LinkButton9.Visible = false; //Book Issuing  link button
                    LinkButton10.Visible = false; //Member Management  link button
                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false; //user login link button
                    LinkButton2.Visible = false; //user sign up link button

                    LinkButton3.Visible = true; //user logout link button
                    LinkButton7.Visible = true; //Hello user link button
                    LinkButton7.Text = "Hello "+ Session["username"].ToString(); //Hello user welcome button

                    LinkButton6.Visible = true; //Admin Login link button
                    LinkButton11.Visible = false; //Author Management link button
                    LinkButton12.Visible = false; //Publisher Management link button
                    LinkButton8.Visible = false; //Book Inventory link button
                    LinkButton9.Visible = false; //Book Issuing  link button
                    LinkButton10.Visible = false; //Member Management  link button
                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false; //user login link button
                    LinkButton2.Visible = false; //user sign up link button

                    LinkButton3.Visible = true; //user logout link button
                    LinkButton7.Visible = false; //Hello user link button
                    LinkButton7.Text = "Hello Admin"; //Hello user welcome button

                    LinkButton6.Visible = false; //Admin Login link button
                    LinkButton11.Visible = true; //Author Management link button
                    LinkButton12.Visible = true; //Publisher Management link button
                    LinkButton8.Visible = true; //Book Inventory link button
                    LinkButton9.Visible = true; //Book Issuing  link button
                    LinkButton10.Visible = true; //Member Management  link button
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormgmt.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermgmt.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookinventory.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookissuing.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermgmt.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
           Response.Redirect("viewbooks.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            try
            {
                Session["username"] = "";
                Session["fullname"] = "";
                Session["role"] = "";
                Session["status"] = "";

                LinkButton1.Visible = true; //user login link button
                LinkButton2.Visible = true; //user sign up link button

                LinkButton3.Visible = false; //user logout link button
                LinkButton7.Visible = false; //Hello user link button

                LinkButton6.Visible = true; //Admin Login link button
                LinkButton11.Visible = false; //Author Management link button
                LinkButton12.Visible = false; //Publisher Management link button
                LinkButton8.Visible = false; //Book Inventory link button
                LinkButton9.Visible = false; //Book Issuing  link button
                LinkButton10.Visible = false; //Member Management  link button

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            Response.Redirect("homepage.aspx");
        }
    }
}