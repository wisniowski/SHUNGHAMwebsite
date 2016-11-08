<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EUDossierGridWidget.ascx.cs" Inherits="SitefinityWebApp.CustomWidgets.EUIssueTracker.EUDossierGridWidget.EUDossierGridWidget" %>

<telerik:RadListView ID="statusesList" ItemPlaceholderID="StatusesContainer" runat="server"
    EnableEmbeddedSkins="false" EnableEmbeddedBaseStylesheet="false">
    <LayoutTemplate>
        <ul class="list-i">
            <asp:PlaceHolder ID="StatusesContainer" runat="server" />
        </ul>
    </LayoutTemplate>
    <ItemTemplate>
        <li>
            <asp:HyperLink ID="dossierStatusLink" runat="server">
                <span><%# GetDossiersCountByStatus((Container.DataItem as RadListViewDataItem)) %></span>
                <%# DataBinder.Eval(Container.DataItem,"Attributes.uni_name") %>
            </asp:HyperLink>
        </li>
    </ItemTemplate>
</telerik:RadListView>

<telerik:RadListView ID="dossiersList" ItemPlaceholderID="DossiersContainer" runat="server"
    EnableEmbeddedSkins="false" EnableEmbeddedBaseStylesheet="false">
    <LayoutTemplate>
        <ul class="list-h">
            <asp:PlaceHolder ID="DossiersContainer" runat="server" />
        </ul>
    </LayoutTemplate>
    <ItemTemplate>
        <li>
            <p class="label">New</p>
            <h4>
                <%# DataBinder.Eval(Container.DataItem,"Attributes.uni_shorttitle") %>
            </h4>
            <ul>
                <li class="text-uppercase"><span>Updated:</span>
                    <%# DataBinder.Eval(Container.DataItem, "Attributes.createdon", "{0:dd MMM yyyy}") %></li>
                <li><span>Status:</span>
                    <%# DataBinder.Eval(Container.DataItem,"Attributes.Status.Value") %>
                </li>
                <li><span>Dossier:</span>
                    <%# DataBinder.Eval(Container.DataItem,"Attributes.DossierID.Value") %>
                </li>
            </ul>
            <p class="link">
                <asp:HyperLink runat="server" ID="detailViewLink">Open</asp:HyperLink>
            </p>
        </li>
    </ItemTemplate>
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
