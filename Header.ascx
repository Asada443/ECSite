<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="ShoppingSite_a.Header" %>

<div class="header-container">
    <div class="header-logo">宇宙移住センター</div>

    <div class="header-nav">
        <asp:Button ID="btnProductList" runat="server" Text="商品一覧" OnClick="btnProductList_Click" CssClass="btn-detail" />
        
        <asp:Panel ID="pnlGuestHeader" runat="server" RenderOuterTable="false" CssClass="nav-group">
            <asp:Button ID="btnLogin" runat="server" Text="ログイン" OnClick="btnLogin_Click" CssClass="btn-detail" />
        </asp:Panel>
        
        <asp:Panel ID="pnlMemberHeader" runat="server" RenderOuterTable="false" CssClass="nav-group">
            <asp:Label ID="lblWelcome" runat="server" Text="ようこそ、〇〇さん！" Font-Bold="true"></asp:Label>
            <asp:Button ID="btnMyPage" runat="server" Text="マイページ" OnClick="btnMyPage_Click" CssClass="btn-detail" />
            <asp:Button ID="btnLogout" runat="server" Text="ログアウト" OnClick="btnLogout_Click" CssClass="btn-detail" />
        </asp:Panel>

        <div class="search-box">
            <asp:TextBox ID="txtKeyword" runat="server" CssClass="search-input"/>
            <asp:Button ID="btnSearch" runat="server" Text="検索" OnClick="btnSearch_Click" CssClass="btn-detail" />
        </div>
    </div>
</div>