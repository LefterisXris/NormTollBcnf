<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Second.aspx.cs" Inherits="BCNF_Web_App.Second" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BCNF</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class ="page-header">
            <h1> Νέο σχήμα: <asp:Label ID="lblSchemaName" runat="server" Text=""></asp:Label> <small> γνωρίσματα κια συναρτησιακές εξαρτήσεις. </small> </h1>
        </div>

        <div class="row">
            <div class="col-md-6">
                <p> Γνωρίσματα </p>

                <asp:ListBox ID="lboxAttr" runat="server" Rows="10" Width="100%"></asp:ListBox>
                <div style="text-align: right; width: 100%;">
                    <button type="button"  class="btn btn-info btn-lg" data-toggle="modal" data-target="#modalNewAttribute">+</button>
                    <asp:Button  class="btn btn-info btn-lg" ID="Button2" runat="server" Text="-" OnClick="deleteAttr" />
                </div>

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
                          <asp:Button runat="server" ID="btnSaveImage" Text="OK"  class="btn btn-default"  OnClick="btnNewAttrClick" UseSubmitBehavior="false" data-dismiss="modal" />
                        </div>
                      </div>
      
                    </div>
                  </div> <%--Modal--%>

            </div>

            <div class="col-md-6">
                <p> Συναρτησιακές εξαρτήσεις </p>

                <asp:ListBox ID="lboxFD" runat="server" Rows="10" Width="100%"></asp:ListBox>

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
                                    <asp:CheckBoxList ID="AttrCheckBoxList1" runat="server"></asp:CheckBoxList>
                                    
                                </div>
                                <div class="col-md-4">
                                    <p>Εξαρτημένες</p>
                                    <asp:CheckBoxList ID="AttrCheckBoxList2" runat="server"></asp:CheckBoxList>
                                </div>
                            </div>
                            <div class="row">
                                <p>Τελική μορφή συναρτησιακής εξάρτησης</p>
                                
                            </div>
                        </div>
                        <div class="modal-footer">
                          <asp:Button runat="server" ID="Button1" Text="OK"  class="btn btn-default"  OnClick="btnNewFDClick" UseSubmitBehavior="false" data-dismiss="modal" />
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
