<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderComplete.aspx.cs" Inherits="ShoppingSite_a.Views.Order.OrderComplete" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <link href="<%= ResolveUrl("~/CSS/MyStyle.css") %>" rel="stylesheet" type="text/css" />
    <title>購入完了</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>ご購入ありがとうございました！</h2>
        <p>移住チケットの確保が完了いたしました。</p>

        <div style="border: 1px solid #000; padding: 15px; width: 400px; background-color: #f9f9f9;">
            <h3>注文詳細情報</h3>
            
            <strong>購入番号：</strong> <asp:Label ID="lblOrderId" runat="server" /><br /><br />

            <asp:Repeater ID="rptDetails" runat="server">
                <ItemTemplate>
                    <div style="margin-bottom: 8px; border-bottom: 1px dotted #ccc;">
                        商品名： <%# Eval("ProductName") %><br />
                        数量： <%# Eval("Quantity") %><br />
                        小計： <%# Eval("SubTotal") %> 円
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <br />
            消費税： <asp:Label ID="lblTax" runat="server" /> 円<br />ke
            <strong>合計金額： <asp:Label ID="lblTotal" runat="server" /> 円</strong>
        </div>

        <br /><br />
        <asp:Button ID="btnBackToTop" runat="server" Text="トップページへ戻る" OnClick="btnBackToTop_Click" />

        <asp:Button ID="btnHistory" runat="server" Text="購入履歴を見る" OnClick="btnHistory_Click" />
    </form>
</body>
</html>