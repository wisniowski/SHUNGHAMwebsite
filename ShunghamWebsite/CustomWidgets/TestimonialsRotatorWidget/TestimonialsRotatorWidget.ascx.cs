using System;
using System.Linq;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Model;
using ShunghamUtilities;

namespace SitefinityWebApp.CustomWidgets.TestimonialsRotatorWidget
{
    public partial class TestimonialsRotatorWidget : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateTestimonialsRotator();
        }

        private void PopulateTestimonialsRotator()
        {
            var slides = DynamicModulesUtilities.GetDataItemsByType(testimonialsType);
            if (slides != null)
            {
                this.testimonialsList.DataSource = slides.ToList().OrderBy(a => a.GetValue("SliderPosition"));
                this.testimonialsList.DataBind();
            }
        }

        private const string testimonialsType = "Telerik.Sitefinity.DynamicTypes.Model.Testimonials.Testimonial";
    }
}