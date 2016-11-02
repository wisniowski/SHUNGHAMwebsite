<%@ Control Language="C#" %>
<%@ Register Src="~/CustomWidgets/EUCalendar/SocialShare.ascx" TagPrefix="uc1" TagName="SocialShare" %>

<div id="aside" class="a">
    <h2>Filters / Search</h2>
    <ul>
        <li class="date">
            <div id="date" runat="server"></div>
            <ul>
                <li>
                    <asp:LinkButton runat="server" ID="prev">Previous month</asp:LinkButton>
                </li>
                <li>
                    <asp:LinkButton runat="server" ID="next">Next month</asp:LinkButton>
                </li>
            </ul>
        </li>
        <li class="search">
            <label for="asa">Search</label>
            <asp:TextBox ID="searchBox" runat="server" onkeypress="return enterEvent(event)"></asp:TextBox>
            <button type="submit" id="searchBtn" runat="server">Submit</button>
        </li>
        <li class="toggle"><a href="./">Sort by</a>
            <ul>
                <li>
                    <asp:RadioButton runat="server" ID="startDateRadioButton" GroupName="date"
                        AutoPostBack="true" Text="Event Date" CssClass="sortRadio" />
                </li>
                <li>
                    <asp:RadioButton runat="server" ID="deadlineRadioButton" GroupName="date"
                        AutoPostBack="true" Text="Event Registration Deadline" CssClass="sortRadio" />
                </li>
            </ul>
        </li>
        <li class="toggle sub">
            <a href="#">Policy Areas</a>
            <span class="toggle"></span>
            <asp:Repeater ID="policyAreasRepeater" runat="server">
                <HeaderTemplate>
                    <ul>
                        <li runat="server" id="allWrapper" class="active">
                            <asp:LinkButton runat="server" ID="all" Text="All Policy Areas" 
                                CommandName="all" />
                        </li>
                </HeaderTemplate>
                <ItemTemplate>
                    <li runat="server" id="linkWrapper">
                        <asp:LinkButton ID="link" runat="server" />
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </li>
    </ul>
</div>
<div class="module-c">
    <article class="b">
        <asp:Literal ID="eventDetailErrMessage" runat="server" Visible="false"></asp:Literal>
        <header>
            <p class="link-b">
                <a runat="server" id="backButtonLink"></a>
            </p>
            <h2>
                <asp:Literal ID="titleLtl" runat="server" />
            </h2>
        </header>
        <div class="double b inv">
            <div>
                <h3 class="size-b">Event description:</h3>
                <p>
                    <asp:Literal ID="descriptionLtl" runat="server" />
                </p>
            </div>
            <ul class="list-f a">
                <li><span>When:</span>
                    <asp:Literal runat="server" ID="startDateLtl" /></li>
                <li><span>How much:</span> <span class="text-uppercase">
                    <asp:Literal runat="server" ID="priceLtl" />
                </span></li>
                <li><span>Policy area:</span>
                    <asp:Literal runat="server" ID="policyAreaLtl" /></li>
                <li><span>Who:</span>
                    <asp:Literal runat="server" ID="organizerLtl" /></li>
                <li class="before-last"><span>Where:</span>
                    <asp:Literal runat="server" ID="locationLtl" /></li>
                <li><span>Registration deadline:</span>
                    <asp:Literal runat="server" ID="deadlineLtl" /></li>
            </ul>
        </div>
        <footer class="double">
            <div>
                <p class="link">
                    <span class="addtocalendar atc-style-blue"
                        data-calendars="iCalendar, Google Calendar, Outlook">
                        <a class="atcb-link">Add to My Calendar</a>
                        <var class="atc_event">
                            <telerik:RadListView ID="singleEvent" ItemPlaceholderID="EventsContainer" runat="server"
                                EnableEmbeddedSkins="false" EnableEmbeddedBaseStylesheet="false">
                                <LayoutTemplate>
                                    <asp:PlaceHolder ID="EventsContainer" runat="server" />
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <var class="atc_date_start">
                                        <%# DataBinder.Eval(Container.DataItem, "Attributes.new_eucstartdate", "{0:yyyy-MM-dd}") %>
                                        <%# DataBinder.Eval(Container.DataItem, "Attributes.new_eucstarttime", "{0:hh:MM:ss}") %>
                                    </var>
                                    <var class="atc_date_end">
                                        <%# DataBinder.Eval(Container.DataItem, "Attributes.new_eucenddate", "{0:yyyy-MM-dd}") %>
                                        <%# DataBinder.Eval(Container.DataItem, "Attributes.new_eucendtime", "{0:hh:MM:ss}") %>
                                    </var>
                                    <var class="atc_timezone">Europe/London</var>
                                    <var class="atc_title">
                                        <%# DataBinder.Eval(Container.DataItem,"Attributes.cdi_name") %>
                                    </var>
                                    <var class="atc_description">
                                        <%# DataBinder.Eval(Container.DataItem,"Attributes.new_euceventdescription") %>
                                    </var>
                                    <var class="atc_location">
                                        <%# DataBinder.Eval(Container.DataItem,"Attributes.new_euclocation.Name") %>
                                    </var>
                                    <var class="atc_organizer">
                                        <%# DataBinder.Eval(Container.DataItem,"Attributes.organiserName.Value") %>
                                    </var>
                                </ItemTemplate>
                            </telerik:RadListView>
                        </var>
                    </span>
                </p>
                <uc1:SocialShare runat="server" ID="SocialShare" />
            </div>
            <p class="link-b mobile-hide">
                <asp:HyperLink runat="server" ID="organizersEventLink" Target="_blank">Organizer's Event Page 
            <i class="icon-caret-right"></i></asp:HyperLink>
            </p>
        </footer>
    </article>
    <article>
        <h3>Other Events Similar to this <span class="no"><asp:Literal ID="count" runat="server" /></span></h3>
        <telerik:RadListView ID="otherEventsList" ItemPlaceholderID="EventsContainer" runat="server"
            EnableEmbeddedSkins="false" EnableEmbeddedBaseStylesheet="false">
            <LayoutTemplate>
                <ul class="list-h a">
                    <asp:PlaceHolder ID="EventsContainer" runat="server" />
                </ul>
            </LayoutTemplate>
            <ItemTemplate>
                <li>
                    <header>
                        <p>
                            <span>
                                <span><%# DataBinder.Eval(Container.DataItem, "Attributes.new_eucstartdate", "{0:dd}") %></span>
                                <%# DataBinder.Eval(Container.DataItem, "Attributes.new_eucstartdate", "{0:MMM}") %>
                            </span>
                            <%# DataBinder.Eval(Container.DataItem, "Attributes.new_eucstarttime", "{0:HH:mm}") %>
                            <%# DataBinder.Eval(Container.DataItem, "Attributes.new_eucstartdate", "{0:ddd}") %>
                        </p>
                        <p>
                            Registration Deadline: <span>
                                <%# DataBinder.Eval(Container.DataItem, "Attributes.new_eucregistrationdeadline").ToString() == DateTime.MinValue.ToString() ?
                                "No deadline" : DataBinder.Eval(Container.DataItem, "Attributes.new_eucregistrationdeadline", "{0:dd MMM ddd}")
                                %>
                            </span>
                        </p>
                    </header>
                    <h2>
                        <%# DataBinder.Eval(Container.DataItem,"Attributes.cdi_name") %>
                        <span class="scheme-a"><%# DataBinder.Eval(Container.DataItem,"Attributes.new_euceventprice") %></span>
                    </h2>
                    <ul>
                        <li><span>Policy Area:</span>
                            <asp:Literal runat="server" ID="policyAreaLtl"
                                Text='<%#(DataBinder.Eval(Container.DataItem, "Attributes.policyAreaName.Value"))%>' /></li>
                        <li><span>Who:</span>
                            <asp:Literal runat="server" ID="organizerLtl"
                                Text='<%#(DataBinder.Eval(Container.DataItem, "Attributes.organiserName.Value"))%>' /></li>
                        <li><span>Where:</span>
                            <asp:Literal runat="server" ID="locationLtl"
                                Text='<%#(DataBinder.Eval(Container.DataItem, "Attributes.new_euclocation.Name"))%>' /></li>
                    </ul>
                    <p class="link">
                        <asp:HyperLink runat="server" ID="detailViewLink">Open</asp:HyperLink>
                    </p>
                </li>
            </ItemTemplate>
            <EmptyDataTemplate>
                <p>No known events were found.</p>
                <p>
                    Have an event and want to see it here? Let us know!<br>
                    <a href="mailto:info@eucalendar.com">info@eucalendar.com</a>
                </p>
            </EmptyDataTemplate>
        </telerik:RadListView>
    </article>
</div>

<script type="text/javascript">

    function enterEvent(e) {
        if (e.keyCode == 13) {
            __doPostBack('<%= searchBtn.UniqueID%>', "");
        }
    }

</script>
