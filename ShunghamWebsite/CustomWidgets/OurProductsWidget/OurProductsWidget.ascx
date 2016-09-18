<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OurProductsWidget.ascx.cs" Inherits="SitefinityWebApp.CustomWidgets.OurProductsWidget.OurProductsWidget" %>

<telerik:RadListView ID="productsList" ItemPlaceholderID="ProductsContainer" runat="server"
    EnableEmbeddedSkins="false" EnableEmbeddedBaseStylesheet="false">
    <LayoutTemplate>
        <article class="module-a">
            <div>
                <h2 class="text-center">
                    <asp:Literal runat="server" Text='<%$ Resources:ShunghamResources, OurProductsHeader%>' />
                </h2>
                <div class="news-a a">
                    <asp:PlaceHolder ID="ProductsContainer" runat="server" />
                </div>
            </div>
            <figure class="background">
                <asp:Image runat="server" />
            </figure>
        </article>
    </LayoutTemplate>
    <ItemTemplate>
        <article>
            <header>
                <h3 class="stronger">
                    <asp:Literal Text='<%# Eval("Title")%>' runat="server" />
                </h3>
            </header>
            <asp:Literal Text='<%# Eval("Summary")%>' runat="server" />
            <p class="link-a">
                <asp:HyperLink NavigateUrl='<%# Eval("PolicyCoverageLandingPage")%>' runat="server">
                    <asp:Literal runat="server" Text='<%$ Resources:ShunghamResources, PolicyCoverageButtonText%>' />
                </asp:HyperLink>
                <asp:HyperLink NavigateUrl='<%# Eval("ReadMoreLandingPage")%>' runat="server">
                    <asp:Literal runat="server" Text='<%$ Resources:ShunghamResources, ReadMoreButtonText%>' />
                </asp:HyperLink>
            </p>
        </article>
    </ItemTemplate>
</telerik:RadListView>
