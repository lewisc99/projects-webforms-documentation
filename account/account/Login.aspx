<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="account.account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="Username" runat="server" Placeholder="Username" />
    <asp:TextBox ID="Password" runat="server" TextMode="Password" Placeholder="Password" />
    <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" />
    <asp:Literal ID="ErrorMessage" runat="server" Text="" />
</asp:Content>
