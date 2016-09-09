<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderWidget.ascx.cs" Inherits="SitefinityWebApp.CustomWidgets.HeaderWidget.HeaderWidget" %>

<%@ Import Namespace="Telerik.Sitefinity.Web.UI.NavigationControls" %>
<%@ Import Namespace="Telerik.Sitefinity.Pages.Model" %>
<%@ Import Namespace="Telerik.Sitefinity.Modules.Pages" %>

<telerik:RadListView ID="menuItemsList" ItemPlaceholderID="NavItemsContainer" runat="server"
    EnableEmbeddedSkins="false" EnableEmbeddedBaseStylesheet="false">
    <LayoutTemplate>
        <ul>
            <asp:PlaceHolder ID="NavItemsContainer" runat="server" />
            <li class="strong">
                <asp:HyperLink ID="LogInLink" runat="server" Target="_blank">
                    <asp:Literal runat="server" Text='<%$ Resources:ShunghamResources, LogInLinkText%>' />
                </asp:HyperLink>
            </li>
            <li class="btn invisible">
                <asp:HyperLink ID="GetTrialLink" runat="server" Target="_blank">
                    <asp:Literal runat="server" Text='<%$ Resources:ShunghamResources, GetTrialButton%>' />
                </asp:HyperLink>
            </li>
        </ul>
    </LayoutTemplate>
    <ItemTemplate>
        <li id="itemTemplateLi" runat="server">
            <asp:HyperLink runat="server" NavigateUrl='<%# (Container.DataItem as PageNode).GetUrl() %>' Target="_blank">
                <asp:Literal runat="server" ID="titleLtl" Text='<%# Eval("Title") %>' />
            </asp:HyperLink>
        </li>
    </ItemTemplate>
</telerik:RadListView>
