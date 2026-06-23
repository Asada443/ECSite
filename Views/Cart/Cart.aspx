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
        <h2>カート画面</h2>

        <asp:Label ID="lblMessage" runat="server" />

        <br />
        <br />

        <asp:Repeater ID="rptCart" runat="server" OnItemDataBound="rptCart_ItemDataBound" OnItemCommand="rptCart_ItemCommand">
            <ItemTemplate>

                <br />

                商品名： <%# Eval("ProductName") %><br />

                価格： <%# Eval("Price") %> 円<br />

                数量：
        <asp:DropDownList ID="ddlQty" runat="server"></asp:DropDownList>

                <br />

                小計： <%# Eval("SubTotal") %> 円


                <asp:Button ID="btnDelete"
                    runat="server"
                    Text="削除"
                    CommandName="Delete"
                    CommandArgument='<%# Eval("ProductId") %>' />


                <asp:HiddenField ID="hfProductId" runat="server"
                    Value='<%# Eval("ProductId") %>' />

            </ItemTemplate>

        </asp:Repeater>
        <br />
        <br />

        <br />
        <br />
        合計金額：<asp:Label ID="lblTotal" runat="server" />
        円

        <asp:Button ID="btnUpdate" runat="server"
            Text="更新"
            OnClick="btnUpdate_Click" />

        ※「買い物かご」に入れた段階では商品の確保とはならず注文ステップ完了後、注文完了画面が出た段階で商品確保となります。

        <a href="/Views/Product/ProductList.aspx">商品一覧へ戻る
</a>
        <br /><br />

<asp:Button ID="btnOrder" runat="server"
    Text="購入へ進む"
    OnClick="btnOrder_Click" />
    </form>
</body>
</html>
