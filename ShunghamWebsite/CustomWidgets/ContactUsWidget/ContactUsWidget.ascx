<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactUsWidget.ascx.cs" Inherits="SitefinityWebApp.CustomWidgets.ContactUsWidget.ContactUs" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sf" %>

<article class="module-a has-background">
    <h2 class="text-center">
        <asp:Literal runat="server" ID="titleLtl" Text="<%$ Resources: ShunghamResources, ContactTitle %>" /></h2>
    <asp:Panel ID="wrapper" runat="server">
        <div class="module-b double">
            <header class="vcard a">
                <h3 class="mobile-hide">Send us a message</h3>
                <p class="fn org strong">Shungham Information sprl</p>
                <ul>
                    <li class="adr">
                        <sf:SitefinityLabel ID="streetAddressLbl" runat="server"
                            Text="<%$ Resources: ShunghamResources, StreetAddress %>" WrapperTagName="span"
                            HideIfNoText="true" CssClass="street-address" />
                        <br>
                        <sf:SitefinityLabel ID="postalCodeLbl" runat="server"
                            Text="<%$ Resources: ShunghamResources, PostalCode %>" WrapperTagName="span"
                            HideIfNoText="true" CssClass="postal-code" />
                        <sf:SitefinityLabel ID="localityLbl" runat="server"
                            Text="<%$ Resources: ShunghamResources, Locality %>" WrapperTagName="span"
                            HideIfNoText="true" CssClass="locality" />,
                         <sf:SitefinityLabel ID="countryLbl" runat="server"
                             Text="<%$ Resources: ShunghamResources, CountryName %>" WrapperTagName="span"
                             HideIfNoText="true" CssClass="country-name" />
                    </li>
                    <li>
                        <asp:Literal runat="server" ID="phoneLtl" Text="<%$ Resources: ShunghamResources, ContactPhone %>" /></li>
                    <li>
                        <asp:Literal runat="server" ID="emailLtl" Text="<%$ Resources: ShunghamResources, ContactEmail %>" /></li>
                </ul>
            </header>
            <div class="form-a">
                <h3 class="mobile-only">Send us a message</h3>
                <p class="double a">
                    <span>
                        <label for="faa" class="hidden">First Name</label>
                        <asp:TextBox runat="server" ID="faa" placeholder="First Name" />
                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server"
                            ControlToValidate="faa" EnableClientScript="false"
                            ErrorMessage="First name is required!" ValidationGroup="Submit" />
                    </span>
                    <span>
                        <label for="fab" class="hidden">Last Name</label>
                        <asp:TextBox runat="server" ID="fab" placeholder="Last Name" />
                        <asp:RequiredFieldValidator ID="rvfLastName" runat="server"
                            ControlToValidate="fab" EnableClientScript="false"
                            ErrorMessage="Last name is required!" ValidationGroup="Submit" />
                    </span>
                </p>
                <p class="double a">
                    <span>
                        <label for="fac" class="hidden">E-mail</label>
                        <asp:TextBox runat="server" ID="fac" placeholder="E-mail" TextMode="Email" />
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                            ControlToValidate="fac" EnableClientScript="false"
                            ErrorMessage="Email is required!" ValidationGroup="Submit" />
                        <asp:RegularExpressionValidator ID="expEmail" runat="server"
                            ControlToValidate="fac" ErrorMessage="Email is invalid!"
                            ValidationGroup="Submit"
                            ValidationExpression="^([a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]){1,70}$" />
                    </span>
                    <span>
                        <label for="fad" class="hidden">Phone Number</label>
                        <asp:TextBox runat="server" ID="fad" placeholder="Phone Number" TextMode="Phone" />
                    </span>
                </p>
                <p>
                    <label for="fae" class="hidden">Company</label>
                    <asp:TextBox runat="server" ID="fae" placeholder="Company" />
                </p>
                <p>
                    <label for="faf" class="hidden">Message</label>
                    <asp:TextBox runat="server" ID="faf" placeholder="Message" TextMode="MultiLine" />
                    <asp:RequiredFieldValidator ID="rfvMessage" runat="server"
                        ControlToValidate="faf" EnableClientScript="false"
                        ErrorMessage="Message is required!" ValidationGroup="Submit" />
                </p>
                <p>
                    <button validationgroup="Submit"
                        onserverclick="btnSend_Click" id="btnSend" runat="server" causesvalidation="true"
                        type="submit">
                        Send</button>
                </p>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="success" runat="server" Visible="false" CssClass="text-center">
        <p>
            <sf:SitefinityLabel ID="successfulSubmitMessage" runat="server"
                Text="<%$ Resources: ShunghamResources, SuccessfulSubmitMessage %>" WrapperTagName="strong"
                HideIfNoText="true" />
    </asp:Panel>
    <figure id="backgrdFigure" runat="server" class="background has-background">
        <asp:Image runat="server" ID="backgrdImage" Width="1920" Height="786" />
    </figure>
</article>
