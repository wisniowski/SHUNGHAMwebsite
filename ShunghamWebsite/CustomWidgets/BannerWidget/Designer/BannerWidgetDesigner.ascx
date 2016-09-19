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
            <asp:Label runat="server" AssociatedControlID="Title" CssClass="sfTxtLbl">Banner Title</asp:Label>
            <asp:TextBox ID="Title" runat="server" CssClass="sfTxt" />
            <div class="sfExample"></div>
        </li>

        <li class="sfFormCtrl">
            <asp:Label runat="server" AssociatedControlID="SubTitle" CssClass="sfTxtLbl">Banner Subtitle</asp:Label>
            <asp:TextBox ID="SubTitle" runat="server" CssClass="sfTxt" TextMode="MultiLine" />
            <div class="sfExample"></div>
        </li>

        <li class="sfFormCtrl">
            <asp:Label runat="server" CssClass="sfTxtLbl">Background Image</asp:Label>
            <img id="previewBackgroundImageId" src="" alt="" style="display: none;" />
            <span style="display: none;" class="sfSelectedItem" id="selectedBackgroundImageId"></span>
            <div>
                <asp:LinkButton ID="selectButtonBackgroundImageId" OnClientClick="return false;" runat="server" CssClass="sfLinkBtn sfChange">
        <span class="sfLinkBtnIn">
          <asp:Literal runat="server" Text="<%$Resources:Labels, SelectDotDotDot %>" />
        </span>
                </asp:LinkButton>
                <asp:LinkButton ID="deselectButtonBackgroundImageId" OnClientClick="return false;" runat="server" CssClass="sfLinkBtn sfChange">
        <span class="sfLinkBtnIn">
          <asp:Literal runat="server" Text="<%$Resources:Labels, Remove %>" />
        </span>
                </asp:LinkButton>
            </div>
            <sf:EditorContentManagerDialog runat="server" ID="selectorBackgroundImageId" DialogMode="Image" HostedInRadWindow="false" BodyCssClass="" />
            <div class="sfExample"></div>
        </li>

        <li class="sfFormCtrl">
            <asp:Label runat="server" AssociatedControlID="FirstBtnText" CssClass="sfTxtLbl">First Button Text</asp:Label>
            <asp:TextBox ID="FirstBtnText" runat="server" CssClass="sfTxt" />
            <div class="sfExample"></div>
        </li>

        <li class="sfFormCtrl">
            <label class="sfTxtLbl" for="selectedFirstBtnLandingPageLabel">First Button Landing Page</label>
            <span style="display: none;" class="sfSelectedItem" id="selectedFirstBtnLandingPageLabel">
                <asp:Literal runat="server" Text="" />
            </span>
            <span class="sfLinkBtn sfChange">
                <a href="javascript: void(0)" class="sfLinkBtnIn" id="pageSelectButtonFirstBtnLandingPage">
                    <asp:Literal runat="server" Text="<%$Resources:Labels, SelectDotDotDot %>" />
                </a>
            </span>
            <div id="selectorTagFirstBtnLandingPage" runat="server" style="display: none;">
                <sf:PagesSelector runat="server" ID="pageSelectorFirstBtnLandingPage"
                    AllowExternalPagesSelection="true" AllowMultipleSelection="false" />
            </div>
            <div class="sfExample"></div>
        </li>

        <li class="sfFormCtrl">
            <asp:Label runat="server" AssociatedControlID="SecondBtnText" CssClass="sfTxtLbl">Second Button Text</asp:Label>
            <asp:TextBox ID="SecondBtnText" runat="server" CssClass="sfTxt" />
            <div class="sfExample"></div>
        </li>

        <li class="sfFormCtrl">
            <label class="sfTxtLbl" for="selectedSecondBtnLandingPageLabel">Second Button Landing Page</label>
            <span style="display: none;" class="sfSelectedItem" id="selectedSecondBtnLandingPageLabel">
                <asp:Literal runat="server" Text="" />
            </span>
            <span class="sfLinkBtn sfChange">
                <a href="javascript: void(0)" class="sfLinkBtnIn" id="pageSelectButtonSecondBtnLandingPage">
                    <asp:Literal runat="server" Text="<%$Resources:Labels, SelectDotDotDot %>" />
                </a>
            </span>
            <div id="selectorTagSecondBtnLandingPage" runat="server" style="display: none;">
                <sf:PagesSelector runat="server" ID="pageSelectorSecondBtnLandingPage"
                    AllowExternalPagesSelection="true" AllowMultipleSelection="false" />
            </div>
            <div class="sfExample"></div>
        </li>

    </ol>
</div>
