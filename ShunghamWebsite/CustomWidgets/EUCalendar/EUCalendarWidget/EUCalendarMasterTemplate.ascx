<%@ Control Language="C#" ClientIDMode="Static" %>

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
            <telerik:RadPersistenceManager runat="server" ID="RadPersistenceManager1">
                <PersistenceSettings>
                    <telerik:PersistenceSetting ControlID="policyAreasTreeView" />
                </PersistenceSettings>
            </telerik:RadPersistenceManager>
            <telerik:RadTreeView ID="policyAreasTreeView" runat="server" EnableEmbeddedSkins="false" ShowLineImages="false">
            </telerik:RadTreeView>
        </li>
    </ul>
</div>
<div class="module-c">
    <article>
        <telerik:RadListView ID="eventsList" ItemPlaceholderID="EventsContainer" runat="server"
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

    function pageLoad() {
        var tree = $find("<%= policyAreasTreeView.ClientID %>");
        var selectedItems = tree.get_selectedNodes();

        for (var i = selectedItems.length - 1; i >= 0; i--) {
            selectedItems[i].get_element().className = selectedItems[i].get_element().className + ' active';
        };
    }
</script>
