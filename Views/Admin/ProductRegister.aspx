<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductRegister.aspx.cs" Inherits="ShoppingSite_a.Views.Admin.ProductRegister" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="<%= ResolveUrl("~/CSS/MyStyle.css") %>" rel="stylesheet" type="text/css" />
    <title>商品新規登録</title>
</head>
<body>
    <form id="form1" runat="server">
      
    <div class="page-center-wrapper">
        <div class="form-card" style="max-width: 600px;">
            <h2>商品新規登録</h2>
            
            <asp:ValidationSummary ID="valSummary" runat="server" CssClass="validation-summary" ForeColor="Red" HeaderText="入力内容に不備があります：" />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" EnableViewState="false"></asp:Label>

            <table class="form-table">
                <tr>
                    <td class="input-label">商品名：</td>
                    <td>
                        <asp:TextBox ID="txtProductName" runat="server" CssClass="input-field"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="input-label">価格：</td>
                    <td>
                        <asp:TextBox ID="txtPrice" runat="server" CssClass="input-field"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="input-label">移住枠（在庫）：</td>
                    <td>
                        <asp:TextBox ID="txtStock" runat="server" CssClass="input-field"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="input-label">星：</td>
                    <td>
                        <asp:TextBox ID="txtPlanet" runat="server" CssClass="input-field"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="input-label">商品説明：</td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="4" CssClass="input-field"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="input-label">星の環境：</td>
                    <td>
                        <asp:DropDownList ID="ddlRecommendedEnvironment" runat="server" CssClass="input-field">
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

            <div class="register-form-actions">
                <asp:Button ID="btnRegister" runat="server" Text="この内容で登録する" CssClass="btn-detail" OnClick="btnRegister_Click" />
                <asp:Button ID="btnBack" runat="server" Text="商品管理一覧に戻る" CssClass="btn-detail btn-logout" OnClick="btnBack_Click" CausesValidation="false" />
            </div>
        </div>
    </div>

    </form>
</body>
</html>