<%@ Control Language="C#" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Import Namespace="Telerik.Sitefinity.Localization" %>

<telerik:RadSocialShare ID="RadSocialShare" runat="server" EnableEmbeddedSkins="false" 
    ClientIDMode="Static" CssClass="social-a a">
    <MainButtons>
        <telerik:RadSocialButton SocialNetType="LinkedIn" LabelText="LinkedIn" />
        <telerik:RadSocialButton SocialNetType="ShareOnTwitter" LabelText="Twitter" />
        <telerik:RadSocialButton SocialNetType="ShareOnFacebook" LabelText="Facebook" />
    </MainButtons>
</telerik:RadSocialShare>

<script type="text/javascript">
    $(function () {
        //custom JS logic to add custom icons to the social share buttons
        var $fbLinks = $('.RadSocialShare').find("a[title='Share on Facebook']"),
            $twitterLinks = $('.RadSocialShare').find("a[title='Tweet this']"),
            $linkedinLinks = $('.RadSocialShare').find("a[title='Share on LinkedIn']");

        $fbLinks.each(function (index) {
            $(this).html('<i class="icon-facebook"></i><span>Facebook</span>');
        });

        $twitterLinks.each(function (index) {
            $(this).html('<i class="icon-twitter"></i><span>Twitter</span>');
        });

        $linkedinLinks.each(function (index) {
            $(this).html('<i class="icon-linkedin"></i><span>LinkedIn</span>');
        })
    });
</script>
