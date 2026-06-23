<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogoutConfirm.aspx.cs" Inherits="ShoppingSite_a.Member.LogoutConfirm" %>
<%@ Register Src="~/Header.ascx" TagPrefix="uc" TagName="MyHeader" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link href="<%= ResolveUrl("~/CSS/MyStyle.css") %>" rel="stylesheet" type="text/css" />
    <title>ログアウト確認画面</title>
</head>
<body>
    <form id="form1" runat="server">
        <uc:MyHeader runat="server" ID="ucHeader" />
     <h1>
         ログアウトしますか
     </h1>

     
         <asp:Button
     ID="btnYes"
     runat="server"
     Text="はい"
     OnClick="btnYes_Click" />

 <asp:Button
     ID="btnNO"
     runat="server"
     Text="いいえ"
     OnClick="btnNo_Click" />
    </form>
</body>
</html>
