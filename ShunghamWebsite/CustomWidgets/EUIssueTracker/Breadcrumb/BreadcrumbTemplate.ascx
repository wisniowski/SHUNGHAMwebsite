<%@ Control Language="C#" %>
<%@ Register Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sf" %>

<header>
    <sf:SitefinityLabel ID="BreadcrumbLabel" runat="server" WrapperTagName="span" HideIfNoText="true"
        CssClass="sfBreadcrumbLabel" />
    <telerik:RadSiteMap runat="server" ID="Breadcrumb" EnableEmbeddedSkins="false">
        <LevelSettings>
            <telerik:SiteMapLevelSetting Level="0" MaximumNodes="4">
                <NodeTemplate>
                    <nav>
                        <ul class="list-e">
                            <li>
                                <a href='<%# DataBinder.Eval(Container.DataItem, "url") %>'>
                                    <%# DataBinder.Eval(Container.DataItem, "title") %>
                                </a></li>
                        </ul>
                    </nav>
                    <h1>
                        <%# DataBinder.Eval(Container.DataItem, "description") %>
                    </h1>
                </NodeTemplate>
            </telerik:SiteMapLevelSetting>
        </LevelSettings>
    </telerik:RadSiteMap>
</header>

<script type="text/javascript">
    $('a[href="javascript:void(0)"]').replaceWith(function () {
        return $("<span>" + $(this).html() + "</span>");
    });
</script>
