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
    <label class="sfTxtLbl" for="selectedApplyNowLandingPageLabel">'Apply Now' Button's Landing Page</label>
    <span style="display: none;" class="sfSelectedItem" id="selectedApplyNowLandingPageLabel">
        <asp:Literal runat="server" Text="" />
    </span>
    <span class="sfLinkBtn sfChange">
        <a href="javascript: void(0)" class="sfLinkBtnIn" id="pageSelectButtonApplyNowLandingPage">
            <asp:Literal runat="server" Text="<%$Resources:Labels, SelectDotDotDot %>" />
        </a>
    </span>
    <div id="selectorTagApplyNowLandingPage" runat="server" style="display: none;">
        <sf:PagesSelector runat="server" ID="pageSelectorApplyNowLandingPage" 
            AllowExternalPagesSelection="false" AllowMultipleSelection="false" />
    </div>
    <div class="sfExample"></div>
    </li>
    
</ol>
</div>
