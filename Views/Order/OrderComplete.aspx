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
      <div class="page-center-wrapper">
        <div class="form-card complete-card">
            <h2 class="complete-title">ご購入ありがとうございました！</h2>
            <p>移住チケットの確保が完了いたしました。</p>

            <div class="order-complete-box">
                <p><strong>購入番号：</strong> <asp:Label ID="lblOrderId" runat="server" /></p>
                <hr />
                
                <asp:Repeater ID="rptDetails" runat="server">
                    <ItemTemplate>
                        <div class="complete-item">
                            ・<%# Eval("ProductName") %> × <%# Eval("Quantity") %>個 
                            （<%# Eval("SubTotal") %> 円）
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <hr />
                <p>消費税： <asp:Label ID="lblTax" runat="server" /> 円</p>
                <p class="complete-total">合計金額： <asp:Label ID="lblTotal" runat="server" /> 円</p>
            </div>

            <div class="form-actions">
                <asp:Button ID="btnBackToTop" runat="server" Text="トップへ戻る" OnClick="btnBackToTop_Click" CssClass="btn-detail" />
                <asp:Button ID="btnHistory" runat="server" Text="購入履歴を見る" OnClick="btnHistory_Click" CssClass="btn-logout" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>