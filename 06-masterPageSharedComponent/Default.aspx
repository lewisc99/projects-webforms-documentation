<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="masterPage._Default" %>
<%@ Register Src="~/AboutContent.ascx" TagPrefix="uc" TagName="AboutContent" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="row">
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h1>Welcome to the Home Page</h1>
                <p>This is the default page content.</p>
                <uc:AboutContent ID="AboutContent" runat="server" />
            </section>
        </div>
    </main>
</asp:Content>