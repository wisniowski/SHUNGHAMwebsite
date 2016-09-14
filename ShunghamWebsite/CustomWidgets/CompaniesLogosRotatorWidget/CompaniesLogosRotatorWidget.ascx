<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CompaniesLogosRotatorWidget.ascx.cs" Inherits="SitefinityWebApp.CustomWidgets.CompaniesLogosSlider.CompaniesLogosRotatorWidget" %>

<telerik:RadListView ID="companiesLogosList" ItemPlaceholderID="CompaniesLogosContainer" runat="server"
    EnableEmbeddedSkins="false" EnableEmbeddedBaseStylesheet="false">
    <LayoutTemplate>
        <ul class="gallery-a">
            <asp:PlaceHolder ID="CompaniesLogosContainer" runat="server" />
        </ul>
    </LayoutTemplate>
    <ItemTemplate>
        <li>
            <asp:Image runat="server" ID="logoImg" />
        </li>
    </ItemTemplate>
</telerik:RadListView>