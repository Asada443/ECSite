<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="ShoppingSite_a.Member.Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
          <h2>会員情報修正</h2>
        <asp:Label ID="lblError" 
    runat="server"
    ForeColor="Red" />
         <p>
            会員ID：
            <asp:TextBox
                ID="txtMemberId"
                runat="server"
                ReadOnly="true" />
        </p>

        <p>
            パスワード：
            <asp:TextBox
                ID="txtPassword"
                runat="server"
                TextMode="Password" />
        </p>

        <p>
            姓：
            <asp:TextBox
                ID="txtLastName"
                runat="server" />
        </p>

        <p>
            名：
            <asp:TextBox
                ID="txtFirstName"
                runat="server" />
        </p>

        <p>
            住所：
            <asp:TextBox
                ID="txtAddress"
                runat="server"
                Width="300" />
        </p>

        <p>
            メールアドレス：
            <asp:TextBox
                ID="txtMailAddress"
                runat="server"
                Width="300" />
        </p>

         <p>
     故郷の星:
     <asp:TextBox ID="txtHomePlanet" runat="server" Width="300" />
 </p>


 <p>
     好みの環境:
     <asp:DropDownList ID="ddlPreferredEnvironment" runat="server">
         <asp:ListItem Text="選択してください" Value="" />
         <asp:ListItem Text="自然豊か" Value="自然豊か" />
         <asp:ListItem Text="都市型" Value="都市型" />
         <asp:ListItem Text="寒冷" Value="寒冷" />
         <asp:ListItem Text="温暖" Value="温暖" />
         <asp:ListItem Text="乾燥" Value="乾燥" />
     </asp:DropDownList>
 </p>

        

        <asp:Button
            ID="btnConfirm"
            runat="server"
            Text="確認"
            OnClick="btnConfirm_Click" />

        <asp:Button
            ID="btnBack"
            runat="server"
            Text="戻る"
            OnClick="btnBack_Click" />


    </form>
</body>
</html>
