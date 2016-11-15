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
                    <a href='<%# DataBinder.Eval(Container.DataItem, "url") %>'>
                        <%# DataBinder.Eval(Container.DataItem, "title") %>
                    </a>
                    <h1 class="titleInvisible">
                        <%# DataBinder.Eval(Container.DataItem, "description") %>
                    </h1>
                </NodeTemplate>
            </telerik:SiteMapLevelSetting>
        </LevelSettings>
    </telerik:RadSiteMap>
    <h1 class="titleVisible"></h1>
</header>

<script type="text/javascript">
    $('a[href="javascript:void(0)"]').replaceWith(function () {
        return $("<span>" + $(this).html() + "</span>");
    });
    $(".rsmList").addClass("list-e");
    $(".titleInvisible").each(function (index) {
        var str = $(this).html();
        if (str != "") {
            $(".titleVisible").html(str);
        };
        $(this).hide();
    });
</script>
