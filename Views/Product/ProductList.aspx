<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="ShoppingSite_a.Product.ProductList" %>
<%@ Register Src="~/Header.ascx" TagPrefix="uc" TagName="MyHeader" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link href="<%= ResolveUrl("~/CSS/MyStyle.css") %>" rel="stylesheet" type="text/css" />
    <title>商品一覧</title>
</head>
<body>
    <form id="form1" runat="server">
        <uc:MyHeader runat="server" ID="ucHeader" />

     <asp:HyperLink
    ID="hlTop"
    runat="server"
    NavigateUrl="~/Views/Home/Top.aspx"
    Text="← トップへ戻る" />
<br /><br />


<div class="page-header">
    <h2>商品一覧</h2>
<div class="sort-container">
    <asp:DropDownList ID="ddlSort" runat="server">
    <asp:ListItem Text="並び替え" Value="NEW" />
    <asp:ListItem Text="価格（安い順）" Value="PRICE_ASC" />
    <asp:ListItem Text="価格（高い順）" Value="PRICE_DESC" />
    <asp:ListItem Text="商品名（昇順）" Value="NAME_ASC" />
    <asp:ListItem Text="商品名（降順）" Value="NAME_DESC" />
</asp:DropDownList>

<asp:Button ID="btnSort" runat="server"
    Text="適用"
    OnClick="btnSort_Click" />
</div> </div>


    <!-- エラー表示（必要なら） -->
    <asp:Label ID="lblError" runat="server" ForeColor="Red" />


        <asp:Label ID="lblCount" runat="server" />
<br />

<asp:Label ID="Label1" runat="server" ForeColor="Red" />

    <br /><br />

    <div class="product-container">

    <!-- 商品一覧（Repeater） -->
    <asp:Repeater ID="rptProducts" runat="server" OnItemCommand="rptProducts_ItemCommand">

        <ItemTemplate>

             <div class="product-card"> 
                <div class="product-image">

                <asp:Image 
                ID="imgProduct" 
                runat="server"
                ImageUrl='<%# ResolveUrl(Eval("ImagePath").ToString()) %>'
                Width="200px" 
                AlternateText='<%# Eval("Planet") %>' />
                </div>
                <br />

                <!-- 商品名 -->
                <b><%# Eval("ProductName") %></b>

                <br />

                <!-- 価格 -->
                価格：<%# Eval("Price") %>円

                <br />

                <!-- 移住先の星 -->
                移住先の星：<%# Eval("Planet") %>

                <br />

                <!-- 在庫 -->
                残り移住枠：<%# Eval("Stock") %>

                <br />

                <!-- 詳細ボタン -->
            
                <asp:Button 
                    ID="btnDetail"
                    runat="server"
                    Text="詳細"
                    CssClass="btn-detail"
                    CommandName="Detail"
                    CommandArgument='<%# Eval("ProductId") %>' />
            
            </div>

        </ItemTemplate>

    </asp:Repeater>
        </div>
    </form>
</body>
</html>
