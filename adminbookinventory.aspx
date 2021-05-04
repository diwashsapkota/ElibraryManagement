<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminbookinventory.aspx.cs" Inherits="ElibraryManagement.adminbookinventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book Details</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/books.png" alt="User" />
                                </center>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col">
                                <center>
                                    <hr />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:FileUpload ID="FIleUpload1" CssClass="form-control" runat="server" />
                            </div>
                        </div><br />

                        <div class="row">
                            <div class="col-md-3">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="ID"></asp:TextBox> 
                                        <asp:Button class="btn btn-secondary ml-1" ID="Button1">Go</asp:Button>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-9">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Book Name" TextMode="SingleLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>Language</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Text="English" Value="English" />
                                        <asp:ListItem Text="Nepali" Value="Nepali" />
                                        <asp:ListItem Text="Hindi" Value="Hindi" />
                                    </asp:DropDownList>
                                </div>
                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                                        <asp:ListItem Text="Ekta Publication" Value="Ekta Publication" />
                                        <asp:ListItem Text="Heritage Publication" Value="Heritage Publication" />
                                        <asp:ListItem Text="KEC Publication" Value="KEC Publication" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Author Name</label>
                                <div class="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList3" runat="server">
                                        <asp:ListItem Text="Bill Johnson" Value="Bill Johnson" />
                                        <asp:ListItem Text="Kris Vallotton" Value="Kris Vallotton" />
                                        <asp:ListItem Text="Sadhu Sundar Selvaraj" Value="Sadhu Sundar Selvaraj" />
                                    </asp:DropDownList>
                                </div>
                                <label>Published Date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="mm/dd/yyyy" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Genre</label>
                                <div class="form-group">
                                    <asp:ListBox ID="ListBox1" CssClass="form-control" runat="server" Rows="5">
                                        <asp:ListItem Text="Action" Value="Action"/>
                                        <asp:ListItem Text="Adventure" Value="Adventure"/>
                                        <asp:ListItem Text="Comic Book" Value="Comic Book"/>
                                        <asp:ListItem Text="Self Help" Value="Self Help"/>
                                        <asp:ListItem Text="Motivation" Value="Motivation"/>
                                        <asp:ListItem Text="Fantasy" Value="Fantasy"/>
                                        <asp:ListItem Text="Poetry" Value="Poetry"/>
                                        <asp:ListItem Text="Autobiography" Value="Autobiography"/>
                                    </asp:ListBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Edition</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="" TextMode="Number"></asp:TextBox>
                                </div>
                                <label>Actual Stock</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Book Cost (per unit)</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="" TextMode="Number"></asp:TextBox>
                                </div>
                                <label>Current Stock</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="" TextMode="Number" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Pages</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="" TextMode="Number"></asp:TextBox>
                                </div>
                                <label>Issued Books</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="" TextMode="Number" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <label>Book Description</label>
                                <asp:TextBox ID="TextBox10" class="form-control" runat="server" TextMode="MultiLine" Placeholder="Enter Book description here..." Rows="2"/>
                            </div>
                        </div><br />

                        <div class="row">
                            <div class="col-4">
                                <asp:Button class="btn btn-success btn-block btn-lg" ID="Button2" text="Add" runat="server" />
                            </div>

                            <div class="col-4">
                                <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button3" text="Update" runat="server" />
                            </div>

                            <div class="col-4">
                                <asp:Button class="btn btn-danger btn-block btn-lg" ID="Button4" text="Delete" runat="server" />
                            </div>
                        </div>


                    </div>
                    
                </div><br />
                </div>

            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book Inventory List</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server"></asp:GridView>
                            </div>
                        </div>

                    </div>
                    
                </div><br />
            </div>
                
         </div>
     </div>
</asp:Content>
