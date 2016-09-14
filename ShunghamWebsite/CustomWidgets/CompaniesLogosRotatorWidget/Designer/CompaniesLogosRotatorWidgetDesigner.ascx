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
            <div id="AlbumIdSelector">
                <sitefinity:FolderSelector ID="AlbumIdItemSelector" runat="server"
                    AllowMultipleSelection="false"
                    BindOnLoad="false"
                    AllowSearch="true"
                    ShowButtonsArea="false"
                    WebServiceUrl="~/Sitefinity/Services/Content/AlbumService.svc/folders/">
                </sitefinity:FolderSelector>
                <asp:Panel runat="server" ID="buttonAreaPanelAlbumId" class="sfButtonArea sfSelectorBtns">
                    <asp:LinkButton ID="lnkDoneAlbumId" runat="server" OnClientClick="return false;" CssClass="sfLinkBtn sfSave">
                <strong class="sfLinkBtnIn">
                    <asp:Literal runat="server" Text="<%$Resources:Labels, Done %>" />
                </strong>
                    </asp:LinkButton>
                    <asp:Literal runat="server" Text="<%$Resources:Labels, or%>" />
                    <asp:LinkButton ID="lnkCancelAlbumId" runat="server" CssClass="sfCancel" OnClientClick="return false;">
                <asp:Literal runat="server" Text="<%$Resources:Labels, Cancel %>" />
                    </asp:LinkButton>
                </asp:Panel>
            </div>
            <label class="sfTxtLbl" for="selectedAlbumIdLabel">AlbumId</label>
            <span class="sfSelectedItem" id="selectedAlbumIdLabel">
                <asp:Literal runat="server" Text="" />
            </span>
            <asp:LinkButton ID="selectButtonAlbumId" OnClientClick="return false;" runat="server" CssClass="sfLinkBtn sfChange">
        <span class="sfLinkBtnIn">
            <asp:Literal runat="server" Text="<%$Resources:Labels, SelectDotDotDot %>" />
        </span>
            </asp:LinkButton>
            <asp:LinkButton ID="deselectButtonAlbumId" OnClientClick="return false;" runat="server" CssClass="sfLinkBtn sfChange">
      <span class="sfLinkBtnIn">
        <asp:Literal runat="server" Text="<%$Resources:Labels, Remove %>" />
      </span>
            </asp:LinkButton>
            <div class="sfExample"></div>
        </li>

    </ol>
</div>
