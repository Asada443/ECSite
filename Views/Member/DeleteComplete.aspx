<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteComplete.aspx.cs" Inherits="ShoppingSite_a.Member.DeleteComplete" %>
<%@ Register Src="~/Header.ascx" TagPrefix="uc" TagName="MyHeader" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="<%= ResolveUrl("~/CSS/MyStyle.css") %>" rel="stylesheet" type="text/css" />
    <title>削除完了</title>
</head>
<body>
    <form id="form1" runat="server">
        <uc:MyHeader runat="server" ID="ucHeader" />

        <div class="page-center-wrapper">
            <div class="form-card" style="text-align: center;">
                <h2>会員情報を削除しました。</h2>
                <div class="form-actions">
                    <asp:Button ID="btnLogin" runat="server" Text="ログイン画面へ" OnClick="btnLogin_Click" CssClass="btn-detail" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>