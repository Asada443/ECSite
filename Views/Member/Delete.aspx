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
           <h2>宇宙会員情報 削除確認</h2>

        <%-- 宇宙会員ID --%>
        <p>
            宇宙会員ID：
            <asp:Label ID="lblUserId" runat="server" />
        </p>

        <%-- お名前 --%>
        <p>
            お名前：
            <asp:Label ID="lblUserName" runat="server" />
        </p>

        <p style="color: red; font-weight: bold;">
            本当にこの宇宙会員データを全宇宙から完全に削除しますか？（元には戻せません）
        </p>

        <asp:Button ID="btnDelete" runat="server" Text="完全に削除する" OnClick="btnDelete_Click" />
        <asp:Button ID="btnBack" runat="server" Text="戻る" OnClick="btnBack_Click" />

    </form>
</body>
</html>
