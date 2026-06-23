<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Error.aspx.cs"
    Inherits="ShoppingSite_a.Error" %>
<%@ Register Src="~/Header.ascx" TagPrefix="uc" TagName="MyHeader" %>
<!DOCTYPE html>
<html>
<head>
    <link href="<%= ResolveUrl("~/CSS/MyStyle.css") %>" rel="stylesheet" type="text/css" />
    <title>ログインエラー</title>
</head>
<body>
    <form id="form1" runat="server">

        <uc:MyHeader runat="server" ID="ucHeader" />

        <h2>会員IDもしくはパスワードが違います</h2>

        <asp:Button
            ID="btnBack"
            runat="server"
            Text="ログイン画面へ戻る"
            OnClick="btnBack_Click" />

    </form>
</body>