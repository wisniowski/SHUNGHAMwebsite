﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BannerWidget.ascx.cs" Inherits="SitefinityWebApp.CustomWidgets.BannerWidget.BannerWidget" %>

<h1>
    <asp:Literal runat="server" ID="titleLtl" />
</h1>
<p>
    <asp:Literal runat="server" ID="subTitleLtl" />
</p>
<p class="link-a a" runat="server" id="btnParagraph">
</p>
<figure class="background">
    <asp:Image runat="server" ID="bgrImage" />
</figure>
