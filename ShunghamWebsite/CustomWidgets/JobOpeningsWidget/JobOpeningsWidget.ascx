<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JobOpeningsWidget.ascx.cs" Inherits="SitefinityWebApp.CustomWidgets.JobOpeningsWidget.JobOpeningsWidget" %>

<telerik:RadListView ID="jobOpeningsList" ItemPlaceholderID="JobOpeningsContainer" runat="server"
    EnableEmbeddedSkins="false" EnableEmbeddedBaseStylesheet="false">
    <LayoutTemplate>
        <h2 class="text-center">Current job <span>openings</span></h2>
        <div class="news-a">
            <asp:PlaceHolder ID="JobOpeningsContainer" runat="server" />
        </div>
    </LayoutTemplate>
    <ItemTemplate>
        <article>
            <header>
                <h3>
                    <asp:Literal Text='<%# Eval("Title")%>' runat="server" />
                </h3>
                <ul>
                    <li class="strong">Basis: 
                        <span class="overlay-c">
                            <asp:Literal Text='<%# Eval("Basis")%>' runat="server" />
                        </span>
                    </li>
                    <li>Added: 
                        <span class="overlay-c text-uppercase">
                            <asp:Literal Text='<%# Eval("PublicationDate")%>' runat="server" />
                        </span>
                    </li>
                </ul>
            </header>
            <p>
                <asp:Literal Text='<%# Eval("JobDescription")%>' runat="server" />
            </p>
            <h4>Key Skills</h4>
            <p>
                <asp:Literal Text='<%# Eval("KeySkills")%>' runat="server" />
            </p>
            <h4>Responsibilities</h4>
            <p>
                <asp:Literal Text='<%# Eval("Responsibilities")%>' runat="server" />
            </p>
            <p class="link-a">
                <asp:HyperLink ID="ApplyNowLink" runat="server">
                    <asp:Literal runat="server" />
                </asp:HyperLink>
            </p>
        </article>
    </ItemTemplate>
</telerik:RadListView>

