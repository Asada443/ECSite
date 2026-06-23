<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditComplete.aspx.cs" Inherits="ShoppingSite_a.Member.EditComplete" %>
<%@ Register Src="~/Header.ascx" TagPrefix="uc" TagName="MyHeader" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link href="<%= ResolveUrl("~/CSS/MyStyle.css") %>" rel="stylesheet" type="text/css" />
    <title>会員情報修正完了</title>
</head>
<body>
    <form id="form1" runat="server">
        <uc:MyHeader runat="server" ID="ucHeader" />
        <h2>会員情報の修正が完了しました</h2>
         <asp:Button
            ID="btnHome"
            runat="server"
            Text="ホーム画面へ戻る"
            OnClick="btnHome_Click" />

    </form>
</body>
</html>
