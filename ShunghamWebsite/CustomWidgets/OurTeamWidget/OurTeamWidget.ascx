<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OurTeamWidget.ascx.cs" Inherits="SitefinityWebApp.CustomWidgets.OurTeamWidget.OurTeamWidget" %>

<telerik:RadListView ID="teamMembersList" ItemPlaceholderID="TeamMembersContainer" runat="server"
    EnableEmbeddedSkins="false" EnableEmbeddedBaseStylesheet="false">
    <LayoutTemplate>
        <ul class="list-b">
            <asp:PlaceHolder ID="TeamMembersContainer" runat="server" />
        </ul>
    </LayoutTemplate>
    <ItemTemplate>
        <li data-popup='<%# Eval("Title")%>'>
            <header>
                <figure>
                    <asp:Image ImageUrl='<%# Eval("Avatar.MediaUrl")%>' AlternateText='<%# Eval("Avatar.AlternativeText")%>' runat="server" />
                </figure>
                <h2>
                    <asp:Literal Text='<%# Eval("FirstName")%>' runat="server" /><br>
                    <asp:Literal Text='<%# Eval("LastName")%>' runat="server" /></h2>
                <p>
                    <asp:Literal Text='<%# Eval("JobTitle")%>' runat="server" />
                </p>
                <ul class="social-b">
                    <li>
                        <asp:HyperLink NavigateUrl='<%# Eval("LinkedIn")%>' runat="server">
                            <i class="icon-linkedin"></i>
                            <span>LinkedIn</span>
                        </asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink NavigateUrl='<%# "mailto:" + Eval("Email").ToString() %>' CssClass="email" runat="server" />
                    </li>
                </ul>
            </header>
            <div>
                <p>
                    <asp:Literal Text='<%# Eval("Biography")%>' runat="server" />
                </p>
            </div>
        </li>
    </ItemTemplate>
</telerik:RadListView>
