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
    <div class="page-center-wrapper">
        <div class="form-card" style="max-width: 700px;">
            <h2>購入内容の確認</h2>
            <p>以下の内容で注文を確定してもよろしいですか？</p>

            <table class="cart-table">
                <thead>
                    <tr>
                        <th>商品名</th>
                        <th>数量（人数）</th>
                        <th>単価</th>
                        <th>小計</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptConfirm" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("ProductName") %></td>
                                <td><%# Eval("Quantity") %></td>
                                <td><%# Eval("Price") %> ウチュウ</td>
                                <td><%# Eval("SubTotal") %> ウチュウ</td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>

            <div class="confirm-summary">
                <p>+消費税 (10%)： <span><asp:Label ID="lblTax" runat="server" /> ウチュウ</span></p>
                <p class="total-line">合計金額： <span><asp:Label ID="lblTotal" runat="server" /> ウチュウ</span></p>
            </div>

            <div class="form-actions">
                <asp:Button ID="btnConfirm" runat="server" Text="購入を確定する" OnClick="btnConfirm_Click" 
                    CssClass="btn-detail" OnClientClick="return confirm('購入を確定します。よろしいですか？');" />
                <asp:Button ID="btnCancel" runat="server" Text="キャンセル" OnClick="btnCancel_Click" 
                    CssClass="btn-logout" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>