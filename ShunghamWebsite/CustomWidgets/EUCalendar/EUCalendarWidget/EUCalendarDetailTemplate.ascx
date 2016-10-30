﻿<%@ Control Language="C#" %>

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
        <li class="toggle">
            <a href="#">Policy Areas</a>
            <%--<ul>
                <li class="active"><a href="./">All Policy Areas</a></li>
            </ul>--%>
            <ul id="listView">
            </ul>
        </li>
    </ul>
</div>
<article class="b">
    <asp:Literal ID="eventDetailErrMessage" runat="server" Visible="false"></asp:Literal>
    <header>
        <p class="link-b">
            <asp:HyperLink runat="server" ID="backLink">
            <i class="icon-caret-left"></i>Back to Events List
            </asp:HyperLink>
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
        <p class="link-b mobile-only"><asp:HyperLink runat="server" ID="organizersEventLinkMobile">Organizer's Event Page 
            <i class="icon-caret-right"></i></asp:HyperLink></p>
        <ul class="list-f a">
            <li><span>When:</span> <asp:Literal runat="server" ID="startDateLtl" /></li>
            <li><span>How much:</span> <span class="text-uppercase"><asp:Literal runat="server" ID="priceLtl" />
                </span></li>
            <li><span>Policy area:</span> <asp:Literal runat="server" ID="policyAreaLtl" /></li>
            <li><span>Who:</span> <asp:Literal runat="server" ID="organizerLtl" /></li>
            <li class="before-last"><span>Where:</span> <asp:Literal runat="server" ID="locationLtl" /></li>
            <li><span>Registration deadline:</span> <asp:Literal runat="server" ID="deadlineLtl" /></li>
        </ul>
    </div>
    <footer class="double">
        <div>
            <p class="link-a"><a class="d" href="./">Add to My Calendar</a></p>
            <ul class="social-a a">
                <li><a rel="external" href="./"><i class="icon-linkedin"></i><span>LinkedIn</span></a></li>
                <li><a rel="external" href="./"><i class="icon-twitter"></i><span>Twitter</span></a></li>
                <li><a rel="external" href="./"><i class="icon-facebook"></i><span>Facebook</span></a></li>
            </ul>
        </div>
        <p class="link-b mobile-hide"><asp:HyperLink runat="server" ID="organizersEventLink">Organizer's Event Page 
            <i class="icon-caret-right"></i></asp:HyperLink></p>
    </footer>
</article>

<script type="text/javascript">

    function enterEvent(e) {
        if (e.keyCode == 13) {
            __doPostBack('<%= searchBtn.UniqueID%>', "");
        }
    }

    var serviceRoot = "https://json2jsonp.com/?url=http://shunghamdemo.crmportalconnector.com/SavedQueryService/Execute/shunghampolicyareas&callback=cbfunc";
    homogeneous = new kendo.data.HierarchicalDataSource({
        transport: {
            read: {
                url: serviceRoot,
                dataType: "jsonp"
            }
        },
        schema: {
            model: {
                id: "Id"
            }
        }
    });

    $("#listView").kendoListView({
        template: "<li><a href='javascript: void(0)' data='#=Attributes.uni_policyareaid#'>${Attributes.uni_name}</a></li>",
        dataSource: homogeneous,
        selectable: "multiple",
        dataTextField: "Attributes.uni_name"
    });

    $("#listView").on("click", "li a", function (event) {
        event.preventDefault();
        $(this).parent().toggleClass("active");
    });
</script>
