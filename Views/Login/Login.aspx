<%@ Page Language="C#" AutoEventWireup="true"
CodeBehind="Login.aspx.cs"
Inherits="ShoppingSite_a.Login" %>
<%@ Register Src="~/Header.ascx" TagPrefix="uc" TagName="MyHeader" %>

<!DOCTYPE html>
<html>
<head>
    <link href="<%= ResolveUrl("~/CSS/MyStyle.css") %>" rel="stylesheet" type="text/css" />
    <title>ログイン</title>
</head>
<body>

    <form id="form1" runat="server" novalidate="novalidate">    

        <uc:MyHeader runat="server" ID="ucHeader" />

    <div class="page-center-wrapper">
        <div class="form-card">
            <h2>ログイン</h2>
            
            <asp:ValidationSummary ID="valSummary" runat="server" ForeColor="Red" />
            <asp:Label ID="lblError" runat="server" ForeColor="Red" />

            <div class="form-group">
                <asp:Label ID="lblMemberId" runat="server" Text="会員ID：" />
                <asp:TextBox ID="txtMemberId" runat="server" CssClass="input-field" autocomplete="off" />
                <asp:RequiredFieldValidator ID="rfvMemberId" runat="server" ControlToValidate="txtMemberId" ErrorMessage="会員IDを入力してください" ForeColor="Red" Display="Dynamic" Text="*" />
            </div>

            <div class="form-group">
                <asp:Label ID="lblPassword" runat="server" Text="パスワード：" />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="input-field" autocomplete="new-password" />
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="パスワードを入力してください" ForeColor="Red" Display="Dynamic" Text="*" />
            </div>

            <asp:Button ID="btnLogin" runat="server" Text="ログイン" OnClick="btnLogin_Click" CssClass="btn-detail" />
            
            <div class="form-footer">
                <asp:HyperLink ID="lnkRegister" runat="server" NavigateUrl="~/Views/Member/Register.aspx" Text="新規会員登録はこちら" />
            </div>
        </div>
    </div>


    </form>

</body>
</html>