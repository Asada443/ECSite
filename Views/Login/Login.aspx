<%@ Page Language="C#" AutoEventWireup="true"
CodeBehind="Login.aspx.cs"
Inherits="ShoppingSite_a.Login" %>

<!DOCTYPE html>
<html>
<head>
    <title>ログイン</title>
</head>
<body>

    <form id="form1" runat="server">    

        <h2>ログイン</h2>

        <div>
            会員ID：
            <asp:TextBox ID="txtMemberId" runat="server" autocomplete="off" />
        </div>

        <div>
            パスワード：
            <asp:TextBox ID="txtPassword"
                runat="server"
                TextMode="Password" 
               autocomplete="new-password" />
        </div>

        <br />

        <asp:Button ID="btnLogin"
            runat="server"
            Text="ログイン"
            OnClick="btnLogin_Click"
            />  

        <a href="~/Views/Member/Register.aspx">新規会員登録はこちら</a>

        <br /><br />

        <asp:Label ID=
            "lblError"
            runat="server"
            ForeColor="Red"/>

    </form>

</body>
</html>