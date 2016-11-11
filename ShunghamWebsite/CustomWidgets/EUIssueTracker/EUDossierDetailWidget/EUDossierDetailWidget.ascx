<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EUDossierDetailWidget.ascx.cs" Inherits="SitefinityWebApp.CustomWidgets.EUIssueTracker.EUDossierDetailWidget.EUDossierDetailWidget" %>

<ul class="list-f">
    <li class="text-uppercase"><span>Updated:</span> <asp:Literal runat="server" ID="dateUpdatedLtl" /><%-- 20 JUL 2016--%></li>
    <li><span>Status:</span> <asp:Literal runat="server" ID="statusLtl" /><%--Current Proposals--%></li>
    <li><span>Dossier:</span> <asp:Literal runat="server" ID="dossierIDLtl" /><%--13245--%></li>
</ul>
<p class="mb-b">
    <asp:Literal runat="server" ID="fullTitleLtl" />
    <%--Directive 2011/61/EU of the European Parliament and of the Council of 8 June 2011 on Alternative Investment Fund Managers and amending Directives 2003/41/EC and 2009/65/EC and Regulations (EC) No 1060/2009 and (EU) No 1095/2010.--%>
</p>
<p class="strong overlay-a"><asp:Literal runat="server" ID="dateUpdated" 
    Text='<%$ Resources:ShunghamResources, FullContentWarning %>'/></p>
