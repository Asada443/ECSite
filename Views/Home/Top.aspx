<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="ShoppingSite_a.Views.Home.Top" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="txtKeyword" runat="server" />
        <asp:Button
             ID="btnSearch"
             runat="server"
             Text="検索"
             OnClick ="btnSearch_Click"  />
        <asp:Button
             ID="btnProductList"
             runat="server"
             Text="商品一覧"
             OnClick="btnProductList_Click" />
    </form>
</body>
</html>
