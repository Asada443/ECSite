<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductManage.aspx.cs" Inherits="ShoppingSite_a.Views.Admin.ProductManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>商品管理メニュー</h2>

        <asp:Button ID="btnNewProduct" runat="server" Text="+ 新規商品を登録する" OnClick="btnNewProduct_Click" />
        <br /><br />

        <h3>登録商品一覧</h3>

        <table border="1" style="border-collapse: collapse; width: 100%;">
                <thead>
                    <tr style="background-color: #eee;">
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
                                <td><%# string.Format("{0:C}", Eval("Price")) %></td>
                                <td><%# Eval("Stock") %> 個</td>
                                <td>
                                    <asp:Button ID="btnEdit" runat="server" Text="編集" 
                                                CommandName="EditProduct" 
                                                CommandArgument='<%# Eval("ProductId") %>' />
                                    
                                    <asp:Button ID="btnDelete" runat="server" Text="削除" 
                                                CommandName="DeleteProduct" 
                                                CommandArgument='<%# Eval("ProductId") %>' 
                                                OnClientClick="return confirm('本当にこの商品を削除しますか？');" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            
            <br />
            <asp:Button ID="btnBackToTop" runat="server" Text="マイページへ戻る" OnClick="btnBackToTop_Click" />
        
        <asp:Label ID ="lblMessage" runat="server" ForeColor="Red" EnableViewState="false"></asp:Label>
    </form>
</body>
</html>
