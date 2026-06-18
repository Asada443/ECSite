<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Error.aspx.cs"
    Inherits="ShoppingSite_a.Error" %>
<body>
    <form id="form1" runat="server">

        <h2>会員IDもしくはパスワードが違います</h2>

        <asp:Button
            ID="btnBack"
            runat="server"
            Text="ログイン画面へ戻る"
            OnClick="btnBack_Click" />

    </form>
</body>