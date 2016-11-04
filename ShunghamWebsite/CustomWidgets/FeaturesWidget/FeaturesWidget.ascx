<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FeaturesWidget.ascx.cs" Inherits="SitefinityWebApp.CustomWidgets.FeaturesWidget.FeaturesWidget" %>

<telerik:RadListView ID="featuresList" ItemPlaceholderID="FeaturesContainer" runat="server"
    EnableEmbeddedSkins="false" EnableEmbeddedBaseStylesheet="false">
    <LayoutTemplate>
        <h2 class="text-center">
            <asp:Literal runat="server" Text='<%$ Resources:ShunghamResources, FeaturesWidgetTitle%>' />
        </h2>
        <div class="news-a b">
            <asp:PlaceHolder ID="FeaturesContainer" runat="server" />
        </div>
    </LayoutTemplate>
    <ItemTemplate>
        <article>
            <header>
                <h3>
                    <asp:Literal Text='<%# Eval("Title")%>' runat="server" />
                </h3>
                <p>
                    <asp:Literal Text='<%# Eval("Subtitle")%>' runat="server" />
                </p>
            </header>
            <p>
                <asp:Literal Text='<%# Eval("Summary")%>' runat="server" />
            </p>
            <p class="link-a">
                <asp:HyperLink NavigateUrl="./" runat="server" CssClass="a" data-popup='<%# Eval("Title")%>'>
                    <asp:Literal runat="server" Text='<%$ Resources:ShunghamResources, FeaturesReadMoreText%>' />
                </asp:HyperLink>
            </p>
        </article>
    </ItemTemplate>
</telerik:RadListView>

<telerik:RadListView ID="featuresPopupList" ItemPlaceholderID="FeaturesPopupsContainer" runat="server"
    EnableEmbeddedSkins="false" EnableEmbeddedBaseStylesheet="false">
    <LayoutTemplate>
            <asp:PlaceHolder ID="FeaturesPopupsContainer" runat="server" />
    </LayoutTemplate>
    <ItemTemplate>
        <article class="popup-a text-center" title='<%# Eval("Title")%>'>
            <header>
                <h2 class="overlay-c">
                    <asp:Literal Text='<%# Eval("Title")%>' runat="server" />
                </h2>
                <p>
                    <asp:Literal Text='<%# Eval("Subtitle")%>' runat="server" />
                </p>
            </header>
            <p>
                <asp:Literal Text='<%# Eval("Summary")%>' runat="server" />
            </p>
            <p>
                <asp:Literal Text='<%# Eval("Content")%>' runat="server" />
            </p>
        </article>
    </ItemTemplate>
</telerik:RadListView>
