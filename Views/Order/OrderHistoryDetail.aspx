<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderHistoryDetail.aspx.cs" Inherits="ShoppingSite_a.Views.Order.OrderHistoryDetail" %>
<%@ Register Src="~/Header.ascx" TagPrefix="uc" TagName="MyHeader" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link href="<%= ResolveUrl("~/CSS/MyStyle.css") %>" rel="stylesheet" type="text/css" />
    <title>購入履歴詳細</title>
</head>
<body>
   <form id="form1" runat="server">
    <uc:MyHeader runat="server" ID="ucHeader" />

    <div class="page-center-wrapper">
        <div class="form-card" style="width: 100%; max-width: 800px;">
            <h2>購入履歴詳細</h2>

            <%-- ① 注文の親情報（一回きりの情報） --%>
            <div class="detail-info">
                <p>購入番号：<asp:Label ID="lblOrderId" runat="server"></asp:Label></p>
                <p>購入日時：<asp:Label ID="lblCreatedAt" runat="server"></asp:Label></p>
                <p>消費税：<asp:Label ID="lblTax" runat="server"></asp:Label> マイル</p>
                <p>合計金額：<span class="detail-total"><asp:Label ID="lblTotalPrice" runat="server"></asp:Label> マイル</span></p>
            </div>

            <hr />

            <%-- ② 注文の明細情報（商品のリスト） --%>
            <table class="history-table">
                <thead>
                    <tr>
                        <th>商品名</th>
                        <th>価格</th>
                        <th>数量</th>
                        <th>小計</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptOrderDetails" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("ProductName") %></td>
                                <td><%# Eval("Price", "{0:N0}") %> マイル</td><%--数字を3桁ごとにカンマ区切りにしてね--%>
                                <td><%# Eval("Quantity") %></td>
                                <%-- DTOで自動計算させているSubTotalをバインド --%>
                                <td><%# Eval("SubTotal", "{0:N0}") %> マイル</td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>

            <br />
            <%-- 画面遷移ボタン --%>
            <div class="btn-container-detail">
                <asp:Button ID="btnToHistory" runat="server" Text="購入履歴へ戻る" CssClass="btn-detail" OnClick="btnToHistory_Click" />
                <asp:Button ID="btnToTop" runat="server" Text="トップページへ戻る" CssClass="btn-detail btn-logout" OnClick="btnToTop_Click" />
            </div>
        </div>
    </div>
</form>
</body>
</html>
