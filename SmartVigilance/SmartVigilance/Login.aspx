<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SmartVigilance.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Login.aspx<br />
        <br /><br />
        Login :<br />
        <asp:TextBox ID="TextBoxLogin" runat="server"></asp:TextBox>
        <br />
        Password :<br />
        <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Button ID="ButtonLogin" runat="server" Text="Log In" Width="75px" OnClick="ButtonLogin_Click" />
        <br />
        <asp:Label ForeColor="DarkGray" ID="Label1" runat="server" Text="Waiting login attempt"></asp:Label>
    </div>
    </form>
</body>
</html>
