<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductEdit.aspx.cs" Inherits="ShoppingSite_a.Views.Admin.ProductEdit" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="<%= ResolveUrl("~/CSS/MyStyle.css") %>" rel="stylesheet" type="text/css" />
    <title>商品情報編集</title>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <div class="page-center-wrapper">
        <div class="form-card" style="max-width: 600px;">
            <h2>商品情報の編集・詳細</h2>
            
            <asp:ValidationSummary ID="valSummary" runat="server" CssClass="validation-summary" ForeColor="Red" HeaderText="入力内容に不備があります：" />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" EnableViewState="false"></asp:Label>
            
            <asp:HiddenField ID="hfProductId" runat="server" />

            <table class="form-table">
                <tr>
                    <td class="input-label">商品名（必須）：</td>
                    <td>
                        <asp:TextBox ID="txtProductName" runat="server" CssClass="input-field"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfName" runat="server" ControlToValidate="txtProductName" ErrorMessage="商品名を入力してください" Text="*" ForeColor="Red" Display="Dynamic" />
                    </td>
                </tr>

                <tr>
            <td class="input-label">商品画像：</td>
            <td>
                <asp:Image ID="imgProduct" runat="server" Width="100px" style="display:block; margin-bottom:5px;" />
                <span class="input-hint">※画像を変更する場合のみ、以下からファイルを選択してください</span>
                <br />
                <asp:FileUpload ID="fuProductImage" runat="server" CssClass="input-field" />
                <asp:HiddenField ID="hfImagePath" runat="server" />
                 
            </td>
        </tr>
       <%-- ### ポイント解説
* **`<asp:Image ID="imgProduct" ... />`**: 現在DBに保存されているパスを `ImageUrl` に入れることで、今どんな画像かを表示します。
* **`<asp:HiddenField ID="hfImagePath" ... />`**: ユーザーが画像を「変更しなかった場合」に、現在保存されているパスを維持するために使います。--%>

                <tr>
                    <td class="input-label">価格（必須）：</td>
                    <td>
                        <asp:TextBox ID="txtPrice" runat="server" CssClass="input-field"></asp:TextBox>
                        <span class="input-hint">半角数字で入力してください</span>
                        <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ControlToValidate="txtPrice" ErrorMessage="価格を入力してください" Text="*" ForeColor="Red" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="revPrice" runat="server" ControlToValidate="txtPrice" ErrorMessage="価格は半角数字で入力してください" ValidationExpression="^\d+$" Text="*" ForeColor="Red" Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td class="input-label">移住枠（在庫）（必須）：</td>
                    <td>
                        <asp:TextBox ID="txtStock" runat="server" CssClass="input-field"></asp:TextBox>
                        <span class="input-hint">半角数字で入力してください</span>
                        <asp:RequiredFieldValidator ID="rfvStock" runat="server" ControlToValidate="txtStock" ErrorMessage="移住枠を入力してください" Text="*" ForeColor="Red" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="revStock" runat="server" ControlToValidate="txtStock" ErrorMessage="移住枠は半角数字で入力してください" ValidationExpression="^\d+$" Text="*" ForeColor="Red" Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td class="input-label">星（必須）：</td>
                    <td>
                        <asp:TextBox ID="txtPlanet" runat="server" CssClass="input-field"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPlanet" runat="server" ControlToValidate="txtPlanet" ErrorMessage="星を入力してください" Text="*" ForeColor="Red" Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td class="input-label">商品説明（必須）：</td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="4" CssClass="input-field"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription" ErrorMessage="商品説明を入力してください" Text="*" ForeColor="Red" Display="Dynamic" />
                    </td>
                </tr>
                <tr>
                    <td class="input-label">星の環境（必須）：</td>
                    <td>
                        <asp:DropDownList ID="ddlRecommendedEnvironment" runat="server" CssClass="input-field">
                            <asp:ListItem Text="選択してください" Value="" />
                            <asp:ListItem Text="自然豊か" Value="自然豊か" />
                            <asp:ListItem Text="都市型" Value="都市型" />
                            <asp:ListItem Text="寒冷" Value="寒冷" />
                            <asp:ListItem Text="温暖" Value="温暖" />
                            <asp:ListItem Text="乾燥" Value="乾燥" />
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvEnvironment" runat="server" ControlToValidate="ddlRecommendedEnvironment" InitialValue="" ErrorMessage="星の環境を選択してください" Text="*" ForeColor="Red" Display="Dynamic" />
                    </td>
                </tr>
            </table>

            <div class="register-form-actions">
                <asp:Button ID="btnUpdate" runat="server" Text="この内容で更新する" CssClass="btn-detail" OnClientClick="if (typeof(Page_ClientValidate) == 'function' && !Page_ClientValidate()) { return false; } return confirm('この内容で更新します。よろしいですか？');"  OnClick="btnUpdate_Click"   />
                <asp:Button ID="btnBack" runat="server" Text="商品管理一覧に戻る" CssClass="btn-detail btn-logout" OnClick="btnBack_Click" CausesValidation="false" />
            </div>
        </div>
    </div>
</form>
</body>
</html>
