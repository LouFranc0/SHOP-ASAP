<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="APPL5.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Franco's Shop</title>

        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />

</head>
<body>
    <form id="form1" runat="server">
            <h1 class="text-center my-3">Amashop</h1>

        <div class="d-flex justify-content-end">
            <asp:Button ID="btnViewCart" runat="server" Text="Cart" OnClick="ViewCart_Click" class="mx-5 btn btn-info btn-lg " />
        </div>
        <div>
            <div class="d-flex">
                <asp:Repeater ID="rptProducts" runat="server">
                    <ItemTemplate>
                        <div class="product card m-4" style="width: 18rem;">
                            <img src='<%# Eval("Image") %>' alt='<%# Eval("Name") %>' class="card-img-top"/>
                              <div class="card-body d-flex justify-content-end flex-column">
                                <h3 class="card-title"><%# Eval("Name") %></h3>
                                <p class="card-text">Prezzo: $<%# Eval("Price") %></p>
                                <asp:Button runat="server" Text="Dettagli" OnClick="ViewDetails_Click" CommandArgument='<%# Eval("ID") %>' class="btn btn-primary"/>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>


</body>
</html>
