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
<div id="designerLayoutRoot" class="sfContentViews sfSingleContentView" style="max-height: 400px; overflow: auto; ">
<ol>        
    <li class="sfFormCtrl">
    <asp:Label runat="server" AssociatedControlID="Text" CssClass="sfTxtLbl">Button Text</asp:Label>
    <asp:TextBox ID="Text" runat="server" CssClass="sfTxt" />
    <div class="sfExample"></div>
    </li>
    
    <li class="sfFormCtrl">
    <label class="sfTxtLbl" for="selectedLandingPageIdLabel">Button Landing Page</label>
    <span style="display: none;" class="sfSelectedItem" id="selectedLandingPageIdLabel">
        <asp:Literal runat="server" Text="" />
    </span>
    <span class="sfLinkBtn sfChange">
        <a href="javascript: void(0)" class="sfLinkBtnIn" id="pageSelectButtonLandingPageId">
            <asp:Literal runat="server" Text="<%$Resources:Labels, SelectDotDotDot %>" />
        </a>
    </span>
    <div id="selectorTagLandingPageId" runat="server" style="display: none;">
        <sf:PagesSelector runat="server" ID="pageSelectorLandingPageId" 
            AllowExternalPagesSelection="true" AllowMultipleSelection="false" />
    </div>
    <div class="sfExample"></div>
    </li>
    
</ol>
</div>
