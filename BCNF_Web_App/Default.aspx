<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BCNF_Web_App.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>BCNF</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>


    <link href="Default.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <h1 style="color: #000000">BCNF Normalization</h1>
            <p style="color: #000000">Click new to see the magic.</p>

            <div class="row">
                <ul>
                    <li  class="column-buttons"><asp:ImageButton data-toggle="modal" data-target="#myModal" ID="ImageButton1" runat="server" ImageUrl="~/Images/new.ico" /></li>
                    <li  class="column-buttons"><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/open.ico" /></li>
                    <li  class="column-buttons"><asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/save.ico" /></li>
                    <li class="column-buttons"><asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/save as.ico" /></li>
                    <li class="column-buttons"><asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/Images/closure.ico" /></li>
                    <li class="column-buttons"><asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/Images/key.ico" /></li>
                    <li  class="column-buttons"><asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/Images/bcnf.ico" /></li>
                    <li class="column-buttons"><asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="~/Images/steps.ico" /></li>
                    
                </ul>
            </div>

            <div>
                <%-- Edo tha ginetai i efarmogi. --%>
               
                <!-- Trigger the modal with a button  -->
                <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#modalNew">Νέο</button>

                <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#modalLoad">Φόρτωση</button>

                <div class="container">
                  
                  <!-- Modal νέο σχήμα-->
                  <div class="modal fade" id="modalNew" role="dialog">
                    <div class="modal-dialog">
    
                      <!-- Modal content-->
                        <!-- To modal αυτό θα πρέπει να έχει τα εξής: 
                            όνομα αρχείου, 
                            περιγραφή (προεραιτική),
                            δυνατότητα προσθήκης γνωρισμάτων (και διαγραφή, τροποποίηση κλπ.),
                            δυνατότητα προσθήκης συναρτησιακών εξαρτήσεων (και διαγραφή, τροποποίηση κλπ.). -->
                      <div class="modal-content">
                        <div class="modal-header">
                          <button type="button" class="close" data-dismiss="modal">&times;</button>
                          <h4 class="modal-title">Νέο σχήμα</h4>
                        </div>
                        <div class="modal-body">
                            <p>Εισάγετε όνομα για το νέο σχήμα.</p>
                            <asp:TextBox ID="tbxNewSchemaName" runat="server" placeholder="Όνομα σχήματος"></asp:TextBox>
                        </div>
                        <div class="modal-footer">
                          <asp:Button runat="server" ID="btnSaveImage" Text="Δημιουργία"  class="btn btn-default"  OnClick="btnNewNameSchema" UseSubmitBehavior="false" data-dismiss="modal" />
                        </div>
                      </div>
      
                    </div>
                  </div>
  

                  <!-- Modal φόρτωση σχήματος -->
                    <div class="modal fade" id="modalLoad" role="dialog">
                    <div class="modal-dialog">
    
                      <!-- Modal content-->
                      <div class="modal-content">
                        <div class="modal-header">
                          <button type="button" class="close" data-dismiss="modal">&times;</button>
                          <h4 class="modal-title">Φόρτωση γνωρίσματος</h4>
                        </div>
                        <div class="modal-body">
                          <p>Επιλέξτε αρχείο για φόρτωση.</p>
                        </div>
                        <div class="modal-footer">
                          <button type="button" class="btn btn-default" data-dismiss="modal">Φόρτωση</button>
                        </div>
                      </div>
      
                    </div>
                  </div>

                </div>

                <asp:TextBox ID="result_tb" runat="server" Enabled="False"></asp:TextBox>
                <asp:TextBox ID="input_tb" runat="server" Text="Write an attribute" OnTextChanged="input_tb_TextChanged"></asp:TextBox>
            </div>

          

        </div>





        <ul>
            <li class="left_nav"><a href="#" class="round green rd">Login<span class="round">That is, if you already have an account.</span></a></li>
            <li class="left_nav"><a href="#" class="round red rd">Sign Up<span class="round">But only if you really, really want to. </span></a></li>
            <li class="left_nav"><a href="#" class="round yellow rd">Demo<span class="round">Take a look. This product is totally rad!</span></a></li>
        </ul>
















        <div>

            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>

        </div>
        <asp:Button ID="Button1" runat="server" Text="Button" PostBackUrl="~/WebForm1.aspx" />
    </form>
</body>
</html>
