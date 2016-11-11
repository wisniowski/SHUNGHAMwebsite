<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavigationWidget.ascx.cs" Inherits="SitefinityWebApp.CustomWidgets.EUIssueTracker.EUINavigationWidget.NavigationWidget" ClientIDMode="Static" %>

<asp:HiddenField runat="server" ID="activeAreaHdn" />
<asp:HiddenField runat="server" ID="activeCategoryHdn" />

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
            <li>
                <asp:HyperLink ID="policyAreaItem" runat="server"
                    Text='<%# Eval("Key")  %>' />
                <asp:Repeater ID="categoriesRepeater" runat="server">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink ID="categoryLink" runat="server" Text='<%# Eval("Attributes.uni_name")%>' />
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

<script type="text/javascript">
    $(function () {

        var href = window.location.href;
        var preSelectedCategory = $('[id*=activeCategoryHdn]').val();
        var preSelectedArea = $('[id*=activeAreaHdn]').val();
        $("[id*=categoryLink]").each(function (e, i) {
            var itemUrl = $(this).attr('href').replace(/\.\.\//g, '').trim();
            if (href.indexOf(itemUrl) >= 0) {
                $(this).parent().addClass('active');
                $(this).parent().parent().parent().addClass("toggle");
            }
            else if (preSelectedCategory) {
                if ($(this).text() == preSelectedCategory)
                {
                    $(this).parent().addClass('active');
                    $(this).parent().parent().parent().addClass("toggle");
                }
            }
        });
    });

</script>
