<%@ Control Language="C#" %>
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
            <asp:Label ID="Label2" runat="server" AssociatedControlID="DaysToDisplayUpdatesWithin" 
                CssClass="sfTxtLbl">Days within to display dossier updates</asp:Label>
            <asp:TextBox ID="DaysToDisplayUpdatesWithin" runat="server" CssClass="sfTxt" />
            <div class="sfExample"></div>
        </li>

        <li class="sfFormCtrl">
            <asp:CheckBox runat="server" ID="DisplayOtherUpdates" Text="Display other updates" CssClass="sfCheckBox" />
            <div class="sfExample"></div>
        </li>
    </ol>
</div>
