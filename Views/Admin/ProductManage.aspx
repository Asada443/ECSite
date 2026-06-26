<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductManage.aspx.cs" Inherits="ShoppingSite_a.Views.Admin.ProductManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="<%= ResolveUrl("~/CSS/MyStyle.css") %>" rel="stylesheet" type="text/css" />
    <title>商品管理</title>
</head>
<body>
    <form id="form1" runat="server">
        
    <div class="page-center-wrapper">
        <div class="form-card" style="max-width: 1000px;">
            <h2>商品管理メニュー</h2>

            <asp:Button ID="btnNewProduct" runat="server" Text="+ 新規商品を登録する" 
                        CssClass="btn-detail" OnClick="btnNewProduct_Click" />

            <h3>登録商品一覧</h3>

            <table class="manage-table">
                <thead>
                    <tr>
                        <th>商品ID</th>
                        <th>商品名</th>
                        <th>価格</th>
                        <th>在庫数</th>
                        <th>操作</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptProducts" runat="server" OnItemCommand="rptProducts_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("ProductId") %></td>
                                <td><%# Eval("ProductName") %></td>
                                <td><%# string.Format("{0:#,##0}", Eval("Price")) %>ウチュウ</td>
                                <td><%# Eval("Stock") %> </td>
                                <td>
                                    <div class="action-buttons">
                                        <asp:Button ID="btnEdit" runat="server" Text="編集" CssClass="btn-detail"
                                                    CommandName="EditProduct" CommandArgument='<%# Eval("ProductId") %>' />
                                        <asp:Button ID="btnDelete" runat="server" Text="削除" CssClass="btn-detail btn-danger"
                                                    CommandName="DeleteProduct" CommandArgument='<%# Eval("ProductId") %>' 
                                                    OnClientClick="return confirm('本当にこの商品を削除しますか？');" />
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            
            <div style="margin-top: 30px;">
                <asp:Button ID="btnBackToTop" runat="server" Text="マイページへ戻る" 
                            CssClass="btn-detail btn-logout" OnClick="btnBackToTop_Click" />
            </div>
        
            <asp:Label ID ="lblMessage" runat="server" ForeColor="Red" EnableViewState="false"></asp:Label>
        </div>
    </div>

    </form>
</body>
</html>
