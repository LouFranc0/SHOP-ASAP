<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="APPL5.Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dettagli Prodotto</title>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css">
</head>
<body>

    <form id="form1" runat="server">
        
        <div class="d-flex justify-content-end m-3">
            <asp:Button ID="btnViewCart" runat="server" Text="Cart" OnClick="ViewCart_Click" class="m-2 btn btn-info btn-lg " />
            <asp:Button ID="btnViewHome" runat="server" Text="Home" OnClick="ViewHome_Click" class="my-2 btn btn-info btn-lg " />
         </div>
        <div class="text-center">
            <div class="mb-3">

                <asp:Image ID="imgProduct" runat="server"  class="card-img-top my-2" style="max-width:500px; max-height:500px"/>

                <div class="card-body">
                    <asp:Label ID="lblProductName" runat="server" Text=" " class="card-title fw-bold fs-5"></asp:Label>     <br />
                    <asp:Label ID="lblProductDescription" runat="server" Text=" " class="card-text"></asp:Label>     <br />
                    <asp:Label ID="lblProductPrice" runat="server" Text=" " class="card-text"></asp:Label>     <br />
                <br />
                
                <asp:Button ID="btnAddToCart" runat="server" Text="Aggiungi al Carrello" OnClick="AddToCart_Click" class="btn btn-primary" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
