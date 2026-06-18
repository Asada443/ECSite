<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditComplete.aspx.cs" Inherits="ShoppingSite_a.Member.EditComplete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>会員情報の修正が完了しました</h2>
         <asp:Button
            ID="btnHome"
            runat="server"
            Text="ホーム画面へ戻る"
            OnClick="btnHome_Click" />

    </form>
</body>
</html>
