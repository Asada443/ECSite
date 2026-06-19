<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="ShoppingSite_a.Views.Home.Top" %>

<!DOCTYPE html><html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>宇宙移住ナビ - トップ</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtKeyword" runat="server" />
            <asp:Button ID="btnSearch" runat="server" Text="検索" OnClick ="btnSearch_Click"  />
            <asp:Button ID="btnProductList" runat="server" Text="商品一覧" OnClick="btnProductList_Click" />
            
            &nbsp;&nbsp;&nbsp;&nbsp; <asp:Panel ID="pnlGuestHeader" runat="server" RenderOuterTable="false">
                <asp:Button ID="btnLogin" runat="server" Text="ログイン" OnClick="btnLogin_Click" />
            </asp:Panel>

            <asp:Panel ID="pnlMemberHeader" runat="server" RenderOuterTable="false">
                <asp:Label ID="lblWelcome" runat="server" Text="ようこそ、〇〇さん！" Font-Bold="true"></asp:Label>
                &nbsp;
                <asp:Button ID="btnMyPage" runat="server" Text="マイページ" OnClick="btnMyPage_Click" />
                &nbsp;
                <asp:Button ID="btnLogout" runat="server" Text="ログアウト" OnClick="btnLogout_Click" />
            </asp:Panel>
            
            <hr /> <br />

            <h3><asp:Label ID="lblListTitle" runat="server" Text="商品一覧"></asp:Label></h3>

            <asp:Label ID="lblNoProductsMessage" runat="server" ForeColor="Gray" Visible="false"></asp:Label>

            <asp:Repeater ID="rptProducts" runat="server">
                <HeaderTemplate>
                    <table border="1" style="border-collapse: collapse; width: 800px;" cellpadding="10">
                </HeaderTemplate>
                
                <ItemTemplate>
                    <tr>
                        <td style="width: 120px; text-align: center;">
                            <span style="font-size: 12px; color: #ccc;">[画像]</span>
                        </td>
                        <td>
                           <a href='<%# ResolveUrl("~/Views/Product/ProductDetail.aspx?id=" + Eval("ProductId")) %>' style="font-weight: bold; font-size: 16px; color: blue;">
                                <%# Eval("ProductName") %>
                            </a>
                            <br /><br />
                            移住先の星：<strong><%# Eval("Planet") %></strong> 
                            （環境：<%# Eval("RecommendedEnvironment") %>）
                            <br />
                            価格：<%# String.Format("{0:N0}", Eval("Price")) %> 円 
                            / 移住枠残り：<%# Eval("Stock") %> 個
                            <br /><br />
                            <small><%# Eval("Description") %></small>
                        </td>
                        <td style="width: 100px; text-align: center;">
                          <a href='<%# ResolveUrl("~/Views/Product/ProductDetail.aspx?id=" + Eval("ProductId")) %>' style="display: inline-block; padding: 5px 10px; background-color: #f0f0f0; border: 1px solid #ccc; text-decoration: none; color: black; font-size: 12px;">詳細を見る</a>
                        </td>
                    </tr>
                </ItemTemplate>
                
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            
            </div>
    </form>
</body>
</html>