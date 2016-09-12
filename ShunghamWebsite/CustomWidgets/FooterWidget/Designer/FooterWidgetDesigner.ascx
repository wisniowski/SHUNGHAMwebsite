<%@ Control %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sf" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sitefinity" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sfFields" Namespace="Telerik.Sitefinity.Web.UI.Fields" %>

<sitefinity:ResourceLinks ID="resourcesLinks" runat="server">
    <sitefinity:ResourceFile Name="Styles/Ajax.css" />
    <sitefinity:ResourceFile Name="Styles/jQuery/jquery.ui.core.css" />
    <sitefinity:ResourceFile Name="Styles/jQuery/jquery.ui.dialog.css" />
    <sitefinity:ResourceFile Name="Styles/jQuery/jquery.ui.theme.sitefinity.css" />
</sitefinity:ResourceLinks>
<div id="designerLayoutRoot" class="sfContentViews sfSingleContentView" style="max-height: 400px; overflow: auto;">
    <ol>
        <li class="sfFormCtrl">
            <label class="sfTxtLbl" for="selectedWhoWeArePageIdsLabel">
                <asp:Literal runat="server" Text='<%$ Resources:ShunghamResources, WhoWeAreLinksLabelInDesigner%>' />
            </label>
            <span style="display: none;" class="sfSelectedItem" id="selectedWhoWeArePageIdsLabel">
                <asp:Literal runat="server" Text="" />
            </span>
            <span class="sfLinkBtn sfChange">
                <a href="javascript: void(0)" class="sfLinkBtnIn" id="pageSelectButtonWhoWeArePageIds">
                    <asp:Literal runat="server" Text="<%$Resources:Labels, SelectDotDotDot %>" />
                </a>
            </span>
            <div id="selectorTagWhoWeArePageIds" runat="server" style="display: none;">
                <sf:PagesSelector runat="server" ID="pageSelectorWhoWeArePageIds"
                    AllowExternalPagesSelection="false" AllowMultipleSelection="true" />
            </div>
            <div class="sfExample"></div>
        </li>

        <li class="sfFormCtrl">
            <asp:Label runat="server" AssociatedControlID="LinkedInButtonExternalLink" CssClass="sfTxtLbl">
                <asp:Literal runat="server" Text='<%$ Resources:ShunghamResources, LinkedInLinkLabelInDesigner%>' />
            </asp:Label>
            <asp:TextBox ID="LinkedInButtonExternalLink" runat="server" CssClass="sfTxt" />
            <div class="sfExample"></div>
        </li>

        <li class="sfFormCtrl">
            <asp:Label runat="server" AssociatedControlID="TwitterButtonExternalLink" CssClass="sfTxtLbl">
                <asp:Literal runat="server" Text='<%$ Resources:ShunghamResources, TwitterLinkLabelInDesigner%>' />
            </asp:Label>
            <asp:TextBox ID="TwitterButtonExternalLink" runat="server" CssClass="sfTxt" />
            <div class="sfExample"></div>
        </li>

        <li class="sfFormCtrl">
            <asp:Label runat="server" AssociatedControlID="FacebookButtonExternalLink" CssClass="sfTxtLbl">
                <asp:Literal runat="server" Text='<%$ Resources:ShunghamResources, FacebookLinkLabelInDesigner%>' />
            </asp:Label>
            <asp:TextBox ID="FacebookButtonExternalLink" runat="server" CssClass="sfTxt" />
            <div class="sfExample"></div>
        </li>

    </ol>
</div>
