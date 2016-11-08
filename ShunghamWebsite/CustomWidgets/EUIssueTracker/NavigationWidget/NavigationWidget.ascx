﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavigationWidget.ascx.cs" Inherits="SitefinityWebApp.CustomWidgets.EUIssueTracker.EUINavigationWidget.NavigationWidget" %>

<header id="aside">
    <h2>Category</h2>
    <telerik:RadListView ID="navigationList" ItemPlaceholderID="NavigationContainer" runat="server"
        EnableEmbeddedSkins="false" EnableEmbeddedBaseStylesheet="false">
        <LayoutTemplate>
            <ul>
                <asp:PlaceHolder ID="NavigationContainer" runat="server" />
            </ul>
        </LayoutTemplate>
        <ItemTemplate>
            <li class="<%# GetPolicyAreaClass(Container.DataItemIndex) %>">
                <asp:HyperLink ID="policyAreaItem" runat="server" 
                    Text='<%# Eval("Key")  %>' />
                <asp:Repeater ID="categoriesRepeater" runat="server">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li class="<%# GetCategoryClass(Container.ItemIndex) %>">
                            <asp:LinkButton ID="categoryLink" runat="server" Text='<%# Eval("Attributes.uni_name")%>'
                                CommandName="selectCategory" />
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </li>
        </ItemTemplate>
    </telerik:RadListView>
</header>