<%@ Control Language="C#" ClientIDMode="Static" %>

<div id="aside" class="a">
    <h2>Filters / Search</h2>
    <ul>
        <li class="date">
            <div id="date"></div>
            <ul>
                <li><a id="prev" onclick="displayPrevMonth()" href="javascript: void(0)">Previous month</a></li>
                <li><a id="next" onclick="displayNextMonth()" href="javascript: void(0)">Next month</a></li>
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
                    <label for="asb">
                        <input type="radio" id="asb" name="as">
                        Event Date</label></li>
                <li>
                    <label for="asc">
                        <input type="radio" id="asc" name="as">
                        Event Registration Deadline</label></li>
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
                        <p><span><span>21</span> mar</span> 09:00 mon</p>
                        <p>Registration Deadline: <span>
                            <asp:Literal runat="server" ID="deadlineLtl" /></span></p>
                    </header>
                    <h2>
                        <asp:Literal runat="server" ID="titleLtl" /></h2>
                    <ul>
                        <li><span>Policy Area:</span>
                            <asp:Literal runat="server" ID="policyAreaLtl" /></li>
                        <li><span>Who:</span>
                            <asp:Literal runat="server" ID="organizerLtl" /></li>
                        <li><span>Where:</span>
                            <asp:Literal runat="server" ID="locationLtl" /></li>
                    </ul>
                    <p class="link"><a href="./">Open</a></p>
                </li>
            </ItemTemplate>
        </telerik:RadListView>
    </article>
</div>

<script type="text/javascript">
    function pageLoad() {
        $('#date').html(Date.today().toString('MMMM yyyy'));
    }

    function enterEvent(e) {
        if (e.keyCode == 13) {
            __doPostBack('<%= searchBtn.UniqueID%>', "");
        }
    }

    function displayPrevMonth() {
        var currentMonth = Date.parse($('#date').text());
        var prevMonth = currentMonth.add(-1).months();
        $('#date').html(prevMonth.toString('MMMM yyyy'));
    }

    function displayNextMonth() {
        var currentMonth = Date.parse($('#date').text());
        var nextMonth = currentMonth.add(1).months();
        $('#date').html(nextMonth.toString('MMMM yyyy'));
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
