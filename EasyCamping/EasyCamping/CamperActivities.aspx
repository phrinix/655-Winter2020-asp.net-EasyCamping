<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CamperActivities.aspx.cs" Inherits="EasyCamping.CamperActivities" %>

<!--part B  page created by YASHKUMAR PATEL-->

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>CAMPER ACTIVITIES PAGE </h1>
    <form id="form1" runat="server">
        Name:
        <asp:Label ID="CamperNameLBL" runat="server" ForeColor="#0066FF" Text="Label"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="RegActivityBTN" runat="server" OnClick="RegActivityBTN_Click">Register Activity Page</asp:LinkButton>
        <br />
        Number of registered activities:
        <asp:Label ID="lblRegActivities" runat="server" ForeColor="#0066FF" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:ButtonField ButtonType="Button" HeaderText="Delete" CommandName="DELETE" Text="Unregister" />
                <asp:BoundField DataField="ActivityId" HeaderText="Activity ID" Visible="False" />
                <asp:BoundField DataField="ActivityName" HeaderText="Activity Name" />
                <asp:BoundField DataField="CampDay" HeaderText="Day" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="NotRegisteredLBL" runat="server" ForeColor="Red" Text="The camper has no registered activity"></asp:Label>
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="LogOutBTN" runat="server" OnClick="LogOutBTN_Click" Text="Log out" />
    <div>
    
    </div>
    </form>
</body>
</html>
