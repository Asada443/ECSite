<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditConfirm.aspx.cs" Inherits="ShoppingSite_a.Member.EditConfirm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>修正内容確認</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>修正内容確認</h2>

        <p>
            会員ID：
           
            <asp:Label ID="lblMemberId" runat="server" />
        </p>

        <p>
            姓：
           
            <asp:Label ID="lblLastName" runat="server" />
        </p>

        <p>
            名：
           
            <asp:Label ID="lblFirstName" runat="server" />
        </p>

        <p>
            住所：
           
            <asp:Label ID="lblAddress" runat="server" />
        </p>

        <p>
            メールアドレス：
           
            <asp:Label ID="lblMailAddress" runat="server" />
        </p>

        <p>
            故郷の星：
    <asp:Label ID="lblHomePlanet" runat="server" />
        </p>

        <p>
            好みの環境：
    <asp:Label ID="lblPreferredEnvironment" runat="server" />
        </p>

        <asp:Button
            ID="btnUpdate"
            runat="server"
            Text="修正する"
            OnClick="btnUpdate_Click" />

        <asp:Button
            ID="btnBack"
            runat="server"
            Text="戻る"
            OnClick="btnBack_Click" />

    </form>
</body>
</html>
