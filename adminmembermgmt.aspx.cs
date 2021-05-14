using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibraryManagement
{
    public partial class adminmembermgmt : System.Web.UI.Page
    {
        private readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //GO Button
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            if (TextBox3.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('ID cannot be empty.');</script>");
            }
            else
            {
                if(CheckIfMemberExists())
                {
                    GetMemberById();
                }
                else
                {
                    Response.Write("<script>alert('Member does not exist.');</script>");
                }
            }

        }

        // Active button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (TextBox3.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('ID cannot be empty.');</script>");
            }
            else
            {
                if (CheckIfMemberExists())
                {
                    UpdateMemberStatusByID("active");
                }
                else
                {
                    Response.Write("<script>alert('Member does not exist.');</script>");
                }
            }
        }
        // pending button
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (TextBox3.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('ID cannot be empty.');</script>");
            }
            else
            {
                if (CheckIfMemberExists())
                {
                    UpdateMemberStatusByID("pending");
                }
                else
                {
                    Response.Write("<script>alert('Member does not exist.');</script>");
                }
            }
        }
        // deactive button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            if (TextBox3.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('ID cannot be empty.');</script>");
            }
            else
            {
                if (CheckIfMemberExists())
                {
                    UpdateMemberStatusByID("deactivated");
                }
                else
                {
                    Response.Write("<script>alert('Member does not exist.');</script>");
                }
            }
        }
        // delete button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox3.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('ID cannot be empty.');</script>");
            }
            else
            {
                if (CheckIfMemberExists())
                {
                    DeleteMemberByID();
                }
                else
                {
                    Response.Write("<script>alert('Member does not exist.');</script>");
                }
            }
            
        }

        //user-defined function

        bool CheckIfMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where user_id = '" + TextBox3.Text.Trim() + "' ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        void DeleteMemberByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE from member_master_tbl WHERE user_id = '" + TextBox3.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Member Deleted Successfully');</script>");
                ClearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        void GetMemberById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE user_id = '" + TextBox3.Text.Trim() + "' ", con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        TextBox3.Text = sdr.GetValue(8).ToString();
                        TextBox4.Text = sdr.GetValue(0).ToString();
                        TextBox7.Text = sdr.GetValue(10).ToString();
                        TextBox1.Text = sdr.GetValue(1).ToString();
                        TextBox2.Text = sdr.GetValue(2).ToString();
                        TextBox5.Text = sdr.GetValue(3).ToString();
                        TextBox6.Text = sdr.GetValue(4).ToString();
                        TextBox8.Text = sdr.GetValue(5).ToString();
                        TextBox9.Text = sdr.GetValue(6).ToString();
                        TextBox10.Text = sdr.GetValue(7).ToString();
                    }
                }
                else
                {
                    Response.Write("<script> alert('Member does not exist in the database'); </script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "'); </script>");

            }
        }

        void UpdateMemberStatusByID(string status)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status='" + status + "' WHERE user_id='" + TextBox3.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
                Response.Write("<script>alert('Member Status Updated');</script>");


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            ClearForm();
        }

        void ClearForm()
        {
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox7.Text = "";
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
        }


    }
}