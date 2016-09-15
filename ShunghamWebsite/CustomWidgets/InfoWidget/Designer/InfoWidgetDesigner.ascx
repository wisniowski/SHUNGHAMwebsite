<%@ Control %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sf" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sitefinity" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register Assembly="Telerik.Sitefinity" TagPrefix="sfFields" Namespace="Telerik.Sitefinity.Web.UI.Fields" %>

<sitefinity:ResourceLinks ID="resourcesLinks" runat="server">
    <sitefinity:ResourceFile Name="Styles/Ajax.css" />
</sitefinity:ResourceLinks>
<div id="designerLayoutRoot" class="sfContentViews sfSingleContentView" style="max-height: 400px; overflow: auto;">
    <ol>
        <li class="sfFormCtrl">
            <asp:Label runat="server" AssociatedControlID="Title" CssClass="sfTxtLbl">
        <asp:Literal runat="server" Text='<%$ Resources:ShunghamResources, InfoWidgetTitleLabelInDesigner%>' />
            </asp:Label>
            <asp:TextBox ID="Title" runat="server" CssClass="sfTxt" />
        </li>

        <li class="sfFormCtrl">
            <asp:Label runat="server" AssociatedControlID="Summary" CssClass="sfTxtLbl">
        <asp:Literal runat="server" Text='<%$ Resources:ShunghamResources, InfoWidgetSummaryLabelInDesigner%>' />
            </asp:Label>
            <asp:TextBox ID="Summary" runat="server" CssClass="sfTxt" TextMode="MultiLine" Rows="5" Width="600" />
        </li>

        <li class="sfFormCtrl">
            <asp:Label runat="server" AssociatedControlID="Content" CssClass="sfTxtLbl">
        <asp:Literal runat="server" Text='<%$ Resources:ShunghamResources, InfoWidgetContentLabelInDesigner%>' />
            </asp:Label>
            <asp:TextBox ID="Content" runat="server" CssClass="sfTxt" TextMode="MultiLine" Rows="15" Width="600" Height="200" />
        </li>

    </ol>
</div>
