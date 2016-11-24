<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AboutUsSectionWidget.ascx.cs" Inherits="SitefinityWebApp.CustomWidgets.AboutUsSectionWidget.AboutUsSectionWidget" %>

<article class="module-a text-justify mobile-text-center">
    <div>
        <h2 class="header-a text-center">
            <asp:Literal runat="server" ID="TitleLtl" />
        </h2>
        <figure class="float-right">
            <img src="http://placehold.it/460x400" alt="Placeholder" width="460" height="400"></figure>
        <asp:Literal runat="server" ID="ContentLtl" />
    </div>
</article>
