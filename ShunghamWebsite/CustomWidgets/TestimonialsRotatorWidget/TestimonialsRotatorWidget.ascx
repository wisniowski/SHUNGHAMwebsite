<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TestimonialsRotatorWidget.ascx.cs" Inherits="SitefinityWebApp.CustomWidgets.TestimonialsRotatorWidget.TestimonialsRotatorWidget" %>

<telerik:RadListView ID="testimonialsList" ItemPlaceholderID="TestimonialsContainer" runat="server"
    EnableEmbeddedSkins="false" EnableEmbeddedBaseStylesheet="false">
    <LayoutTemplate>
        <ul class="list-d">
            <asp:PlaceHolder ID="TestimonialsContainer" runat="server" />
        </ul>
    </LayoutTemplate>
    <ItemTemplate>
        <li>
            <q>
                <asp:Literal Text='<%# Eval("Testimonial")%>' runat="server" />
            </q>
            <span class="strong overlay-a">
                <asp:Literal Text='<%# Eval("PersonName")%>' runat="server" />
            </span>
            ,<asp:Literal Text='<%# Eval("PersonJobTitle")%>' runat="server" />, 
            <span class="strong">
                <asp:Literal Text='<%# Eval("Organization")%>' runat="server" />
            </span>
        </li>
    </ItemTemplate>
</telerik:RadListView>
