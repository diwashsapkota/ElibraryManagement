using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace ElibraryManagement
{
    public partial class adminbookinventory : System.Web.UI.Page
    {
        private readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_books;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillAuthorPublisherValues();
            }

            GridView1.DataBind();
        }

        //Go Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            GetBookByID();
        }

        //Add Button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (CheckIfBookExists())
            {
                Response.Write("<script>alert('Book Already Exists, try some other Book ID');</script>");
            }
            else
            {
                AddNewBook();
            }
        }

        //Update Button
        protected void Button3_Click(object sender, EventArgs e)
        {
            UpdateBookByID();
        }

        //Delete Button
        protected void Button4_Click(object sender, EventArgs e)
        {
            DeleteBookByID();
        }

        //user-defined functions
        void FillAuthorPublisherValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tbl", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "author_name";
                DropDownList3.DataBind();

                SqlCommand cmd1 = new SqlCommand("SELECT * FROM publisher_master_tbl", con);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                DropDownList2.DataSource = dt1;
                DropDownList2.DataValueField = "publisher_name";
                DropDownList2.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void DeleteBookByID()
        {
            if (CheckIfBookExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from book_master_tbl WHERE book_id='" + TextBox3.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Book Deleted Successfully');</script>");

                    GridView1.DataBind();
                    ClearForm();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID');</script>");
            }
        }

        void UpdateBookByID()
        {

            if (CheckIfBookExists())
            {
                try
                {

                    int actual_stock = Convert.ToInt32(TextBox8.Text.Trim());
                    int current_stock = Convert.ToInt32(TextBox7.Text.Trim());

                    if (global_actual_stock == actual_stock)
                    {

                    }
                    else
                    {
                        if (actual_stock < global_issued_books)
                        {
                            Response.Write("<script>alert('Actual Stock value cannot be less than the Issued books');</script>");
                            return;


                        }
                        else
                        {
                            current_stock = actual_stock - global_issued_books;
                            TextBox7.Text = "" + current_stock;
                        }
                    }

                    string genres = "";
                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        genres = genres + ListBox1.Items[i] + ",";
                    }
                    genres = genres.Remove(genres.Length - 1);

                    string filepath = "~/book_inventory/books1.png";
                    string filename = Path.GetFileName(FIleUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;

                    }
                    else
                    {
                        FIleUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                        filepath = "~/book_inventory/" + filename;
                    }

                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd2 = new SqlCommand("SELECT * FROM author_master_tbl WHERE author_name = '" + DropDownList3.SelectedItem.Value + "' ", con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                    DataTable sdt = new DataTable();
                    sda.Fill(sdt);
                    var aid = "";
                    if (sdt.Rows.Count >= 1)
                    {
                        aid = sdt.Rows[0]["author_id"].ToString().Trim();
                    }

                    else
                    {
                        Response.Write("<script>alert('Author Not Found.');</script>");
                    }


                    SqlCommand cmd3 = new SqlCommand("SELECT * from publisher_master_tbl WHERE publisher_name = '" + DropDownList2.SelectedItem.Value + "' ", con);
                    SqlDataAdapter sda2 = new SqlDataAdapter(cmd3);
                    DataTable sdt2 = new DataTable();
                    sda2.Fill(sdt2);
                    var pid = "";
                    if (sdt.Rows.Count >= 1)
                    {
                        pid = sdt2.Rows[0]["publisher_id"].ToString().Trim();
                    }
                    else
                    {
                        Response.Write("<script>alert('Publisher Not Found.');</script>");
                    }


                    SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl SET book_name=@book_name, genre=@genre, author=@author, publisher=@publisher, published_date=@published_date, language=@language, edition=@edition, book_price=@book_price, no_of_pages=@no_of_pages, book_description=@book_description, actual_stock=@actual_stock, current_stock=@current_stock, book_img_link=@book_img_link where book_id='" + TextBox3.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@author", aid);
                    cmd.Parameters.AddWithValue("@publisher", pid);
                    cmd.Parameters.AddWithValue("@published_date", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_price", TextBox9.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_description", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", TextBox8.Text.Trim());
                    cmd.Parameters.AddWithValue("@current_stock", TextBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_img_link", filepath);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Book Updated Successfully');</script>");
                    ClearForm();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID');</script>");
            }
        }

        void GetBookByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                
                SqlCommand cmd = new SqlCommand("SELECT a.author_name, p.publisher_name, b.* FROM book_master_tbl b JOIN author_master_tbl a ON a.author_id = b.author JOIN publisher_master_tbl p ON p.publisher_id = b.publisher WHERE book_id='" + TextBox3.Text.Trim() + "' ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0]["book_name"].ToString().Trim();
                    TextBox6.Text = dt.Rows[0]["published_date"].ToString();
                    TextBox2.Text = dt.Rows[0]["edition"].ToString();
                    TextBox9.Text = dt.Rows[0]["book_price"].ToString().Trim();
                    TextBox1.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    TextBox8.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    TextBox7.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    TextBox10.Text = dt.Rows[0]["book_description"].ToString();
                    TextBox5.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));

                    DropDownList1.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                    DropDownList2.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                    DropDownList3.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();

                    ListBox1.ClearSelection();
                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                    for (int i = 0; i < genre.Length; i++)
                    {
                        for (int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString() == genre[i])
                            {
                                ListBox1.Items[j].Selected = true;

                            }
                        }
                    }

                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    global_issued_books = global_actual_stock - global_current_stock;
                    global_filepath = dt.Rows[0]["book_img_link"].ToString();

                }
                else
                {
                    Response.Write("<script>alert('Invalid Book ID');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool CheckIfBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tbl where book_id='" + TextBox3.Text.Trim() + "' OR book_name='" + TextBox4.Text.Trim() + "';", con);
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

        void AddNewBook()
        {
            try
            {
                string genres = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }
                // genres = Adventure,Self Help,
                genres = genres.Remove(genres.Length - 1);

                string filepath = "~/book_inventory/books1.png";
                string filename = Path.GetFileName(FIleUpload1.PostedFile.FileName);
                FIleUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                filepath = "~/book_inventory/" + filename;


                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                

                SqlCommand cmd2 = new SqlCommand("SELECT * from author_master_tbl WHERE author_name = '" + DropDownList3.SelectedItem.Value + "' ", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                DataTable sdt = new DataTable();
                sda.Fill(sdt);
                var aid = "";
                if (sdt.Rows.Count >= 1)
                {
                    aid = sdt.Rows[0]["author_id"].ToString().Trim();
                }
                
                else
                {
                    Response.Write("<script>alert('Author Not Found.');</script>");
                }
                

                SqlCommand cmd3 = new SqlCommand("SELECT * from publisher_master_tbl WHERE publisher_name = '" + DropDownList2.SelectedItem.Value + "' ", con);
                SqlDataAdapter sda2 = new SqlDataAdapter(cmd3);
                DataTable sdt2 = new DataTable();
                sda2.Fill(sdt2);
                var pid = "";
                if (sdt.Rows.Count >= 1)
                {
                    pid = sdt2.Rows[0]["publisher_id"].ToString().Trim();
                }
                else
                {
                    Response.Write("<script>alert('Publisher Not Found.');</script>");
                }

                
                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl (book_id,book_name,genre,author,publisher,published_date,language,edition,book_price,no_of_pages,book_description,actual_stock,current_stock,book_img_link) values (@book_id,@book_name,@genre,@author,@publisher,@published_date,@language,@edition,@book_price,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link)", con);
                cmd.Parameters.AddWithValue("@book_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                cmd.Parameters.AddWithValue("@author", aid);
                cmd.Parameters.AddWithValue("@publisher", pid);
                cmd.Parameters.AddWithValue("@published_date", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@book_price", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@book_img_link", filepath);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book added successfully.');</script>");
                GridView1.DataBind();
                ClearForm();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void ClearForm()
        {
            TextBox4.Text = "";
            TextBox6.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox9.Text = "";
            TextBox1.Text = "";
            TextBox8.Text = "";
            TextBox7.Text = "";
            TextBox10.Text = "";
            TextBox5.Text = "";

            DropDownList1.ClearSelection();
            DropDownList2.ClearSelection();
            DropDownList3.ClearSelection();

            ListBox1.ClearSelection();
        }

    }
}