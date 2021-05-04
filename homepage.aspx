<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="ElibraryManagement.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <img src="imgs/home-bg.jpg" class="img-fluid" alt="Alternate Text" />
    </section>
    <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                        <h2>Our Features</h2>
                        <p><b>Our 3 Primary Features</b></p>
                    </center>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <center>
                        <img width="150px" src="imgs/digital-inventory.png" alt="Digital Inventory" />
                        <h4>Digital Book Inventory</h4>
                        <p class="text-justify">
                            The one and only best online library in Nepal. Visit us for reading the latest best-seller books. See you soon!
                        </p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <img width="150px" src="imgs/search-online.png" alt="Search Online" />
                        <h4>Search Books</h4>
                        <p class="text-justify"> <%--  text-justify is a bootstrap class to justify the text --%>
                            The one and only best online library in Nepal. Visit us for reading the latest best-seller books. See you soon!
                        </p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <img width="150px" src="imgs/defaulters-list.png" alt="Defaulter's List" />
                        <h4>Defaulter List</h4>
                        <p class="text-justify">
                            The one and only best online library in Nepal. Visit us for reading the latest best-seller books. See you soon!
                        </p>
                    </center>
                </div>
            </div>
        </div>
    </section>
    <section>
<%--        class fluid adds responsive behavior to the image--%>
        <img src="imgs/in-homepage-banner.jpg" class="img-fluid" alt="Alternate Text" />
    </section>
    <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                        <h2>Our Process</h2>
                        <p><b>We have a Simple 3 Step Process</b></p>
                    </center>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <center>
                        <img width="150px" src="imgs/sign-up.png" alt="Sign Up" />
                        <h4>Sign Up</h4>
                        <p class="text-justify">
                            We have the best service delivery mechanism in the whole nation. Experience how it feels to be a member of the best online library in the country. We assure you, you will never forget!
                        </p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <img width="150px" src="imgs/search-online.png" alt="Search Online" />
                        <h4>Search Books</h4>
                        <p class="text-justify"> <%--  text-justify is a bootstrap class to justify the text --%>
                            The one and only best online library in Nepal. Visit us for reading the latest best-seller books. See you soon!
                        </p>
                    </center>
                </div>
                <div class="col-md-4">
                    <center>
                        <img width="150px" src="imgs/library.png" alt="Library" />
                        <h4>Visit Us</h4>
                        <p class="text-justify">
                            The one and only best online library in Nepal. Visit us for reading the latest best-seller books. See you soon!
                        </p>
                    </center>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
