<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="ShoppingSite_a.Views.Cart.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="<%= ResolveUrl("~/CSS/MyStyle.css") %>" rel="stylesheet" type="text/css" />
    <title>カート</title>
</head>
<body>
    <form id="form1" runat="server">
     <div class="page-center-wrapper">
        <div class="form-card" style="max-width: 800px;">
            <h2>ショッピングカート</h2>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />

            <table class="cart-table">
                <thead>
                    <tr>
                        <th>商品名</th>
                        <th>価格</th>
                        <th>数量</th>
                        <th>小計</th>
                        <th>操作</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptCart" runat="server" OnItemDataBound="rptCart_ItemDataBound" OnItemCommand="rptCart_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("ProductName") %></td>
                                <td><%# Eval("Price") %> 円</td>
                                <td><asp:DropDownList ID="ddlQty" runat="server" /></td>
                                <td><%# Eval("SubTotal") %> 円</td>
                                <td>
                                    <asp:Button ID="btnDelete" runat="server" Text="削除" CommandName="Delete" CommandArgument='<%# Eval("ProductId") %>' CssClass="btn-danger" />
                                    <asp:HiddenField ID="hfProductId" runat="server" Value='<%# Eval("ProductId") %>' />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>

            <div class="cart-summary">
                <p>合計金額：<span class="total-price"><asp:Label ID="lblTotal" runat="server" /> 円</span></p>
                <asp:Button ID="btnUpdate" runat="server" Text="数量を更新" OnClick="btnUpdate_Click" CssClass="btn-detail" />
            </div>

            <div class="cart-actions">
                <asp:Button ID="btnOrder" runat="server" Text="購入へ進む" OnClick="btnOrder_Click" CssClass="btn-detail" style="width:100%; padding: 15px; font-size: 18px;" />
                <p class="note">※注文完了画面が出るまで商品は確保されません。</p>
                <a href="/Views/Product/ProductList.aspx">← 商品一覧へ</a>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
