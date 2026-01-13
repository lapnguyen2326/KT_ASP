<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="QLBanSach.Test" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Test Page - Application is Running!</h1>
            <p>If you can see this page, the application is working correctly.</p>
            <asp:Label ID="lblMessage" runat="server" Text="Welcome to QLBanSach!"></asp:Label>
            <br /><br />
            <a href="QTSach.aspx">Go to Book Management</a>
        </div>
    </form>
</body>
</html>
