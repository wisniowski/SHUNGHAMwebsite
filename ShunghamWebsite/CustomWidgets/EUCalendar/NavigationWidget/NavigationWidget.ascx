<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavigationWidget.ascx.cs" Inherits="SitefinityWebApp.CustomWidgets.EUCalendar.NavigationWidget.NavigationWidget" ClientIDMode="Static" %>

<div id="aside" class="a">
    <h2>Filters / Search</h2>
    <ul>
        <li class="date">
            <div id="date"></div>
            <ul>
                <li><a onclick="displayPrevMonth()" href="javascript: void(0)">Previous month</a></li>
                <li><a onclick="displayNextMonth()" href="javascript: void(0)">Next month</a></li>
            </ul>
        </li>
        <li class="search">
            <label for="asa">Search</label>
            <input type="text" id="asa" name="asa" required>
            <button type="submit">Submit</button>
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
                <li><a href="./">Agriculture &amp; Fisheries</a></li>
                <li><a href="./">Chemicals</a></li>
                <li><a href="./">Competition</a></li>
                <li><a href="./">Consumers</a></li>
                <li><a href="./">Culture &amp; Education</a></li>
                <li><a href="./">Economic &amp; Monetary</a></li>
                <li><a href="./">Employment &amp; Social</a></li>
                <li><a href="./">Energy &amp; Climate</a></li>
                <li><a href="./">Environment</a></li>
                <li><a href="./">Financial Services</a></li>
                <li><a href="./">Foreign &amp; Security</a></li>
                <li><a href="./">Health &amp; Pharma</a></li>
                <li><a href="./">Human Rights &amp; Development</a></li>
                <li><a href="./">ICT, Research &amp; Innovation</a></li>
                <li><a href="./">Institutional</a></li>
                <li><a href="./">Justice &amp; Home Affairs</a></li>
                <li><a href="./">Regional &amp; Cohesion</a></li>
                <li><a href="./">Single Market &amp; Industry</a></li>
                <li><a href="./">Trade</a></li>
                <li><a href="./">Transport</a></li>
            </ul>--%>
            <ul id="listView">
            </ul>
        </li>
    </ul>
</div>

<script type="text/javascript">
    function pageLoad() {
        $('#date').html(Date.today().toString('MMMM yyyy'));
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
        template: "<li><a href='javascript: void(0)'>${Attributes.uni_name}</a></li>",
        dataSource: homogeneous,
        selectable: "multiple",
        dataTextField: "Attributes.uni_name"
    });

    $("#listView").on("click", "li", function (event) {
        $(this).toggleClass("active");
    });
</script>
