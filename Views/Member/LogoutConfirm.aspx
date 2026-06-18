<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogoutConfirm.aspx.cs" Inherits="ShoppingSite_a.Member.LogoutConfirm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ログアウト確認画面</title>
</head>
<body>
    <form id="form1" runat="server">
     <h1>
         ログアウトしますか
     </h1>

     
         <asp:Button
     ID="btnYes"
     runat="server"
     Text="はい"
     OnClick="btnYes_Click" />

 <asp:Button
     ID="btnNO"
     runat="server"
     Text="いいえ"
     OnClick="btnNo_Click" />
    </form>
</body>
</html>
