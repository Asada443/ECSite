<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="ShoppingSite_a.Member.Delete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
           <h2>会員情報削除</h2>

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
            本当に削除しますか？
        </p>

        <asp:Button
            ID="btnDelete"
            runat="server"
            Text="削除する"
            OnClick="btnDelete_Click" />

        <asp:Button
            ID="btnBack"
            runat="server"
            Text="戻る"
            OnClick="btnBack_Click" />

    </form>
</body>
</html>
