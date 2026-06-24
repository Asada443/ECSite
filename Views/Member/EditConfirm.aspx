<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditConfirm.aspx.cs" Inherits="ShoppingSite_a.Member.EditConfirm" %>
<%@ Register Src="~/Header.ascx" TagPrefix="uc" TagName="MyHeader" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <link href="<%= ResolveUrl("~/CSS/MyStyle.css") %>" rel="stylesheet" type="text/css" />
    <title>会員情報 修正内容確認</title>
</head>
<body>
    <form id="form1" runat="server">
        <uc:MyHeader runat="server" ID="ucHeader" />

        <div class="page-center-wrapper">
        <div class="form-card">
            <h2>会員情報 修正内容確認</h2>
            <p>以下の内容に修正します。よろしいですか？</p>

            <div class="confirm-info">
                <p>会員ID：<strong><asp:Label ID="lblUserId" runat="server" /></strong></p>
                <p>お名前：<strong><asp:Label ID="lblUserName" runat="server" /></strong></p>
                <p>故郷の星：<strong><asp:Label ID="lblHometownPlanet" runat="server" /></strong></p>
                <p>ご希望の移住環境：<strong><asp:Label ID="lblRecommendedEnvironment" runat="server" /></strong></p>
            </div>

            <div class="form-actions">
                <asp:Button ID="btnUpdate" runat="server" Text="この内容で修正する" OnClick="btnUpdate_Click" OnClientClick="return confirm('この修正内容内容で登録します。よろしいですか？');"　CssClass="btn-detail" />
                <asp:Button ID="btnBack" runat="server" Text="書き直す（戻る）" OnClick="btnBack_Click" CssClass="btn-detail" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>