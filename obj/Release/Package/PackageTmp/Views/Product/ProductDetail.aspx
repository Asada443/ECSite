<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="ShoppingSite_a.Views.Product.ProductDetail" %>
<%@ Register Src="~/Header.ascx" TagPrefix="uc" TagName="MyHeader" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link href="<%= ResolveUrl("~/CSS/MyStyle.css") %>" rel="stylesheet" type="text/css" />
    <title>商品詳細</title>
</head>
<body>
    <form id="form1" runat="server">
        <uc:MyHeader runat="server" ID="ucHeader" />
        <h2>商品詳細</h2>

        <asp:Image ID="imgProduct" runat="server" Width="300px" />
<br /><br />

商品名：
<asp:Label ID="lblProductName" runat="server" />
<br /><br />

価格：
<asp:Label ID="lblPrice" runat="server" />
円
<br /><br />

移住先の星：
<asp:Label ID="lblPlanet" runat="server" />
<br /><br />

残り移住枠：
<asp:Label ID="lblStock" runat="server" />
<br /><br />

説明：
<br />
<asp:Label ID="lblDescription" runat="server" />
<br /><br />

推奨環境：
<br />
<asp:Label ID="lblRecommendedEnvironment" runat="server" />
<br /><br />

数量：
<asp:DropDownList ID="ddlQty" runat="server">
</asp:DropDownList>

<br /><br />
<asp:Button ID="btnCart" runat="server" Text="カートに追加" OnClick="btnCart_Click"  />
<asp:Button ID="btnGoCart" runat="server"
    Text="カートを見る"
    OnClick="btnGoCart_Click" />

            <br /><br />

        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />

        <a href="/Views/Product/ProductList.aspx">
    商品一覧へ戻る
</a>
    </form>


   
</body>
</html>
