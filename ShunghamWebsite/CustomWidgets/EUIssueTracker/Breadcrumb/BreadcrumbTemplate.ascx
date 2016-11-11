<%@ Control Language="C#" %>
<%@ Register Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sf" %>

<header>
    <sf:SitefinityLabel ID="BreadcrumbLabel" runat="server" WrapperTagName="span" HideIfNoText="true"
        CssClass="sfBreadcrumbLabel" />
    <telerik:RadSiteMap runat="server" ID="Breadcrumb" EnableEmbeddedSkins="false">
        <LevelSettings>
            <telerik:SiteMapLevelSetting Level="0" MaximumNodes="3">
                <NodeTemplate>
                    <nav>
                        <ul class="list-e">
                            <li>
                                <a href='#'>
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
