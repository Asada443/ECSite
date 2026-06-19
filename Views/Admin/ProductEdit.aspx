<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductEdit.aspx.cs" Inherits="ShoppingSite_a.Views.Admin.ProductEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>商品情報の編集・詳細</h2>

            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" EnableViewState="false"></asp:Label>
            <br />
            <br />

            <%-- 非表示で商品IDを裏側に持たせておくための仕掛け --%>
            <asp:HiddenField ID="hfProductId" runat="server" />

            <table border="0">
                <tr>
                    <td>商品名：</td>
                    <td>
                        <asp:TextBox ID="txtProductName" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>価格：</td>
                    <td>
                        <asp:TextBox ID="txtPrice" runat="server" Width="150px"></asp:TextBox> 円
                    </td>
                </tr>
                <tr>
                    <td>移住枠：</td>
                    <td>
                        <asp:TextBox ID="txtStock" runat="server" TextMode="Number" Width="100px"></asp:TextBox> 個
                    </td>
                </tr>
                <tr>
                    <td>星：</td>
                    <td>
                        <asp:TextBox ID="txtPlanet" runat="server" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>商品説明：</td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="4" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>星の環境：</td>
                    <td>
                        <asp:DropDownList ID="ddlRecommendedEnvironment" runat="server">
                            <asp:ListItem Text="選択してください" Value="" />
                            <asp:ListItem Text="自然豊か" Value="自然豊か" />
                            <asp:ListItem Text="都市型" Value="都市型" />
                            <asp:ListItem Text="寒冷" Value="寒冷" />
                            <asp:ListItem Text="温暖" Value="温暖" />
                            <asp:ListItem Text="乾燥" Value="乾燥" />
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>

            <br />
            <asp:Button ID="btnUpdate" runat="server" Text="この内容で更新する" OnClick="btnUpdate_Click" />
            &nbsp;&nbsp;
           
            <asp:Button ID="btnBack" runat="server" Text="商品管理一覧に戻る" OnClick="btnBack_Click" UseSubmitBehavior="false" />
        </div>
    </form>
</body>
</html>
