<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InfoWidget.ascx.cs" Inherits="SitefinityWebApp.CustomWidgets.InfoWidget.InfoWidget" %>

<span class="title">
    <asp:Literal runat="server" ID="TitleLtl" />
</span>
<span class="desc">
    <asp:Literal runat="server" ID="SummaryLtl" />
</span>
<span class="more">
    <asp:Literal runat="server" ID="ContentLtl" />
</span>