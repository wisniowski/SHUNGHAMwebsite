<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EUDossierGridWidget.ascx.cs" Inherits="SitefinityWebApp.CustomWidgets.EUIssueTracker.EUDossierGridWidget.EUDossierGridWidget" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sf" %>

<sf:SitefinityLabel ID="otherUpdatesTitle" runat="server" WrapperTagName="H3" HideIfNoText="true" />

<asp:Repeater ID="statusesList" runat="server">
    <HeaderTemplate>
        <ul class="list-i">
    </HeaderTemplate>
    <ItemTemplate>
        <li>
            <asp:HyperLink ID="dossierStatusLink" runat="server">
                <span><%# DisplayDossiersCount((Container.DataItem as SitefinityWebApp.CustomWidgets.EUIssueTracker.EUDossierStatusModel)) %></span>
                <%# DataBinder.Eval(Container.DataItem,"Attributes.uni_displayname") %>
            </asp:HyperLink>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>

<telerik:RadListView ID="dossiersList" ItemPlaceholderID="DossiersContainer" runat="server"
    EnableEmbeddedSkins="false" EnableEmbeddedBaseStylesheet="false">
    <LayoutTemplate>
        <ul class="list-h">
            <asp:PlaceHolder ID="DossiersContainer" runat="server" />
        </ul>
    </LayoutTemplate>
    <ItemTemplate>
        <li>
            <p id="newWrapper" runat="server" class="label" style="display: none;">New</p>
            <h4>
                <%# DataBinder.Eval(Container.DataItem,"Attributes.shortTitle.Value") %>
            </h4>
            <ul>
                <li class="text-uppercase"><span>Updated:</span>
                    <%# DataBinder.Eval(Container.DataItem, "Attributes.publishDate.Value", "{0:dd MMM yyyy}") %></li>
                <li><span>Status:</span>
                    <%# DataBinder.Eval(Container.DataItem,"Attributes.Status.Value") %>
                </li>
                <li><span>Dossier:</span>
                    <%# DataBinder.Eval(Container.DataItem,"Attributes.dossierId.Value") %>
                </li>
            </ul>
            <p class="link">
                <asp:HyperLink runat="server" ID="detailViewLink">Open</asp:HyperLink>
            </p>
        </li>
    </ItemTemplate>
    <EmptyDataTemplate>
        <p class="strong overlay-a">
            <asp:Literal runat="server" ID="emptyMessageLtl" />
        </p>
        <footer class="module-d">
            <h2>
                <asp:Literal runat="server" ID="emptyTitleLtl" />
            </h2>
            <p>
                <asp:Literal runat="server" ID="emptyMessageContentLtl" />
            </p>
    </EmptyDataTemplate>
</telerik:RadListView>

<script type="text/javascript">
    $(function () {
        var href = window.location.href;
        $("[id*=dossierStatusLink]").each(function (e, i) {
            if (href.indexOf($(this).attr('href')) >= 0) {
                $(this).parent().addClass('active');
            }
        });
    });
</script>
