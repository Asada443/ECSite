<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs"
    Inherits="ShoppingSite_a.Home" %>

<form id="form1" runat="server">

    <h2>ようこそ、
   
        <asp:Label ID="lblLastName" runat="server" />
        さん！</h2>

    <asp:Button
        ID="btnEdit"
        runat="server"
        Text="修正"
        OnClick="btnEdit_Click" />

    <asp:Button
        ID="btnDelete"
        runat="server"
        Text="削除"
        OnClick="btnDelete_Click" />

    <asp:Button
        ID="btnLogout"
        runat="server"
        Text="ログアウト"
        OnClick="btnLogout_Click" />

    <asp:Button
        ID="btnProductManage"
        runat="server"
        Text="商品管理"
        Visible="false"
        Onclick="btnProductManage_Click" />

</form>
