<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderConfirm.aspx.cs" Inherits="ShoppingSite_a.Views.Order.OrderConfirm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <link href="<%= ResolveUrl("~/CSS/MyStyle.css") %>" rel="stylesheet" type="text/css" />
    <title>購入確認</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>購入確認画面</h2>

        <asp:Repeater ID="rptConfirm" runat="server">
            <ItemTemplate>
                <div style="margin-bottom: 10px; border-bottom: 1px dashed #ccc; padding-bottom: 5px;">
                    商品名： <%# Eval("ProductName") %><br />
                    価格： <%# Eval("Price") %> 円<br />
                    数量： <%# Eval("Quantity") %><br />
                    小計： <%# Eval("SubTotal") %> 円
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <br />
        <div>
            消費税 (10%)： <asp:Label ID="lblTax" runat="server" /> 円<br />
            <strong>合計金額： <asp:Label ID="lblTotal" runat="server" /> 円</strong>
        </div>

        <br />
        <asp:Button ID="btnConfirm" runat="server" Text="購入確定" OnClick="btnConfirm_Click" 
            OnClientClick="return confirm('購入を確定します。よろしいですか？');" />

        <asp:Button ID="btnCancel" runat="server" Text="キャンセル" OnClick="btnCancel_Click" />
    </form>
</body>
</html>