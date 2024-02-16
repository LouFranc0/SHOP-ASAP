<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="APPL5.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Carrello</title>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="text-center my-2">Cart</h1>

            <div class="d-flex justify-content-end">
                <asp:Button ID="btnViewHome" runat="server" Text="Home" OnClick="ViewHome_Click" class="m-4 btn btn-info btn-lg " />
            </div>
            <div class="mx-3 p-2">
                <asp:Repeater ID="rptCart" runat="server">
                    <ItemTemplate>
                        <div class="cart-item  m-3 p-5">
                          <div class="d-flex justify-content-start ">
                            <div>
                                <h3><%# Eval("Name") %></h3>
                                <p>Prezzo: $<%# Eval("Price") %></p>
                            </div>

                           <img src='<%# Eval("Image") %>' alt='<%# Eval("Name") %>' style="width:100px" class="mx-3"/>

                          <div class="align-self-center fs-3">
                            <%# (int)Eval("Quantity") > 1 ? "x" + Eval("Quantity") : "" %>
                          </div>

                        </div>
                            <asp:Button runat="server" Text="Rimuovi" OnClick="RemoveFromCart_Click" CommandArgument='<%# Eval("ID") %>' CssClass="btn btn-danger" />
                        </div>

                        <div class="text-success">
                          <hr>
                        </div>

                    </ItemTemplate>
                </asp:Repeater>
                <br />
                <div class="text-center">
                <asp:Button ID="btnClearCart" runat="server" Text="Svuota Carrello" OnClick="ClearCart_Click" class="btn btn-danger btn-lg"/>
                <p>Totale: $<asp:Label ID="lblTotal" runat="server" Text="0.00"></asp:Label></p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
