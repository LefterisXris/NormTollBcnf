<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BCNF_Web_App.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>BCNF</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <script src="Scripts/bootstrap.min.js"></script>
    <link rel="stylesheet" href="Content/bootstrap-theme.min.css" />

    <link href="Default.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <h1>Working with Grid Rows/Columns</h1>
            <p>Resize your browser window to see the magic...</p>

            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-2 main_buttons">
                    <a href="#" class="round green rd">Αρχείο<span class="round">Λειτουργίες όπως: Νέο, Άνοιγμα, Έξοδος κλπ.</span></a>
                    <%--<asp:Button class="main_btns" ID="Button1" runat="server" Text="Αρχείο" />--%>
                </div>
                <div class="col-md-1"></div>
                <div class="col-md-2 main_buttons">
                    <a href="#" class="round red rd">Κανονικοποίηση<span class="round">Θα έχει Εγκλυσμό, Διάσπαση, Κλειδιά, Σταδική.</span></a>
                    <%--<asp:Button class="main_btns" ID="Button2" runat="server" Text="Κανονικοποίηση" />--%>
                </div>
                <div class="col-md-1"></div>
                <div class="col-md-2 main_buttons">
                    <a href="#" class="round yellow rd">Το πρόγραμμα<span class="round">Ρυθμίσεις, οδηγίες, credits.</span></a>
                    <%--<asp:Button class="main_btns" ID="Button3" runat="server" Text="Το πρόγραμμα" />--%>
                </div>
            </div>

            <div class="row">
                <div class="col-md-1">
                    <div class="column-buttons">
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/new.ico" />
                    </div>
                    <div class="column-buttons">
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/open.ico" />
                    </div>
                    <div class="column-buttons">
                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/save.ico" />
                    </div>
                    <div class="column-buttons">
                        <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/save as.ico" />
                    </div>
                    <div class="column-buttons">
                        <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/Images/closure.ico" />
                    </div>
                    <div class="column-buttons">
                        <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/Images/key.ico" />
                    </div>
                    <div class="column-buttons">
                        <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/Images/bcnf.ico" />
                    </div>
                    <div class="column-buttons">
                        <asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="~/Images/steps.ico" />
                    </div>

                </div>
                <div class="col-md-11" style="background-color: pink;">
                </div>
            </div>
        </div>





        <ul>
            <li><a href="#" class="round green rd">Login<span class="round">That is, if you already have an account.</span></a></li>
            <li><a href="#" class="round red rd">Sign Up<span class="round">But only if you really, really want to. </span></a></li>
            <li><a href="#" class="round yellow rd">Demo<span class="round">Take a look. This product is totally rad!</span></a></li>
        </ul>
















        <div>

            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>

        </div>
    </form>
</body>
</html>
