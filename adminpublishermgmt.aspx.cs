using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace ElibraryManagement
{
    public partial class adminpublishermanagement : System.Web.UI.Page
    {
        private readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            //ClearForm();
            GridView1.DataBind();
        }

        // add publisher
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('ID cannot be empty.');</script>");
            }
            else
            {
                if (CheckPublisherExists())
                {
                    Response.Write("<script> alert('Publisher with this id already exists'); </script>");
                }
                else
                {
                    AddNewPublisher();
                }
            }
        }
        // update publisher
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('ID cannot be empty.');</script>");
            }
            else
            {
                if (CheckPublisherExists())
                {
                    UpdatePublisherByID();
                }
                else
                {
                    Response.Write("<script> alert('Publisher does not exist'); </script>");
                }
            }
        }
        // delete publisher
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('ID cannot be empty.');</script>");
            }
            else
            {
                if (CheckPublisherExists())
                {
                    DeletePublisherByID();
                }
                else
                {
                    Response.Write("<script> alert('Publisher does not exist'); </script>");
                }
            }
            
        }

        //GO Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Trim().Equals(""))
            {
                Response.Write("<script>alert('ID cannot be empty.');</script>");
            }
            else
            {
                if (CheckPublisherExists())
                {
                    GetPublisherByID();
                }
                else
                {
                    Response.Write("<script>alert('Publisher does not exist.');</script>");
                }
            }
        }




        // user defined functions

        void GetPublisherByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from publisher_master_tbl where publisher_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                    TextBox3.Text = dt.Rows[0][2].ToString();
                    TextBox4.Text = dt.Rows[0][3].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Publisher with this ID does not exist.');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        bool CheckPublisherExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from publisher_master_tbl where publisher_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

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

        void AddNewPublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tbl(publisher_id,publisher_name, publisher_mobile, publisher_email) values(@publisher_id, @publisher_name, @publisher_mobile, @publisher_email)", con);

                cmd.Parameters.AddWithValue("@publisher_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_mobile", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_email", TextBox4.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher added successfully.');</script>");
                ClearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        public void UpdatePublisherByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("update publisher_master_tbl set publisher_name=@publisher_name, publisher_mobile=@publisher_mobile, publisher_email=@publisher_email WHERE publisher_id='" + TextBox1.Text.Trim() + "'", con);
                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_mobile", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_email", TextBox4.Text.Trim());
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {

                    Response.Write("<script>alert('Publisher Updated Successfully');</script>");
                    GridView1.DataBind();
                    ClearForm();
                }
                else
                {
                    Response.Write("<script>alert('Publisher ID does not Exist');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        public void DeletePublisherByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("Delete from publisher_master_tbl WHERE publisher_id='" + TextBox1.Text.Trim() + "'", con);
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {

                    Response.Write("<script>alert('Publisher Deleted Successfully');</script>");
                    GridView1.DataBind();
                    ClearForm();
                }
                else
                {
                    Response.Write("<script>alert('Publisher ID does not Exist');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void ClearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
        }
    }
}
