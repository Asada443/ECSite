<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="ShoppingSite_a.Member.Delete" %>
<%@ Register Src="~/Header.ascx" TagPrefix="uc" TagName="MyHeader" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="<%= ResolveUrl("~/CSS/MyStyle.css") %>" rel="stylesheet" type="text/css" />
    <title>会員情報削除</title>
</head>
<body>
    <form id="form1" runat="server">
        <uc:MyHeader runat="server" ID="ucHeader" />

        <div class="page-center-wrapper">
            <div class="form-card">
                <h2>会員情報 削除確認</h2>

                <div class="delete-info">
                    <p>会員ID：<strong><asp:Label ID="lblUserId" runat="server" /></strong></p>
                    <p>お名前：<strong><asp:Label ID="lblUserName" runat="server" /></strong></p>
                </div>

                <p class="delete-warning">
                    本当にこの会員データを完全に削除しますか？（元には戻せません）
                </p>

                <div class="form-actions">
                    <asp:Button ID="btnDelete" runat="server" Text="完全に削除する" OnClick="btnDelete_Click" OnClientClick="return confirm('会員データを削除します（元には戻せません。よろしいですか？');" CssClass="btn-detail btn-danger" />
                    <asp:Button ID="btnBack" runat="server" Text="戻る" OnClick="btnBack_Click" CssClass="btn-detail" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>