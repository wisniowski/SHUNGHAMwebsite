﻿<%@ Control Language="C#" ClientIDMode="Static" %>

<div id="aside" class="a">
    <h2>Filters / Search</h2>
    <ul>
        <li class="date">
            <div id="date" runat="server"></div>
            <ul>
                <li>
                    <asp:HyperLink runat="server" ID="prev">Previous month</asp:HyperLink>
                </li>
                <li>
                    <asp:HyperLink runat="server" ID="next">Next month</asp:HyperLink>
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
                        AutoPostBack="true" Text="Event Date" />
                </li>
                <li>
                    <asp:RadioButton runat="server" ID="deadlineRadioButton" GroupName="date"
                        AutoPostBack="true" Text="Event Registration Deadline" />
                </li>
            </ul>
        </li>
        <li class="toggle sub">
            <a href="#">Policy Areas</a>
            <span class="toggle"></span>
            <telerik:RadTreeView ID="policyAreasTreeView" runat="server" CheckBoxes="true" MultipleSelect="true"
                EnableEmbeddedSkins="false" EnableEmbeddedBaseStylesheet="false" ShowLineImages="false" OnClientNodeClicking="ClientNodeClicking">
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
                        <span class="scheme-a">
                            <%# DataBinder.Eval(Container.DataItem,"Attributes.new_euceventprice") == null ?
                            "Free" : DataBinder.Eval(Container.DataItem,"Attributes.new_euceventprice") %>
                        </span>
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

        $(".RadTreeView .rtLI label").addClass("checkbox");
        $(".RadTreeView input:checkbox").addClass("hidden");
        $("<div class='input'></div>").insertAfter(".RadTreeView span.rtIn");

        $(".RadTreeView .input").click(function () {
            var nodeText = $(this).prev().text();

            var node = tree.findNodeByText(nodeText);
            $(node.get_checkBoxElement()).click();
        });
    }

    function ClientNodeClicking(sender, eventArgs) {
        sender.trackChanges();
        var currentNode = eventArgs.get_node();
        sender._checkNode(new Event("click"), currentNode);
        args.set_cancel(true);
    }
</script>
