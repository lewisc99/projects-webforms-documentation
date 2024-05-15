<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FirstWebPage.aspx.cs" Inherits="BasicWebApp.FirstWebPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="height:300px">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 300px">
            <p>
                Welcome to visual Web Developer
           
            </p>
            <div>
                <asp:Label runat="server" Text="Enter your name:" ID="Label"></asp:Label>
                <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox><asp:Button runat="server" Text="Button" OnClick="Button1_Clicked"></asp:Button>
            </div>
            <div>
                <asp:Label runat="server" ID="Label1"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
