<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="ShoppingSite_a.Views.Order.OrderHitory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link href="<%= ResolveUrl("~/CSS/MyStyle.css") %>" rel="stylesheet" type="text/css" />
    <title>購入履歴</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-center-wrapper">
            <div class="form-card">
        <h2>購入履歴一覧</h2>

        <table class="history-table">
            <thead>
                <tr>
                    <th>購入日時</th>
                    <th>購入金額</th>
                    <th>詳細</th>
                </tr>
            </thead>
            <tbody>
                
                <asp:Repeater ID="rptOrderHistory" runat="server" OnItemCommand="rptOrderHistory_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <%-- 購入日時のバインド --%>
                            <td><%# Eval("CreatedAt", "{0:yyyy/MM/dd HH:mm}") %></td>
                            
                            <%-- 購入金額のバインド --%>
                            <td><%# Eval("TotalPrice", "{0:N0}") %> マイル</td>
                            
                            <%-- 詳細ボタン (CommandArgumentにOrderIdを仕込む) --%>
                            <td>
                                <asp:Button ID="btnDetail" runat="server" Text="詳細を見る" CssClass="btn-detail"
                                            CommandName="ShowDetail" 
                                            CommandArgument='<%# Eval("OrderId") %>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>

        <div class="btn-container">
            <asp:Button ID="btnToTop" runat="server" Text="トップページへ戻る" CssClass="btn-detail btn-logout" OnClick="btnToTop_Click" />
        </div>


        </div>

       </div>


    </form>
</body>
</html>
