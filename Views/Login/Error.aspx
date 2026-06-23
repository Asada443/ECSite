<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="ShoppingSite_a.Error" %>
<%@ Register Src="~/Header.ascx" TagPrefix="uc" TagName="MyHeader" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="<%= ResolveUrl("~/CSS/MyStyle.css") %>" rel="stylesheet" type="text/css" />
    <title>ログインエラー</title>
</head>
<body>
    <form id="form1" runat="server">
        <uc:MyHeader runat="server" ID="ucHeader" />

        <div class="page-center-wrapper">
            <div class="error-card">
                <h2>会員IDもしくはパスワードが違います</h2>
                <div class="error-actions">
                    <asp:Button ID="btnBack" runat="server" Text="ログイン画面へ戻る" OnClick="btnBack_Click" CssClass="btn-detail" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>