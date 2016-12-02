<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AboutUsSectionWidget.ascx.cs" Inherits="SitefinityWebApp.CustomWidgets.AboutUsSectionWidget.AboutUsSectionWidget" %>

<article class="text-justify mobile-text-center">
    <div>
        <h2 class="header-a text-center">
            <asp:Literal runat="server" ID="TitleLtl" />
        </h2>
        <div id="contentWrapper" runat="server">
            <figure class="float-right" id="imageWrapper" runat="server">
                <asp:Image ID="ImageControl" runat="server" />
            </figure>
            <div id="textWrapper">
                <asp:Literal runat="server" ID="ContentLtl" />
            </div>
        </div>
    </div>
</article>

<script type="text/javascript">
    $(function () {
        $("#textWrapper a").wrap("<p class='link-a'></p>");

        $('.header-a').html(function (i, html) {
            return html.replace(/(\w+\s)/, '<span>$1</span>');
        });

        $('#textWrapper ul').addClass('list-a a');
    });
</script>