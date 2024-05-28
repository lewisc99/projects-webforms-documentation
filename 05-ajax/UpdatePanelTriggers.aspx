<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdatePanelTriggers.aspx.cs" Inherits="ajax.updatePanelTriggers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server"
            UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="Label1" runat="server" />
                <br />
                <asp:Button ID="Button1" runat="server"
                    Text="Update Both Panels" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server"
                    Text="Update This Panel" OnClick="Button2_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server"
            UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="Label2" runat="server" ForeColor="red" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
