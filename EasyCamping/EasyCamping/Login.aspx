<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EasyCamping.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUserName" ErrorMessage="Username is required." style="color: #FF0000"></asp:RequiredFieldValidator>
    
    </div>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required." style="color: #FF0000"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="lblInvalid" runat="server" style="color: #FF0000" Text="Invalid UserName and/or Password." Visible="False"></asp:Label>
        </p>
        <p>
            <asp:Button ID="LoginBtn" runat="server" OnClick="LoginBtn_Click" Text="Login" Width="81px" />
        </p>
    </form>
</body>
</html>
