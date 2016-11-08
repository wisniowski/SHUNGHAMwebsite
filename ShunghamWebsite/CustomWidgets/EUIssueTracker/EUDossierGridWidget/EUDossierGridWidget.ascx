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
<ul class="list-h">
    <li>
        <p class="label">New</p>
        <h4>Capital Markets Union (CMU): Action Plan</h4>
        <ul>
            <li class="text-uppercase"><span>Updated:</span> 20 JUL 2016</li>
            <li><span>Status:</span> Current Proposals</li>
            <li><span>Dossier:</span> 13245</li>
        </ul>
        <p class="link"><a href="./">Open</a></p>
    </li>
    <li>
        <p class="label">New</p>
        <h4>Alternative Investment Fund Managers (AIFM)</h4>
        <ul>
            <li class="text-uppercase"><span>Updated:</span> 20 JUL 2016</li>
            <li><span>Status:</span> Current Proposals</li>
            <li><span>Dossier:</span> 13245</li>
        </ul>
        <p class="link"><a href="./">Open</a></p>
    </li>
    <li>
        <h4>Capital Markets Union (CMU): Action Plan</h4>
        <ul>
            <li class="text-uppercase"><span>Updated:</span> 20 JUL 2016</li>
            <li><span>Status:</span> Current Proposals</li>
            <li><span>Dossier:</span> 13245</li>
        </ul>
        <p class="link"><a href="./">Open</a></p>
    </li>
    <li>
        <p class="label">New</p>
        <h4>Capital Markets Union (CMU): Action Plan</h4>
        <ul>
            <li class="text-uppercase"><span>Updated:</span> 20 JUL 2016</li>
            <li><span>Status:</span> Current Proposals</li>
            <li><span>Dossier:</span> 13245</li>
        </ul>
        <p class="link"><a href="./">Open</a></p>
    </li>
    <li>
        <h4>Alternative Investment Fund Managers (AIFM)</h4>
        <ul>
            <li class="text-uppercase"><span>Updated:</span> 20 JUL 2016</li>
            <li><span>Status:</span> Current Proposals</li>
            <li><span>Dossier:</span> 13245</li>
        </ul>
        <p class="link"><a href="./">Open</a></p>
    </li>
    <li>
        <h4>Capital Markets Union (CMU): Action Plan</h4>
        <ul>
            <li class="text-uppercase"><span>Updated:</span> 20 JUL 2016</li>
            <li><span>Status:</span> Current Proposals</li>
            <li><span>Dossier:</span> 13245</li>
        </ul>
        <p class="link"><a href="./">Open</a></p>
    </li>
    <li>
        <p class="label">New</p>
        <h4>Capital Markets Union (CMU): Action Plan</h4>
        <ul>
            <li class="text-uppercase"><span>Updated:</span> 20 JUL 2016</li>
            <li><span>Status:</span> Current Proposals</li>
            <li><span>Dossier:</span> 13245</li>
        </ul>
        <p class="link"><a href="./">Open</a></p>
    </li>
    <li>
        <h4>Alternative Investment Fund Managers (AIFM)</h4>
        <ul>
            <li class="text-uppercase"><span>Updated:</span> 20 JUL 2016</li>
            <li><span>Status:</span> Current Proposals</li>
            <li><span>Dossier:</span> 13245</li>
        </ul>
        <p class="link"><a href="./">Open</a></p>
    </li>
    <li>
        <h4>Capital Markets Union (CMU): Action Plan</h4>
        <ul>
            <li class="text-uppercase"><span>Updated:</span> 20 JUL 2016</li>
            <li><span>Status:</span> Current Proposals</li>
            <li><span>Dossier:</span> 13245</li>
        </ul>
        <p class="link"><a href="./">Open</a></p>
    </li>
</ul>

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
