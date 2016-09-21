<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JobOpeningsWidget.ascx.cs" Inherits="SitefinityWebApp.CustomWidgets.JobOpeningsWidget.JobOpeningsWidget" %>

<%@ Register TagPrefix="sf" Namespace="Telerik.Sitefinity.Web.UI" Assembly="Telerik.Sitefinity" %>

<telerik:RadListView ID="jobOpeningsList" ItemPlaceholderID="JobOpeningsContainer" runat="server"
    EnableEmbeddedSkins="false" EnableEmbeddedBaseStylesheet="false">
    <LayoutTemplate>
        <h2 class="text-center">
            <asp:Literal runat="server" Text='<%$ Resources:ShunghamResources, JobOpeningsWidgetTitle%>' />
        </h2>
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
                    <li class="strong">
                        <asp:Literal runat="server" Text='<%$ Resources:ShunghamResources, JobBasisText%>' />
                        <span class="overlay-c">
                            <asp:Literal Text='<%# Eval("Basis")%>' runat="server" />
                        </span>
                    </li>
                    <li>
                        <asp:Literal runat="server" Text='<%$ Resources:ShunghamResources, JobAddedText%>' />
                        <span class="overlay-c text-uppercase">
                            <sf:FieldListView ID="PublicationDate" runat="server" Format="{PublicationDate.ToLocal():dd MMM yyyy}" />
                        </span>
                    </li>
                </ul>
            </header>
            <p>
                <asp:Literal Text='<%# Eval("JobDescription")%>' runat="server" />
            </p>
            <h4>
                <asp:Literal runat="server" Text='<%$ Resources:ShunghamResources, JobKeySkillsText%>' />
            </h4>
            <p>
                <asp:Literal Text='<%# Eval("KeySkills")%>' runat="server" />
            </p>
            <h4>
                <asp:Literal runat="server" Text='<%$ Resources:ShunghamResources, JobResponsibilitiesText%>' />
            </h4>
            <p>
                <asp:Literal Text='<%# Eval("Responsibilities")%>' runat="server" />
            </p>
            <p class="link-a">
                <asp:HyperLink ID="ApplyNowLink" runat="server">
                    <asp:Literal runat="server" Text='<%$ Resources:ShunghamResources, ApplyNowButtonText%>' />
                </asp:HyperLink>
            </p>
        </article>
    </ItemTemplate>
</telerik:RadListView>

