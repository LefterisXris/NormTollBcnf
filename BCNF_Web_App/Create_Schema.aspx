<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create_Schema.aspx.cs" Inherits="BCNF_Web_App.Create_Schema" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BCNF</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>


    <%--<link href="Default.css" rel="stylesheet" type="text/css" />--%>
</head>

<body>
    <form id="form1" runat="server">
         
        <div class="container">
            <div class="page-header">
                <h1> Νέο σχήμα <asp:Label ID="lblSchemaName" runat="server" Text=""></asp:Label> <small> γνωρίσματα και συναρτησιακές εξαρτήσεις. </small></h1>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <p> Γνωρίσματα </p>                 
                    
                    <asp:ListBox ID="AttrList" runat="server" Width="100%" Rows="10"></asp:ListBox>

                    <div style="text-align: right; width: 100%;">
                        <button type="button"  class="btn btn-info btn-lg" data-toggle="modal" data-target="#modalNewAttribute">+</button>
                        <asp:Button  class="btn btn-info btn-lg" ID="Button2" runat="server" Text="-" OnClick="deleteAttr" />
                    </div>  

                    <asp:Label ID="lblAttrName" runat="server" Visible="False"></asp:Label>

                  <!-- Modal νέο γνώρισμα-->
                  <div class="modal fade" id="modalNewAttribute" role="dialog">
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
                          <h4 class="modal-title">Νέο γνώρισμα</h4>
                        </div>
                        <div class="modal-body">
                            
                            <p>Εισάγετε όνομα για το νέο γνώρισμα.</p>
                            <asp:TextBox ID="tbxNewAttrName" runat="server" placeholder="Όνομα σχήματος"></asp:TextBox>
                        </div>
                        <div class="modal-footer">
                          <asp:Button runat="server" ID="btnSaveImage" Text="OK"  class="btn btn-default"  OnClick="btnNewAttrSchema" UseSubmitBehavior="false" data-dismiss="modal" />
                        </div>
                      </div>
      
                    </div>
                  </div>

                </div>
                <div class="col-md-6">
                    <p> Συναρτησιακές εξαρτήσεις </p> 
                    
                    <asp:ListBox ID="FDList" runat="server" Width="100%" Rows="10"></asp:ListBox>

                    <div style="text-align: right; width: 100%;">
                        <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#modalNewFD">+</button>
                        <asp:Button class="btn btn-info btn-lg" ID="Button3" runat="server" Text="-" OnClick="deleteFD" />        
                    </div>

                  <!-- Modal νέα συναρτησιακή εξάρτηση-->
                  <div class="modal fade" id="modalNewFD" role="dialog">
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
                          <h4 class="modal-title">Νέα συναρτησιακή εξάρτηση</h4>
                        </div>
                        <div class="modal-body">
                            
                            <p>Δομή συναρτησιακής εξάρτησης</p>
                            <div class="row">
                                <div class="col-md-4">
                                    <p>Ορίζουσες</p>
                                    <asp:CheckBoxList ID="AtrrCheckBoxList1" runat="server" OnSelectedIndexChanged="AtrrCheckBoxList1_SelectedIndexChanged"></asp:CheckBoxList>
                                    
                                </div>
                                <div class="col-md-4">
                                    <p>Εξαρτημένες</p>
                                    <asp:CheckBoxList ID="AtrrCheckBoxList2" runat="server" OnSelectedIndexChanged="AtrrCheckBoxList2_SelectedIndexChanged"></asp:CheckBoxList>
                                </div>
                            </div>
                            <div class="row">
                                <p>Τελική μορφή συναρτησιακής εξάρτησης</p>
                                <asp:Label ID="lblOrizouses" runat="server" Text="" Visible="False"></asp:Label>
                                <asp:Label ID="lblVelaki" runat="server" Text="-->"></asp:Label>
                                <asp:Label ID="lblEksartimenes" runat="server" Text="" Visible="False"></asp:Label>
                            </div>
                        </div>
                        <div class="modal-footer">
                          <asp:Button runat="server" ID="Button1" Text="OK"  class="btn btn-default"  OnClick="btnNewFD" UseSubmitBehavior="false" data-dismiss="modal" />
                        </div>
                      </div>
      
                    </div>
                  </div>
                    
                </div>
            </div>
        </div>
        
    </form>
</body>
</html>
