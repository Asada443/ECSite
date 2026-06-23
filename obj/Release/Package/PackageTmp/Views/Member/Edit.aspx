<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="ShoppingSite_a.Member.Edit" %>
<%@ Register Src="~/Header.ascx" TagPrefix="uc" TagName="MyHeader" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <link href="<%= ResolveUrl("~/CSS/MyStyle.css") %>" rel="stylesheet" type="text/css" />
    <title>会員情報修正</title>
</head>
<body>
   <form id="form1" runat="server" novalidate="novalidate">
    <uc:MyHeader runat="server" ID="ucHeader" />

    <div class="page-center-wrapper">
        <div class="form-card">
            <h2>会員情報修正</h2>
            
            <asp:Label ID="lblError" runat="server" ForeColor="Red" />
            <asp:ValidationSummary ID="valSummary" runat="server" ForeColor="Red" HeaderText="入力内容に不備があります：" />

            <div class="form-group">
                <asp:Label ID="lblUserId" runat="server" Text="会員ID：" />
                <asp:TextBox ID="txtUserId" runat="server" CssClass="input-field" ReadOnly="true" BackColor="#e1e1e1" />
            </div>

            <div class="form-group">
                <asp:Label ID="lblPassword" runat="server" Text="新しいパスワード：" />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="input-field" autocomplete="new-password" />
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="パスワードを入力してください" ForeColor="Red" Text="*" Display="Dynamic" />
                <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtPassword" 
                    ValidationExpression="^(?=.*[a-zA-Z])(?=.*[0-9])[a-zA-Z0-9!-/:-@\[-`{-~]{8,32}$" 
                    ErrorMessage="パスワードは8～32文字の英数字（記号可）で、英字と数字を両方含めてください" ForeColor="Red" Text="*" Display="Dynamic" />
            </div>

            <div class="form-group">
                <asp:Label ID="lblUserName" runat="server" Text="お名前：" />
                <asp:TextBox ID="txtUserName" runat="server" CssClass="input-field" />
                <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="お名前を入力してください" ForeColor="Red" Text="*" Display="Dynamic" />
            </div>

            <div class="form-group">
                <asp:Label ID="lblHometown" runat="server" Text="故郷の星：" />
                <asp:TextBox ID="txtHometownPlanet" runat="server" CssClass="input-field" />
                <asp:RequiredFieldValidator ID="rfvHometownPlanet" runat="server" ControlToValidate="txtHometownPlanet" ErrorMessage="故郷の星を入力してください" ForeColor="Red" Text="*" Display="Dynamic" />
            </div>

            <div class="form-group">
                <asp:Label ID="lblEnvironment" runat="server" Text="ご希望の移住環境：" />
                <asp:DropDownList ID="ddlRecommendedEnvironment" runat="server" CssClass="input-field">
                    <asp:ListItem Text="選択してください" Value="" />
                    <asp:ListItem Text="自然豊か" Value="自然豊か" />
                    <asp:ListItem Text="都市型" Value="都市型" />
                    <asp:ListItem Text="寒冷" Value="寒冷" />
                    <asp:ListItem Text="温暖" Value="温暖" />
                    <asp:ListItem Text="乾燥" Value="乾燥" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvEnvironment" runat="server" ControlToValidate="ddlRecommendedEnvironment" ErrorMessage="ご希望の移住環境を選択してください" ForeColor="Red" Text="*" Display="Dynamic" />
            </div>

            <div class="button-group">
                <asp:Button ID="btnConfirm" runat="server" Text="確認する" OnClick="btnConfirm_Click" CssClass="btn-detail" />
                <asp:Button ID="btnBack" runat="server" Text="戻る" OnClick="btnBack_Click" CausesValidation="false" CssClass="btn-detail btn-logout" />
            </div>
        </div>
    </div>
</form>
</body>
</html>