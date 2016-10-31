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
            <label class="sfTxtLbl" for="selectedDetailsPageIdLabel">Select the ID of Details page</label>
            <span style="display: none;" class="sfSelectedItem" id="selectedDetailsPageIdLabel">
                <asp:Literal ID="Literal1" runat="server" Text="" />
            </span>
            <span class="sfLinkBtn sfChange">
                <a href="javascript: void(0)" class="sfLinkBtnIn" id="pageSelectButtonDetailsPageId">
                    <asp:Literal ID="Literal2" runat="server" Text="<%$Resources:Labels, SelectDotDotDot %>" />
                </a>
            </span>
            <div id="selectorTagDetailsPageId" runat="server" style="display: none;">
                <sf:PagesSelector runat="server" ID="pageSelectorDetailsPageId"
                    AllowExternalPagesSelection="false" AllowMultipleSelection="false" />
            </div>
            <div class="sfExample"></div>
        </li>

        <li class="sfFormCtrl">
            <asp:Label ID="Label2" runat="server" AssociatedControlID="InitialItemsCount" 
                CssClass="sfTxtLbl">Initial Items Count</asp:Label>
            <asp:TextBox ID="InitialItemsCount" runat="server" CssClass="sfTxt" />
            <div class="sfExample"></div>
        </li>

        <li class="sfFormCtrl">
            <asp:Label ID="Label1" runat="server" AssociatedControlID="BackButtonDefaultDestination" 
                CssClass="sfTxtLbl">Back link default destination</asp:Label>
            <asp:TextBox ID="BackButtonDefaultDestination" runat="server" CssClass="sfTxt" />
            <div class="sfExample"></div>
        </li>

        <li class="sfFormCtrl">
            <asp:CheckBox runat="server" ID="IsDetailsMode" Text="Enable Details Mode" CssClass="sfCheckBox" />
            <div class="sfExample"></div>
        </li>
    </ol>
</div>
