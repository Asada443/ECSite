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

    <form id="form1" runat="server">    

        <uc:MyHeader runat="server" ID="ucHeader" />

    <div class="page-center-wrapper">
        <div class="form-card">
            <h2>ログイン</h2>

            <div class="form-group">
                <asp:Label ID="lblMemberId" runat="server" Text="会員ID：" />
                <asp:TextBox ID="txtMemberId" runat="server" CssClass="input-field" autocomplete="off" />
            </div>

            <div class="form-group">
                <asp:Label ID="lblPassword" runat="server" Text="パスワード：" />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="input-field" autocomplete="new-password" />
            </div>

            <asp:Button ID="btnLogin" runat="server" Text="ログイン" OnClick="btnLogin_Click" CssClass="btn-detail" />
            
            <div class="form-footer">
                <asp:HyperLink ID="lnkRegister" runat="server" NavigateUrl="~/Views/Member/Register.aspx" Text="新規会員登録はこちら" />
            </div>

            <asp:Label ID="lblError" runat="server" ForeColor="Red" />
        </div>
    </div>

    </form>

</body>
</html>