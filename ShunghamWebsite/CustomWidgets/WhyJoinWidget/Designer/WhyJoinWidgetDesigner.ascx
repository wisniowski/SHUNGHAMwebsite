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
    <asp:Label runat="server" AssociatedControlID="Title" CssClass="sfTxtLbl">Title</asp:Label>
    <asp:TextBox ID="Title" runat="server" CssClass="sfTxt" />
    <div class="sfExample"></div>
    </li>
    
    <li class="sfFormCtrl">
    <asp:Label runat="server" AssociatedControlID="Content" CssClass="sfTxtLbl">Content</asp:Label>
    <asp:TextBox ID="Content" runat="server" CssClass="sfTxt" />
    <div class="sfExample"></div>
    </li>
    
    <li class="sfFormCtrl">
    <asp:Label runat="server" AssociatedControlID="FirstButtonText" CssClass="sfTxtLbl">First Button Text</asp:Label>
    <asp:TextBox ID="FirstButtonText" runat="server" CssClass="sfTxt" />
    <div class="sfExample"></div>
    </li>
    
    <li class="sfFormCtrl">
    <label class="sfTxtLbl" for="selectedFirstButtonLandingPageLabel">First Button Landing Page</label>
    <span style="display: none;" class="sfSelectedItem" id="selectedFirstButtonLandingPageLabel">
        <asp:Literal runat="server" Text="" />
    </span>
    <span class="sfLinkBtn sfChange">
        <a href="javascript: void(0)" class="sfLinkBtnIn" id="pageSelectButtonFirstButtonLandingPage">
            <asp:Literal runat="server" Text="<%$Resources:Labels, SelectDotDotDot %>" />
        </a>
    </span>
    <div id="selectorTagFirstButtonLandingPage" runat="server" style="display: none;">
        <sf:PagesSelector runat="server" ID="pageSelectorFirstButtonLandingPage" 
            AllowExternalPagesSelection="false" AllowMultipleSelection="false" />
    </div>
    <div class="sfExample"></div>
    </li>

    <li class="sfFormCtrl">
        <asp:Label runat="server" AssociatedControlID="FirstBtnBackgroundSelector" CssClass="sfTxtLbl">First Button Background color:</asp:Label>
        <asp:DropDownList ID="FirstBtnBackgroundSelector" Width="60%" CssClass="sfTxt" runat="server" ClientIDMode="Static">
            <asp:ListItem Text="Red" Selected="True" />
            <asp:ListItem Text="White" />
            <asp:ListItem Text="Blue" />
        </asp:DropDownList>
        <div class="sfExample">Default Value: Red;</div>
    </li>
    
    <li class="sfFormCtrl">
    <asp:Label runat="server" AssociatedControlID="SecondButtonText" CssClass="sfTxtLbl">Second Button Text</asp:Label>
    <asp:TextBox ID="SecondButtonText" runat="server" CssClass="sfTxt" />
    <div class="sfExample"></div>
    </li>
    
    <li class="sfFormCtrl">
    <label class="sfTxtLbl" for="selectedSecondButtonLandingPageLabel">Second Button Landing Page</label>
    <span style="display: none;" class="sfSelectedItem" id="selectedSecondButtonLandingPageLabel">
        <asp:Literal runat="server" Text="" />
    </span>
    <span class="sfLinkBtn sfChange">
        <a href="javascript: void(0)" class="sfLinkBtnIn" id="pageSelectButtonSecondButtonLandingPage">
            <asp:Literal runat="server" Text="<%$Resources:Labels, SelectDotDotDot %>" />
        </a>
    </span>
    <div id="selectorTagSecondButtonLandingPage" runat="server" style="display: none;">
        <sf:PagesSelector runat="server" ID="pageSelectorSecondButtonLandingPage" 
            AllowExternalPagesSelection="false" AllowMultipleSelection="false" />
    </div>
    <div class="sfExample"></div>
    </li>

    <li class="sfFormCtrl">
        <asp:Label runat="server" AssociatedControlID="SecondBtnBackgroundSelector" CssClass="sfTxtLbl">Second Button Background color:</asp:Label>
        <asp:DropDownList ID="SecondBtnBackgroundSelector" Width="60%" CssClass="sfTxt" runat="server" ClientIDMode="Static">
            <asp:ListItem Text="Red" Selected="True" />
            <asp:ListItem Text="White" />
            <asp:ListItem Text="Blue" />
        </asp:DropDownList>
        <div class="sfExample">Default Value: Red;</div>
    </li>
    
</ol>
</div>
