<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ajax._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 <div>
 <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
 <ContentTemplate>
 <asp:Label ID="Label1" runat="server"
 Text="This is a label!"></asp:Label>
 <asp:Button ID="Button1" runat="server"
 Text="Click Me" OnClick="Button1_Click" />
 </ContentTemplate>
 </asp:UpdatePanel>
     </div>
</asp:Content>
