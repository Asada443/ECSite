<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" Inherits="ShoppingSite_a.Member.Confirm" %>
<%@ Register Src="~/Header.ascx" TagPrefix="uc" TagName="MyHeader" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link href="<%= ResolveUrl("~/CSS/MyStyle.css") %>" rel="stylesheet" type="text/css" />
    <title>登録内容確認</title>
</head>
<body>
    <form id="form1" runat="server">
        <uc:MyHeader runat="server" ID="ucHeader" />
         <h2>会員 登録内容確認</h2>
         <p>以下の内容で登録します。よろしいですか？</p>

        <%-- 宇宙会員ID --%>
        <p>
            会員ID：
            <asp:Label ID="lblUserId" runat="server" />
        </p>

        <%-- お名前 --%>
        <p>
            お名前：
            <asp:Label ID="lblUserName" runat="server" />
        </p>

        <%--  故郷の星 --%>
        <p>
            故郷の星：
            <asp:Label ID="lblHometownPlanet" runat="server" />
        </p>

        <%-- ご希望の移住環境 --%>
        <p>
            ご希望の移住環境：
            <asp:Label ID="lblRecommendedEnvironment" runat="server" />
        </p>
       
        <br />
        <asp:Button ID="btnRegister" runat="server" Text="この内容で登録する" OnClick="btnRegister_Click" />
        <asp:Button ID="btnBack" runat="server" Text="修正する（戻る）" OnClick="btnBack_Click" />

    </form>
</body>
</html>
