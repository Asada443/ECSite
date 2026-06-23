<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Complete.aspx.cs" Inherits="ShoppingSite_a.Member.Complete" %>
<%@ Register Src="~/Header.ascx" TagPrefix="uc" TagName="MyHeader" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link href="<%= ResolveUrl("~/CSS/MyStyle.css") %>" rel="stylesheet" type="text/css" />
    <title>登録完了</title>
</head>
<body>

    <form id="form1" runat="server">
        <uc:MyHeader runat="server" ID="ucHeader" />
         <h2>登録が完了しました</h2>
    <asp:Button
    ID="btnLogin"
    runat="server"
    Text="ログイン画面へ"
    OnClick="btnLogin_Click" />
    </form>
</body>
</html>
