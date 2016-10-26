<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavigationWidget.ascx.cs" Inherits="SitefinityWebApp.CustomWidgets.EUCalendar.NavigationWidget.NavigationWidget" %>
<div id="aside" class="a">
    <h2>Filters / Search</h2>
    <ul>
        <li class="date">March 2016
							<ul>
                                <li><a href="./">Previous month</a></li>
                                <li><a href="./">Next month</a></li>
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
        <li class="toggle"><a href="./">Policy Areas</a>
            <ul>
                <li><a href="./">All Policy Areas</a></li>
                <li><a href="./">Agriculture &amp; Fisheries</a></li>
                <li><a href="./">Chemicals</a></li>
                <li><a href="./">Competition</a></li>
                <li><a href="./">Consumers</a></li>
                <li class="active"><a href="./">Culture &amp; Education</a></li>
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
            </ul>
        </li>
    </ul>
</div>
