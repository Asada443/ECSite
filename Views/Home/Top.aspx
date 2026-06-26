<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="ShoppingSite_a.Views.Home.Top" %>
<%@ Register Src="~/Header.ascx" TagPrefix="uc" TagName="MyHeader" %>
<!DOCTYPE html><html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="<%= ResolveUrl("~/CSS/MyStyle.css") %>" rel="stylesheet" type="text/css" />
    <title>宇宙移住センター - トップ</title>
</head>

<body>
    <form id="form1" runat="server">
        <uc:MyHeader runat="server" ID="ucHeader" />


        <div class="top-page-wrapper">
        <h3 class="top-list-title"><asp:Label ID="lblListTitle" runat="server" Text="商品一覧" ></asp:Label></h3>
        <asp:Label ID="lblNoProductsMessage" runat="server" ForeColor="Gray" Visible="false"></asp:Label>

        <div class="top-product-grid">
            <asp:Repeater ID="rptProducts" runat="server">
                <ItemTemplate>
                    <div class="top-product-card">
                        <div class="top-product-image">
                            <asp:Image ID="imgProduct" runat="server" 
                                ImageUrl='<%# ResolveUrl(Eval("ImagePath").ToString()) %>' 
                                AlternateText='<%# Eval("ProductName") %>' />
                        </div>
                        <div class="top-card-body">
                            <a href='<%# ResolveUrl("~/Views/Product/ProductDetail.aspx?id=" + Eval("ProductId")) %>' class="top-product-link">
                                <%# Eval("ProductName") %>
                            </a>
                           <%-- <div class="top-product-info">
                                移住先の星：<strong><%# Eval("Planet") %></strong><br />
                                環境：<%# Eval("RecommendedEnvironment") %><br />
                                価格：<%# String.Format("{0:N0}", Eval("Price")) %> ウチュウ <br />
                                残り移住枠：<%# Eval("Stock") %> 個（人数）
                            </div>--%>
                            <div class="top-product-info">
                                   <dl class="product-info-dl">
                                     <dt>移住先の星：</dt>
                                     <dd><strong><%# Eval("Planet") %></strong></dd>

                                     <dt>環境：</dt>
                                     <dd><%# Eval("RecommendedEnvironment") %></dd>

                                     <dt>価格：</dt>
                                     <dd><%# String.Format("{0:N0}", Eval("Price")) %> ウチュウ</dd>

                                     <dt>残り移住枠：</dt>
                                     <dd><%# Eval("Stock") %> （人）</dd>
                                  </dl>
                            </div>

                            <div class="top-product-desc">
                                <%# Eval("Description") %>
                            </div>
                            <a href='<%# ResolveUrl("~/Views/Product/ProductDetail.aspx?id=" + Eval("ProductId")) %>' class="top-btn-detail">詳細を見る</a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
            
            
    </form>
</body>
</html>