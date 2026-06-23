<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductEdit.aspx.cs" Inherits="ShoppingSite_a.Views.Admin.ProductEdit" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="<%= ResolveUrl("~/CSS/MyStyle.css") %>" rel="stylesheet" type="text/css" />
    <title>商品情報編集</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>商品情報の編集・詳細</h2>
            <asp:ValidationSummary ID="valSummary" runat="server" ForeColor="Red" HeaderText="入力内容に不備があります：" />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" EnableViewState="false"></asp:Label>
            <br />

            <asp:HiddenField ID="hfProductId" runat="server" />

            <table border="0">
                <tr>
                    <td>商品名：</td>
                    <td>
                        <asp:TextBox ID="txtProductName" runat="server" Width="300px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtProductName" ErrorMessage="商品名を入力してください" Text="*" ForeColor="Red" />
                    </td>
                </tr>
                <tr>
                    <td>価格：</td>
                    <td>
                        <asp:TextBox ID="txtPrice" runat="server" Width="150px"></asp:TextBox> 円
                        <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ControlToValidate="txtPrice" ErrorMessage="価格を入力してください" Text="*" ForeColor="Red" />
                        <asp:CompareValidator ID="cvPrice" runat="server" ControlToValidate="txtPrice" Operator="DataTypeCheck" Type="Integer" ErrorMessage="価格は数値で入力してください" Text="*" ForeColor="Red" />
                    </td>
                </tr>
                <tr>
                    <td>移住枠（在庫）：</td>
                    <td>
                        <asp:TextBox ID="txtStock" runat="server" Width="100px"></asp:TextBox> 個
                        <asp:RequiredFieldValidator ID="rfvStock" runat="server" ControlToValidate="txtStock" ErrorMessage="在庫数を入力してください" Text="*" ForeColor="Red" />
                        <asp:CompareValidator ID="cvStock" runat="server" ControlToValidate="txtStock" Operator="DataTypeCheck" Type="Integer" ErrorMessage="在庫数は数値で入力してください" Text="*" ForeColor="Red" />
                    </td>
                </tr>
                <tr>
                    <td>星：</td>
                    <td>
                        <asp:TextBox ID="txtPlanet" runat="server" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPlanet" runat="server" ControlToValidate="txtPlanet" ErrorMessage="星の名前を入力してください" Text="*" ForeColor="Red" />
                    </td>
                </tr>
                <tr>
                    <td>商品説明：</td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="4" Width="300px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDesc" runat="server" ControlToValidate="txtDescription" ErrorMessage="商品説明を入力してください" Text="*" ForeColor="Red" />
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
                        <asp:RequiredFieldValidator ID="rfvEnv" runat="server" ControlToValidate="ddlRecommendedEnvironment" InitialValue="" ErrorMessage="環境を選択してください" Text="*" ForeColor="Red" />
                    </td>
                </tr>
            </table>

            <br />
            <asp:Button ID="btnUpdate" runat="server" Text="この内容で更新する" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnBack" runat="server" Text="商品管理一覧に戻る" OnClick="btnBack_Click" CausesValidation="false" />
        </div>
    </form>
</body>
</html>
