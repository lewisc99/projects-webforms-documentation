<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MultipleContentPlaceHolders.aspx.cs" Inherits="masterPage.MultipleContentPlaceHolders" Title="Untitled Page" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    content 2
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftColumnContent" runat="Server">
    <h3>Page-Specific Content</h3>
    <ul>
        <li>This content is defined in the content page.</li>
        <li>The master page has two regions in the Web Form that are editable on a
 page-by-page basis.</li>
    </ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="QuickLoginUI" runat="server" Visible="true">
    Login
</asp:Content>
