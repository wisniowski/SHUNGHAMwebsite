<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FooterWidget.ascx.cs" Inherits="SitefinityWebApp.CustomWidgets.FooterWidget.FooterWidget" %>

<%@ Import Namespace="Telerik.Sitefinity.Pages.Model" %>
<%@ Import Namespace="Telerik.Sitefinity.Modules.Pages" %>

<nav>
    <telerik:RadListView ID="productsList" ItemPlaceholderID="productsContainer" runat="server"
        EnableEmbeddedSkins="false" EnableEmbeddedBaseStylesheet="false">
        <LayoutTemplate>
            <div>
                <h3>Our products</h3>
                <div class="double">
                    <asp:PlaceHolder ID="productsContainer" runat="server" />
                </div>
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <div>
                <h4>
                    <asp:Literal runat="server" ID="titleLtl" Text='<%# Eval("Title") %>' /></h4>
                <ul>
                    <asp:Repeater ID="companyLinkRepeater" runat="server">
                        <ItemTemplate>
                            <li>
                                <asp:HyperLink runat="server" NavigateUrl='<%# (Container.DataItem as PageNode).GetUrl() %>' Target="_blank">
                                    <asp:Literal runat="server" ID="titleLtl" Text='<%# Eval("Title") %>' />
                                </asp:HyperLink>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>

                </ul>
            </div>
        </ItemTemplate>
    </telerik:RadListView>
    <telerik:RadListView ID="siteMapList" ItemPlaceholderID="siteMapContainer" runat="server"
        EnableEmbeddedSkins="false" EnableEmbeddedBaseStylesheet="false">
        <LayoutTemplate>
            <div>
                <h3>Who we are</h3>
                <ul>
                    <asp:PlaceHolder ID="siteMapContainer" runat="server" />
                </ul>
            </div>

        </LayoutTemplate>
        <ItemTemplate>
            <asp:Repeater ID="linksRepeater" runat="server">
                <ItemTemplate>
                    <li>
                        <asp:HyperLink runat="server" NavigateUrl='<%# (Container.DataItem as PageNode).GetUrl() %>' Target="_blank">
                            <asp:Literal runat="server" ID="titleLtl" Text='<%# Eval("Title") %>' />
                        </asp:HyperLink>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </telerik:RadListView>
    <ul class="social-a">
        <li>
            <asp:HyperLink ID="LinkedInLink" runat="server" Target="_blank">
                <i class="icon-linkedin"></i>
                <span>
                    <asp:Literal runat="server" Text='<%$ Resources:ShunghamResources, LinkedInText%>' />
                </span>
            </asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink ID="TwitterLink" runat="server" Target="_blank">
                <i class="icon-twitter"></i>
                <span>
                    <asp:Literal runat="server" Text='<%$ Resources:ShunghamResources, TwitterText%>' />
                </span>
            </asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink ID="FacebookLink" runat="server" Target="_blank">
                <i class="icon-facebook"></i>
                <span>
                    <asp:Literal runat="server" Text='<%$ Resources:ShunghamResources, FacebookText%>' />
                </span>
            </asp:HyperLink>
        </li>
    </ul>
</nav>
<p>&copy; <span class="date">2016</span> Shungham. All Rights Reserved.</p>
