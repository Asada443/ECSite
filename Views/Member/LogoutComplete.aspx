<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogoutComplete.aspx.cs" Inherits="ShoppingSite_a.Member.LogoutComplete" %>
<%@ Register Src="~/Header.ascx" TagPrefix="uc" TagName="MyHeader" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link href="<%= ResolveUrl("~/CSS/MyStyle.css") %>" rel="stylesheet" type="text/css" />
    <title>ログアウト完了画面</title>
</head>
<body>
    <form id="form1" runat="server">
        <uc:MyHeader runat="server" ID="ucHeader" />
        <h1>
            ログアウトが完了しました
        </h1>

       <a href="/Views/Login/Login.aspx">ログイン画面へ</a>
    </form>
</body>
</html>
