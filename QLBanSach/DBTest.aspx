<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DBTest.aspx.cs" Inherits="QLBanSach.DBTest" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Database Connection Test</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-4">
            <h2>Database Connection Test</h2>
            <div class="card">
                <div class="card-header">
                    <h5>Test Connection Strings</h5>
                </div>
                <div class="card-body">
                    <asp:Button ID="btnTest1" runat="server" Text="Test localhost\SQLEXPRESS" CssClass="btn btn-primary m-2" OnClick="btnTest1_Click" />
                    <asp:Button ID="btnTest2" runat="server" Text="Test .\SQLEXPRESS" CssClass="btn btn-primary m-2" OnClick="btnTest2_Click" />
                    <asp:Button ID="btnTest3" runat="server" Text="Test (local)\SQLEXPRESS" CssClass="btn btn-primary m-2" OnClick="btnTest3_Click" />
                    <asp:Button ID="btnTest4" runat="server" Text="Test localhost" CssClass="btn btn-primary m-2" OnClick="btnTest4_Click" />
                    <asp:Button ID="btnTest5" runat="server" Text="Test LAPTOP-TNRJQCBE\SQL" CssClass="btn btn-primary m-2" OnClick="btnTest5_Click" />
                    
                    <hr />
                    
                    <h5>Results:</h5>
                    <asp:Label ID="lblResult" runat="server" CssClass="alert alert-info d-block"></asp:Label>
                </div>
            </div>
            
            <div class="card mt-3">
                <div class="card-header">
                    <h5>Current Connection String</h5>
                </div>
                <div class="card-body">
                    <asp:Label ID="lblCurrentConn" runat="server" CssClass="font-monospace"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
