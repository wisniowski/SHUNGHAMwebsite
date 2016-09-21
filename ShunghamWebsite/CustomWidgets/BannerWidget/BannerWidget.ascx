<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BannerWidget.ascx.cs" Inherits="SitefinityWebApp.CustomWidgets.BannerWidget.BannerWidget" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sf" %>

<sf:SitefinityLabel ID="titleLbl" runat="server" WrapperTagName="H1"
    HideIfNoText="true" />
<p>
    <asp:Literal runat="server" ID="subTitleLtl" />
</p>
<p class="link-a a" runat="server" id="btnParagraph">
</p>
<figure class="background">
    <asp:Image runat="server" ID="bgrImage" />
</figure>
