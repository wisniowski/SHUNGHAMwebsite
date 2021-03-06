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
            <asp:Label runat="server" AssociatedControlID="Title" CssClass="sfTxtLbl">Title</asp:Label>
            <sfFields:HtmlField
                ID="Title"
                runat="server"
                DisplayMode="Write"
                EditorToolsConfiguration="Standard"
                HtmlFieldEditModes="All"
                EditorContentFilters="DefaultFilters,RemoveScripts"
                EditorStripFormattingOptions="AllExceptNewLines"
                Height="200"
                IsToOverrideDialogs="false">
            </sfFields:HtmlField>
            <div class="sfExample"></div>
        </li>

        <li class="sfFormCtrl">
            <asp:Label runat="server" AssociatedControlID="Content" CssClass="sfTxtLbl">Content</asp:Label>
            <sfFields:HtmlField
                ID="Content"
                runat="server"
                DisplayMode="Write"
                EditorToolsConfiguration="Standard"
                HtmlFieldEditModes="All"
                EditorContentFilters="DefaultFilters,RemoveScripts"
                EditorStripFormattingOptions="AllExceptNewLines"
                Height="250"
                IsToOverrideDialogs="false">
            </sfFields:HtmlField>
            <div class="sfExample"></div>
        </li>

        <li class="sfFormCtrl">
            <asp:Label runat="server" CssClass="sfTxtLbl">Image</asp:Label>
            <img id="previewImage" src="" alt="" style="display: none;" />
            <span style="display: none;" class="sfSelectedItem" id="selectedImage"></span>
            <div>
                <asp:LinkButton ID="selectButtonImage" OnClientClick="return false;" runat="server" CssClass="sfLinkBtn sfChange">
        <span class="sfLinkBtnIn">
          <asp:Literal runat="server" Text="<%$Resources:Labels, SelectDotDotDot %>" />
        </span>
                </asp:LinkButton>
                <asp:LinkButton ID="deselectButtonImage" OnClientClick="return false;" runat="server" CssClass="sfLinkBtn sfChange">
        <span class="sfLinkBtnIn">
          <asp:Literal runat="server" Text="<%$Resources:Labels, Remove %>" />
        </span>
                </asp:LinkButton>
            </div>
            <sf:EditorContentManagerDialog runat="server" ID="selectorImage" DialogMode="Image" HostedInRadWindow="false" BodyCssClass="" />
            <div class="sfExample"></div>
        </li>

        <li class="sfFormCtrl">
            <asp:Label runat="server" AssociatedControlID="AlignmentSelector" CssClass="sfTxtLbl">Image Alignment:</asp:Label>
            <asp:DropDownList ID="AlignmentSelector" Width="60%" CssClass="sfTxt" runat="server" ClientIDMode="Static">
                <asp:ListItem Text="Left" />
                <asp:ListItem Text="Right" />
            </asp:DropDownList>
            <div class="sfExample">Default value: Right;</div>
        </li>

        <li class="sfFormCtrl">
            <asp:Label runat="server" AssociatedControlID="TextBackgroundColorSelector" CssClass="sfTxtLbl">Text Background Color:</asp:Label>
            <asp:DropDownList ID="TextBackgroundColorSelector" Width="60%" CssClass="sfTxt" runat="server" ClientIDMode="Static">
                <asp:ListItem Text="None" />
                <asp:ListItem Text="White" />
            </asp:DropDownList>
            <div class="sfExample">Default value: None;</div>
        </li>

    </ol>
</div>
