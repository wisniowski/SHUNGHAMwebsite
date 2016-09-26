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
    <div id="ProductIdSelector">
        <sitefinity:FlatSelector ID="ProductIdItemSelector" runat="server" ItemType="Telerik.Sitefinity.DynamicTypes.Model.Products.Product"
                DataKeyNames="Id" ShowSelectedFilter="false" AllowPaging="false" PageSize="10"
                AllowSearching="true" ShowProvidersList="true" InclueAllProvidersOption="false"
                SearchBoxTitleText="Filter by Title" ShowHeader="true"
                ServiceUrl="~/Sitefinity/Services/DynamicModules/Data.svc/live">
            <DataMembers>
                <sitefinity:DataMemberInfo ID="DataMemberInfoProductId" runat="server" Name="Title" IsExtendedSearchField="true" HeaderText="Title">
                    <span>{{Title.Value}}</span>
                </sitefinity:DataMemberInfo>
            </DataMembers>
        </sitefinity:FlatSelector>
        <asp:Panel runat="server" ID="buttonAreaPanelProductId" class="sfButtonArea sfSelectorBtns">
            <asp:LinkButton ID="lnkDoneProductId" runat="server" OnClientClick="return false;" CssClass="sfLinkBtn sfSave">
                <strong class="sfLinkBtnIn">
                    <asp:Literal runat="server" Text="<%$Resources:Labels, Done %>" />
                </strong>
            </asp:LinkButton>
            <asp:Literal runat="server" Text="<%$Resources:Labels, or%>" />
            <asp:LinkButton ID="lnkCancelProductId" runat="server" CssClass="sfCancel" OnClientClick="return false;">
                <asp:Literal runat="server" Text="<%$Resources:Labels, Cancel %>" />
            </asp:LinkButton>
        </asp:Panel>
    </div>
    <label class="sfTxtLbl" for="selectedProductIdLabel">Related Product</label>
    <span class="sfSelectedItem" id="selectedProductIdLabel">
        <asp:Literal runat="server" Text="" />
    </span>
    <asp:LinkButton ID="selectButtonProductId" OnClientClick="return false;" runat="server" CssClass="sfLinkBtn sfChange">
        <span class="sfLinkBtnIn">
            <asp:Literal runat="server" Text="<%$Resources:Labels, SelectDotDotDot %>" />
        </span>
    </asp:LinkButton>
    <asp:LinkButton ID="deselectButtonProductId" OnClientClick="return false;" runat="server" CssClass="sfLinkBtn sfChange">
      <span class="sfLinkBtnIn">
        <asp:Literal runat="server" Text="<%$Resources:Labels, Remove %>" />
      </span>
    </asp:LinkButton>
    <div class="sfExample"></div>
    </li>
    
</ol>
</div>
