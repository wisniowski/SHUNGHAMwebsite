<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AboutUsSectionWidget.ascx.cs" Inherits="SitefinityWebApp.CustomWidgets.AboutUsSectionWidget.AboutUsSectionWidget" %>

<article class="module-a text-justify mobile-text-center">
    <div>
        <h2 class="header-a text-center">
            <asp:Literal runat="server" ID="TitleLtl" />
        </h2>
        <div id="contentWrapper" runat="server">
            <figure class="float-right" id="imageWrapper" runat="server">
                <asp:Image ID="ImageControl" runat="server" />
            </figure>
            <p>
                <asp:Literal runat="server" ID="ContentLtl" />
            </p>
        </div>
    </div>
</article>
