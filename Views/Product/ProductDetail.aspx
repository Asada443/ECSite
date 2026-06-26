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

        <div class="detail-page-wrapper">
        <div class="detail-card">
            <div class="detail-image">
                <asp:Image ID="imgProduct" runat="server" />
            </div>
            <div class="detail-info">
                <h2><asp:Label ID="lblProductName" runat="server" /></h2>
                
                <p class="price-display">価格：<span><asp:Label ID="lblPrice" runat="server" />ウチュウ</span></p>
                <p>移住先の星：<asp:Label ID="lblPlanet" runat="server" /></p>
                <p>残り個数（人数）：<asp:Label ID="lblStock" runat="server" /></p>
                
                <div class="description-area">
                    <h3>商品説明</h3>
                    <p><asp:Label ID="lblDescription" runat="server" /></p>
                    
                    <h3>この星の環境</h3>
                    <p><asp:Label ID="lblRecommendedEnvironment" runat="server" /></p>
                </div>
                <div class="action-area">
                    数量（人数）：<asp:DropDownList ID="ddlQty" runat="server" CssClass="qty-select"></asp:DropDownList>
                    <asp:Button ID="btnCart" runat="server" Text="カートに追加" OnClick="btnCart_Click" CssClass="btn-cart" />
                </div>

                <asp:Button ID="btnGoCart" runat="server" Text="カートを見る" OnClick="btnGoCart_Click" CssClass="btn-link" />
                <asp:Label ID="lblMessage" runat="server" ForeColor="Green" />
                
                <br /><br />
                <a href="/Views/Product/ProductList.aspx" class="back-link">← 商品一覧へ</a>
            </div>
          
        </div>
    </div>
    
    </form>


   
</body>
</html>
