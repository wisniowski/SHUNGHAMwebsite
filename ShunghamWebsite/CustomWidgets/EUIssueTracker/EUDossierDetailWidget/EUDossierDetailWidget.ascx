<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EUDossierDetailWidget.ascx.cs" Inherits="SitefinityWebApp.CustomWidgets.EUIssueTracker.EUDossierDetailWidget.EUDossierDetailWidget" %>

<ul class="list-f">
    <li class="text-uppercase"><span>Updated:</span> <asp:Literal runat="server" ID="dateUpdatedLtl" /></li>
    <li><span>Status:</span> <asp:Literal runat="server" ID="statusLtl" /></li>
    <li><span>Dossier:</span> <asp:Literal runat="server" ID="dossierIDLtl" /></li>
</ul>
<p class="mb-b">
    <asp:Literal runat="server" ID="fullTitleLtl" />
</p>
<p class="strong overlay-a"><asp:Literal runat="server" ID="dateUpdated" 
    Text='<%$ Resources:ShunghamResources, FullContentWarning %>'/></p>
