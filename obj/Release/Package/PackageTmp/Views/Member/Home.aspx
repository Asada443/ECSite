<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ShoppingSite_a.Home" %>
<%@ Register Src="~/Header.ascx" TagPrefix="uc" TagName="MyHeader" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link href="<%= ResolveUrl("~/CSS/MyStyle.css") %>" rel="stylesheet" type="text/css" />
    <title>マイページ</title>
</head>
<body>
    <form id="form1" runat="server">
        <uc:MyHeader runat="server" ID="ucHeader" />
      <div class="page-center-wrapper">
    <div class="form-card">
        <h2>マイページ</h2>
        <p>ようこそ、<asp:Label ID="lblUserName" runat="server" /> さん！</p>
        
        <div class="mypage-menu">
            <asp:Button ID="btnEdit" runat="server" Text="会員情報修正" OnClick="btnEdit_Click" CssClass="btn-detail" />
            <asp:Button ID="btnHistory" runat="server" Text="購入履歴を見る" OnClick="btnHistory_Click" Visible="false" CssClass="btn-detail" />
            <asp:Button ID="btnProductManage" runat="server" Text="商品管理" Visible="false" OnClick="btnProductManage_Click" CssClass="btn-detail" />
            <asp:Button ID="btnDelete" runat="server" Text="退会する" OnClick="btnDelete_Click" CssClass="btn-detail btn-danger" />
            
            <asp:Button ID="btnLogout" runat="server" Text="ログアウト" OnClick="btnLogout_Click" CssClass="btn-detail btn-logout" />
        </div>
    </div>
</div>
    </form>
</body>
</html>