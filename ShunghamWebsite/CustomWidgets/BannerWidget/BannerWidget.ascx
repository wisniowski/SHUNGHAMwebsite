<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BannerWidget.ascx.cs" Inherits="SitefinityWebApp.CustomWidgets.BannerWidget.BannerWidget" %>

<header id="featured" class="a">
    <h1>
        <asp:Literal runat="server" ID="titleLtl" />
    </h1>
    <p>
        <asp:Literal runat="server" ID="subTitleLtl" />
    </p>
    <p class="link-a a">
        <asp:HyperLink runat="server" ID="firstBtnLink" Target="_blank" CssClass="b">
            <asp:Literal runat="server" ID="firstBtnLtl" />
        </asp:HyperLink>
        <asp:HyperLink runat="server" ID="secondBtnLink" Target="_blank" CssClass="b">
            <asp:Literal runat="server" ID="secondBtnLtl" />
        </asp:HyperLink>
    </p>
    <figure class="background">
        <asp:Image runat="server" ID="bgrImage" />
    </figure>
</header>
